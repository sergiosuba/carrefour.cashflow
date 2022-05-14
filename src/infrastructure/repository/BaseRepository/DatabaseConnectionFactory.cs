using System;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.IO;
using MySqlConnector;

namespace cashflow.infrastructure.repository
{
    public class DatabaseConnectionFactory : BaseRepository, IDatabaseConnectionFactory
    {
        public IDbConnection GetConnection()
        {
            var config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();

            IDbConnection connection;

            switch (config["profile:db.type"])
            {
                case "mysql":
                    connection = new MySqlConnection(ConnectionString());
                    break;

                default:
                    connection = new MySqlConnection(ConnectionString());
                    break;
            };

            return connection;
        }


    }
}