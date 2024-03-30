﻿namespace Infrastructure
{
    public interface IDbSettingsResolved
    {
        /// <summary>
        /// 連線類型
        /// </summary>
        DBProvider ConnectionType { get; }

        /// <summary>
        /// 連線字串
        /// </summary>
        string ConnectionString { get; }
    }
}
