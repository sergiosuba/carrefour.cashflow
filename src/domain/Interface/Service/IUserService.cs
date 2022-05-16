using System;
using System.Threading.Tasks;
using cashflow.domain.DTO;
using cashflow.infrastructure.common;

namespace cashflow.domain.Interface.Service
{
    public interface IUserService : IDisposable
    {
        Task<Result<UserDTO>> Authenticate(string email, string password);
    }
}
