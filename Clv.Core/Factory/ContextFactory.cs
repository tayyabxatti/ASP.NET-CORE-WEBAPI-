﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Clv.Core.EFContext;
using Clv.Models.Configuration;
using System;
using System.Data.SqlClient;

namespace Clv.Core.Factory
{
    /// <summary>
    /// context factory for ef
    /// </summary>
    public class ContextFactory : IContextFactory
    {
        private readonly IOptions<ConnectionSettings> _connectionOptions;

        public ContextFactory(IOptions<ConnectionSettings> connectionOptions)
        {
            _connectionOptions = connectionOptions;
        }

        public IDatabaseContext DbContext => new DatabaseContext(GetDataContext().Options);

        private DbContextOptionsBuilder<DatabaseContext> GetDataContext()
        {
            ValidateDefaultConnection();

            var sqlConnectionBuilder = new SqlConnectionStringBuilder(_connectionOptions.Value.DefaultConnection);

            var contextOptionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();

            contextOptionsBuilder.UseSqlServer(sqlConnectionBuilder.ConnectionString);

            return contextOptionsBuilder;
        }

        private void ValidateDefaultConnection()
        {
            if (string.IsNullOrEmpty(_connectionOptions.Value.DefaultConnection))
            {
                throw new ArgumentNullException(nameof(_connectionOptions.Value.DefaultConnection));
            }
        }
    }
}