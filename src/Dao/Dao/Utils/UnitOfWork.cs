using Infrastructure;
using System.Collections;
using System.Data;
using System.Reflection;

namespace Dao.Utils
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Properties

        private IDbConnection? _connection;
        private IDbTransaction? _transaction;
        private Hashtable? _repositories;

        #endregion

        #region Constructor

        public UnitOfWork(IConnectionFactory connectionFactory)
        {
            _connection = connectionFactory.GetConnection();
            _connection.Open();

            // 開始交易
            _transaction = _connection.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        #endregion

        /// <summary>
        /// 儲存變更
        /// </summary>
        public void SaveChanges()
        {
            try
            {
                //SaveSqlLogs();
                _transaction?.Commit();
            }
            catch
            {
                _transaction?.Rollback();
                throw;
            }
            finally
            {
                _transaction?.Dispose();
                _transaction = _connection?.BeginTransaction(IsolationLevel.ReadCommitted);
                ResetRepositories();
            }
        }

        /// <summary>
        /// 放棄變更
        /// </summary>
        public void AbortChanges()
        {
            _transaction?.Rollback();
            _transaction?.Dispose();
            _transaction = _connection?.BeginTransaction(IsolationLevel.ReadCommitted);
            ResetRepositories();
        }

        /// <summary>
        /// 重置資源池
        /// </summary>
        private void ResetRepositories()
        {
            _repositories = null;
        }

        /// <summary>
        /// 取得Repository
        /// </summary>
        public TRepository Get<TRepository>()
        {
            _repositories ??= new Hashtable();

            var assembly = Assembly.GetExecutingAssembly();

            var repositoryName = typeof(TRepository).Name.Remove(0, 1);

            var namespaceList = (typeof(TRepository).Namespace?.Split('.') ?? Array.Empty<string>()).Reverse().ToArray();

            var prefixRepositoryName = $"{namespaceList.FirstOrDefault()}.{typeof(TRepository).Name.Remove(0, 1)}";

            var type = assembly.ExportedTypes
                .Aggregate(new List<(Type, int)>(), (total, now) =>
                {
                    if (!now.Name.Equals(repositoryName))
                    {
                        return total;
                    }

                    var nowNamespaceList = (now.Namespace?.Split('.') ?? Array.Empty<string>()).Reverse().ToArray();

                    var matchIndex = 0;

                    while (namespaceList.Length > matchIndex && nowNamespaceList.Length > matchIndex &&
                           namespaceList[matchIndex] == nowNamespaceList[matchIndex])
                    {
                        matchIndex++;
                    }

                    total.Add((now, matchIndex));
                    return total;
                }).MaxBy(data => data.Item2)
                .Item1;

            if (!_repositories.ContainsKey(prefixRepositoryName))
            {
                var repositoryInstance =
                    Activator.CreateInstance(type, _transaction);

                _repositories.Add(prefixRepositoryName, repositoryInstance);
            }

            var respiratory = (TRepository)_repositories[prefixRepositoryName]!;

            return respiratory;
        }

        private bool disposedValue = false; // 偵測多餘的呼叫

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // 釋放交易資源
                    _transaction?.Dispose();
                    _transaction = null;

                    // 釋放連線資源
                    _connection?.Dispose();
                    _connection = null;
                }

                disposedValue = true;
            }
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}