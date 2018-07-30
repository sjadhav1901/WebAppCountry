using Microsoft.Extensions.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Db.Core.Utilites
{
    public interface IDataSettings
    {
        SqlDatabase TransactionalDatabase { get; }
        SqlDatabase ReadOnlyDatabase { get; }
    }

    public class DataSettings : IDataSettings
    {
        private readonly IConfiguration _configurationRoot;
        private SqlDatabase _database;

        public DataSettings(IConfiguration configurationRoot)
        {
            _configurationRoot = configurationRoot;
        }

        public string DatabaseConnectionString => _configurationRoot["ConnectionString"];
        public SqlDatabase TransactionalDatabase => _database ?? (_database = new SqlDatabase(DatabaseConnectionString));
        public SqlDatabase ReadOnlyDatabase => _database ?? (_database = new SqlDatabase(DatabaseConnectionString));
    }
}
