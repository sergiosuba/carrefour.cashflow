using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Dapper;

namespace cashflow.infrastructure.repository
{
    public class HelpersDataBase<TEntity> where TEntity : class
    {
        public HelpersDataBase()
        {

        }
        public DynamicParameters GetDynamicParameters<TFilter>(TFilter filter, string sql = null)
        {
            var parameters = new DynamicParameters();

            string props = string.Empty;

            var properties = typeof(TFilter)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .ToDictionary(x => x.Name, y => y.GetValue(filter, null));

            foreach (var prop in properties)
            {
                if (IsNumber(prop.Value))
                {
                    if (prop.Value.ToString() != "0")
                        parameters.Add($"{prop.Key.ToString()}", EnsureSqlSafe(prop.Value));
                }
                else
                {
                    if (!string.IsNullOrEmpty(prop.Value.ToString()))
                        parameters.Add($"{prop.Key.ToString()}", EnsureSqlSafe(prop.Value));
                }
            }
            return parameters;
        }

        public async Task<string> GetDynamicQuery<TFilter>(TFilter filter)
        {
            await Task.Yield();

            string sqlQuery = string.Empty;

            string parameters = string.Empty;

            string props = string.Empty;

            var properties = typeof(TFilter)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .ToDictionary(x => x.Name, y => y.GetValue(filter, null));

            foreach (var prop in properties)
            {
                if (IsNumber(prop.Value))
                {
                    if (prop.Value.ToString() != "0")
                        parameters += $"AND {prop.Key.ToString()} = {EnsureSqlSafe(prop.Value)} ";
                }
                else
                {
                    if (prop.Value != null)
                        if (!string.IsNullOrEmpty(prop.Value.ToString()))
                            parameters += $"AND {prop.Key.ToString()} = {EnsureSqlSafe(prop.Value)} ";
                }
            }

            if (!string.IsNullOrEmpty(parameters))
                sqlQuery = $"SELECT * FROM {typeof(TEntity).Name} WHERE 1 = 1 " + parameters;

            return sqlQuery;
        }

        private static string EnsureSqlSafe(object value)
        {
            return IsNumber(value)
                ? $"{value}"
                : $"'{value}'";
        }

        private static bool IsNumber(object value)
        {
            var s = value as string ?? "";

            if (s.Length > 1 && s.StartsWith("0"))
                return false;

            return long.TryParse(s, out long l);
        }
    }
}