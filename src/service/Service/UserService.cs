using System;
using System.Threading.Tasks;
using cashflow.domain.DTO;
using cashflow.infrastructure.common;
using cashflow.domain.Interface.Service;
using cashflow.infrastructure.security;

namespace cashflow.service
{
    public class UserService : BaseAppService, IUserService
    {
        private IJwtAuthManagerService _jwtAuthManagerService;
        public UserService(IJwtAuthManagerService jwtAuthManagerService)
        {
            _jwtAuthManagerService = jwtAuthManagerService;
        }

        public async Task<Result<UserDTO>> Authenticate(string email, string password)
        {
            var user = new UserDTO()
            {
                Id = Guid.NewGuid().ToString(),
                Email = email,
                Password = string.Empty,
                Token = await _jwtAuthManagerService.GetTokenAsync(email, "user")
            };

            return Result.Ok<UserDTO>(200, "User successfully authenticated", user);
        }
    }
}