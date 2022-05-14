using System;

namespace cashflow.domain.DTO
{
    public class UserDTO
    {
        string Id { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string Description { get; set; }
        DateTime CreationDate { get; set; }
    }
}