using System.Data;
using static Dapper.SqlMapper;

namespace Dao.Utils
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected IDbTransaction Transaction { get; }

        protected int Timeout { get; }

        protected IDbConnection Connection => Transaction.Connection;

        public GenericRepository(IDbTransaction transaction)
        {
            Transaction = transaction;
            Timeout = 1800; //Timeout 預設3分鐘
        }

        public abstract TEntity Get(TEntity entity);

        public abstract IEnumerable<TEntity> GetAll();

        public abstract int Add(TEntity entity);

        public abstract int AddRange(IEnumerable<TEntity> entities);

        public abstract int Update(TEntity entity);

        public abstract int UpdateRange(IEnumerable<TEntity> entities);

        public abstract int Remove(TEntity entity);

        public abstract int RemoveRange(IEnumerable<TEntity> entities);

        protected virtual IEnumerable<T> Query<T>(string command, object? param = null)
        {
            try
            {                
                var result = Connection.Query<T>(command, param, Transaction);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected virtual T QueryFirstOrDefault<T>(string command, object? param = null)
        {
            try
            {
                var result = Connection.QueryFirstOrDefault<T>(command, param, Transaction);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        protected virtual int Execute(string command, object? param = null)
        {
            try
            {
                var result = Connection.Execute(command, param, Transaction);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
