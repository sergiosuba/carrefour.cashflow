using System.Threading.Tasks;
using System.Collections.Generic;
using cashflow.domain.Entity;

namespace cashflow.domain.Interface.Repository
{
    public interface IUserRepository
    {
        Task<User> GetByEmail(string email);
    }
}
