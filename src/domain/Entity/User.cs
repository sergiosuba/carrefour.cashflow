using System;

namespace cashflow.domain.Entity
{
    public class User
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string description { get; set; }
        public DateTime creationDate { get; set; }
    }
}