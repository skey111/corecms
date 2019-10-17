using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Skey.Core.Framework.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public class BaseRepository<T, TKey> : IBaseRepository<T, TKey> where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public BaseRepository(IConfiguration configuration)
        {
            var dbtype = configuration["DbType"];
            DbType db = DbType.SqlServer;
            if (dbtype.Equals("mysql", System.StringComparison.CurrentCultureIgnoreCase))
            {
                db = DbType.MySQL;
                SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            }
            else if (dbtype.Equals("postgresql", System.StringComparison.CurrentCultureIgnoreCase))
            {
                db = DbType.PostgreSQL;
                SimpleCRUD.SetDialect(SimpleCRUD.Dialect.PostgreSQL);
            }
            else
            {
                db = DbType.SqlServer;
                SimpleCRUD.SetDialect(SimpleCRUD.Dialect.SQLServer);
            }
            _dbConnection = ConnectionFactory.CreateConnection(db, configuration.GetConnectionString("DefaultConnection"));
        }

        protected IDbConnection _dbConnection;

        public int Delete(TKey id)
        {
            return _dbConnection.Delete<T>(id);
        }

        public int Delete(T entity)
        {
            return _dbConnection.Delete(entity);
        }

        public Task<int> DeleteAsync(TKey id)
        {
            return _dbConnection.DeleteAsync(id);
        }

        public Task<int> DeleteAsync(T entity)
        {
            return _dbConnection.DeleteAsync(entity);
        }

        public int DeleteList(object whereConditions, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return _dbConnection.DeleteList<T>(whereConditions, transaction, commandTimeout);
        }

        public int DeleteList(string conditions, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return _dbConnection.DeleteList<T>(conditions, parameters, transaction, commandTimeout);
        }

        public async Task<int> DeleteListAsync(object whereConditions, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return await _dbConnection.DeleteListAsync<T>(whereConditions, transaction, commandTimeout);
        }

        public async Task<int> DeleteListAsync(string conditions, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return await _dbConnection.DeleteListAsync<T>(conditions, parameters, transaction, commandTimeout);
        }
        private bool disposedValue = false; // 要检测冗余调用
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。

                disposedValue = true;
            }
        }
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }

        public T Get(TKey id)
        {
            return _dbConnection.Get<T>(id);
        }

        public async Task<T> GetAsync(TKey id)
        {
            return await _dbConnection.GetAsync<T>(id);
        }

        public IEnumerable<T> GetList()
        {
            return _dbConnection.GetList<T>();
        }

        public IEnumerable<T> GetList(object whereConditions)
        {
            return _dbConnection.GetList<T>(whereConditions);
        }

        public IEnumerable<T> GetList(string conditions, object parameters = null)
        {
            return _dbConnection.GetList<T>(conditions, parameters);
        }

        public async Task<IEnumerable<T>> GetListAsync()
        {
            return await _dbConnection.GetListAsync<T>();
        }

        public async Task<IEnumerable<T>> GetListAsync(object whereConditions)
        {
            return await _dbConnection.GetListAsync<T>(whereConditions);
        }

        public async Task<IEnumerable<T>> GetListAsync(string conditions, object parameters = null)
        {
            return await _dbConnection.GetListAsync<T>(conditions, parameters);
        }

        public IEnumerable<T> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby, object parameters = null)
        {
            return _dbConnection.GetListPaged<T>(pageNumber, rowsPerPage, conditions, orderby, parameters);
        }

        public Task<IEnumerable<T>> GetListPagedAsync(int pageNumber, int rowsPerPage, string conditions, string orderby, object parameters = null)
        {
            return _dbConnection.GetListPagedAsync<T>(pageNumber, rowsPerPage, conditions, orderby, parameters);
        }

        public int? Insert(T entity)
        {
            return _dbConnection.Insert<T>(entity);
        }

        public async Task<int?> InsertAsync(T entity)
        {
            return await _dbConnection.InsertAsync<T>(entity);
        }

        public int RecordCount(string conditions = "", object parameters = null)
        {
            return _dbConnection.RecordCount<T>(conditions, parameters);
        }

        public async Task<int> RecordCountAsync(string conditions = "", object parameters = null)
        {
            return await _dbConnection.RecordCountAsync<T>(conditions, parameters);
        }

        public int Update(T entity)
        {
            return _dbConnection.Update<T>(entity);
        }

        public async Task<int> UpdateAsync(T entity)
        {
            return await _dbConnection.UpdateAsync<T>(entity);
        }
    }
}
