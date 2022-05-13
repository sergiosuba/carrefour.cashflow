using System;
namespace cashflow.infrastructure.security
{
    public static class Settings
    {
        public static string Secret = "JIOBLi6eVjBpvGtWBgJzjWd2QH0sOn5tI8rIFXSHKijXWEt/3J2jFYL79DQ1vKu+EtTYgYkwTluFRDdtF41yAQ==";

        public static string TokenType = "Bearer";

        public static int TokenExpirationTime = 480;

        public static int ExpirationCache = 60;
    }
}
