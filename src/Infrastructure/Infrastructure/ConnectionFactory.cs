using MiniProfiler.Integrations;
using Oracle.ManagedDataAccess.Client;
using Security;
using StackExchange.Profiling.Data;
using System.Data;
using System.Data.SqlClient;

namespace Infrastructure
{
    public class ConnectionFactory : IConnectionFactory
    {
        #region Properties

        private readonly IDbSettingsResolved _dbSetting;

        #endregion

        #region Constructor

        public ConnectionFactory(IDbSettingsResolved dbSettingsResolved)
        {
            _dbSetting = dbSettingsResolved;
        }

        #endregion

        /// <summary>
        /// 取得資料庫連線
        /// </summary>
        /// <returns></returns>
        public IDbConnection GetConnection()
        {
            return CreateConnection(_dbSetting.ConnectionType, _dbSetting.ConnectionString);
        }

        #region Private Method

        /// <summary>
        /// 建立資料庫連線
        /// </summary>
        /// <param name="dbProvider"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        private IDbConnection CreateConnection(DbProvider dbProvider, string connectionString)
        {
            IDbConnection connection = null;

            var connectionDecrypt = CryptoMemoryStream.Decrypt(connectionString);

            switch (dbProvider)
            {
                case DbProvider.Oracle:
                    connection = new OracleConnection(connectionDecrypt);
                    break;
                case DbProvider.MsSql:
                    connection = new ProfiledDbConnection(
                        new SqlConnection(connectionDecrypt), CustomDbProfiler.Current);
                    break;
                default:
                    break;
            }

            return connection;
        }

        #endregion
    }
}
