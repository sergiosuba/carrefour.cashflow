using System.IO;
using Microsoft.Extensions.Configuration;

namespace cashflow.infrastructure.repository
{
    public abstract class BaseRepository
    {
        protected string ConnectionString()
        {
            var config = new ConfigurationBuilder()
                             .SetBasePath(Directory.GetCurrentDirectory())
                             .AddJsonFile("appsettings.json")
                             .Build();
#if DEBUG
            {
                return config["profile:dev.connectionString"];
            }
#else
            {
                return config["profile:prod.connectionString"];
            }
#endif
        }
    }
}
