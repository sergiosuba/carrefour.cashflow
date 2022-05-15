using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Sqlite;

namespace Cashflow.Test.UnitTest.Repository
{
    public class InMemoryDatabase : IInMemoryDatabase
    {
        private readonly OrmLiteConnectionFactory _dbFactory = new OrmLiteConnectionFactory(":memory:", SqliteOrmLiteDialectProvider.Instance);

        public IDbConnection OpenConnection() => this._dbFactory.OpenDbConnection();

        public void CreateTable<T>()
        {
            using (var conn = this.OpenConnection())
            {
                conn.CreateTableIfNotExists<T>();
            }
        }

        public void Insert<T>(IEnumerable<T> items)
        {
            var con = OpenConnection();

            con.CreateTableIfNotExists<T>();

            con.InsertAll(typeof(T).Name, items);
        }
    }

    public sealed class DbColumnAttribute : Attribute
    {
        public string Name { get; set; }

        public DbColumnAttribute(string name)
        {
            Name = name;
        }
    }
    internal static class DbConnectionExtensions
    {
        public static void CreateTableIfNotExists<T>(this IDbConnection connection)
        {
            var columns = GetColumnsForType<T>();
            var fields = string.Join(", ", columns.Select(x => $"[{x.Item1}] TEXT"));
            string[] fields1 = fields.Split(",");
            string key = fields1[0];
            key = key + " PRIMARY KEY";
            fields = fields.Replace(fields1[0], key);

            var sql = $"CREATE TABLE IF NOT EXISTS [{typeof(T).Name}] ({fields}) WITHOUT ROWID";

            ExecuteNonQuery(sql, connection);
        }

        public static void Insert<T>(this IDbConnection connection, string tableName, T item)
        {
            var properties = typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .ToDictionary(x => x.Name, y => y.GetValue(item, null));

            var fields = string.Join(", ", properties.Select(x => $"[{x.Key}]"));

            var values = string.Join(", ", properties.Select(x => EnsureSqlSafe(x.Value)));

            var sql = $"INSERT INTO [{typeof(T).Name}] ({fields}) VALUES ({values})";

            ExecuteNonQuery(sql, connection);
        }

        public static void InsertAll<T>(this IDbConnection connection, string tableName, IEnumerable<T> items)
        {
            foreach (var item in items)
                Insert(connection, tableName, item);
        }

        private static IEnumerable<Tuple<string, Type>> GetColumnsForType<T>()
        {
            return from pinfo in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                   let attribute = pinfo.GetCustomAttribute<DbColumnAttribute>()
                   let columnName = attribute?.Name ?? pinfo.Name
                   select new Tuple<string, Type>(columnName, pinfo.PropertyType);
        }

        private static void ExecuteNonQuery(string commandText, IDbConnection connection)
        {
            using (var com = connection.CreateCommand())
            {
                com.CommandText = commandText;

                com.ExecuteNonQuery();
            }
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