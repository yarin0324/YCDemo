﻿using Microsoft.Extensions.Options;

namespace Infrastructure
{
    public class DbSettingsBridge : IDbSettingsResolved
    {
        private readonly IOptions<DbSettings> _dbSettings;

        public DbSettingsBridge(IOptionsSnapshot<DbSettings> dbSettings)
        {
            _dbSettings = dbSettings ?? throw new ArgumentNullException(nameof(dbSettings));
        }

        public DbProvider ConnectionType => _dbSettings.Value.ConnectionType.ConvertFromString<DbProvider>();

        public string ConnectionString => _dbSettings.Value.ConnectionStrings[_dbSettings.Value.ConnectionType];
    }
}
