﻿using System.Data.Common;
using System.Data.SqlClient;

namespace ElencoMagazzinoWebApp.Services
{
    public class SqlServerServiceBase
    {
        private SqlConnection _connection;

        public SqlServerServiceBase(IConfiguration config)
        {
            _connection = new SqlConnection(config.GetConnectionString("ServerSpedizioni"));
        }
        protected DbCommand GetCommand(string commandText)
        {
            return new SqlCommand(commandText, _connection);
        }

        protected DbConnection GetConnection()
        {
            return _connection;
        }
    }
}
