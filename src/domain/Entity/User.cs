using System;

namespace cashflow.domain.Entity
{
    public class User
    {
        string id { get; set; }
        string name { get; set; }
        string email { get; set; }
        string password { get; set; }
        string description { get; set; }
        DateTime creationDate { get; set; }
    }
}