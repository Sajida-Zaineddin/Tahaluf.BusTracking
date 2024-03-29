﻿using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Tahaluf.BusTracking.Core.Common;

namespace Tahaluf.BusTracking.Infra.Common
{
   public class DbContext : IDbContext
    {
        private DbConnection _connection;
        private readonly IConfiguration _configuration;

        // constructor
        public DbContext(IConfiguration configuration)
        {
            //this._configuration = _configuration;
            _configuration = configuration;
        }
        public DbConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new OracleConnection(_configuration["ConnectionStrings:DBConnectionString"]);
                    _connection.Open();
                }
                else if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                return _connection;
            }
        }

    }
}
