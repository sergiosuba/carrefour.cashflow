using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Linq;
using System.Reflection;
using cashflow.domain.Interface.Repository;

namespace cashflow.infrastructure.repository
{
    public class GenericRepository<TEntity> : BaseRepository, IGenericRepository<TEntity> where TEntity : class
    {
        private readonly IDatabaseConnectionFactory _connectionFactory;
        private HelpersDataBase<TEntity> _helper = new HelpersDataBase<TEntity>();

        private string sql = string.Empty;

        public GenericRepository(IDatabaseConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;

            SqlMapperExtensions.TableNameMapper = (type) => type.Name;
        }

        public async Task AddAsync(TEntity entity)
        {
            {
                using (var conn = _connectionFactory.GetConnection())
                {
                    try
                    {
                        await conn.InsertAsync<TEntity>(entity);
                    }
                    catch (Exception e)
                    {
                        if (!e.Message.Trim().Contains("no such function: SCOPE_IDENTITY")) //TODO Required for SQLite support used in unit tests
                            throw new Exception($"{nameof(AddAsync)} -> Error adding a new record. Exception: {e.Message}");
                    }
                }
            }
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            using (var conn = _connectionFactory.GetConnection())
            {
                try
                {
                    return await conn.GetAsync<TEntity>(id);
                }
                catch (Exception e)
                {
                    throw new Exception($"{nameof(GetByIdAsync)} -> Error geting a record. Exception: {e.Message}");
                }
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync<TFilter>(TFilter filter)
        {
            using (var conn = _connectionFactory.GetConnection())
            {
                IEnumerable<TEntity> result;

                var sqlQuery = _helper.GetDynamicQuery(filter);

                try
                {
                    if (string.IsNullOrEmpty(sqlQuery.Result))
                    {
                        result = await conn.GetAllAsync<TEntity>();
                    }
                    else
                    {
                        result = await conn.QueryAsync<TEntity>(sqlQuery.Result);
                    }
                    return result.ToList();
                }
                catch (Exception e)
                {
                    throw new Exception($"{nameof(GetAllAsync)} -> Error geting the record. Exception: {e.Message}");
                }
            }
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            using (var conn = _connectionFactory.GetConnection())
            {
                try
                {
                    return await conn.UpdateAsync<TEntity>(entity);
                }
                catch (Exception e)
                {
                    throw new Exception($"{nameof(UpdateAsync)} -> Error updating record. Exception: {e.Message}");
                }
            }
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            using (var conn = _connectionFactory.GetConnection())
            {
                try
                {
                    return await conn.DeleteAsync<TEntity>(entity);
                }
                catch (Exception e)
                {
                    throw new Exception($"{nameof(DeleteAsync)} -> Error deleting record. Exception: {e.Message}");
                }
            }
        }

        public async Task<IEnumerable<dynamic>> ExecuteStoredProcedureAsync(TEntity filter)
        {
            using (var conn = _connectionFactory.GetConnection())
            {
                try
                {
                    var _helpers = new HelpersDataBase<TEntity>();

                    var parameters = _helpers.GetDynamicParameters(filter);

                    var result = await conn.QueryAsync<dynamic>("", parameters, commandType: System.Data.CommandType.StoredProcedure);

                    return result.ToList();
                }
                catch (Exception e)
                {
                    throw new Exception($"{nameof(ExecuteStoredProcedureAsync)} -> Error execution store procedure. Exception : {e.Message}");
                }
            }
        }
    }
}