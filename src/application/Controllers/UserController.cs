using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using cashflow.infrastructure.common;
using cashflow.infrastructure.security;
using cashflow.domain.Interface.Service;
using Swashbuckle.AspNetCore.Annotations;
using cashflow.domain.DTO;

namespace cashflow.application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtAuthManagerService _jwtAuthManagerService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService,
                              IJwtAuthManagerService jwtAuthManagerService,
                              ILogger<UserController> logger)
        {
            _userService = userService;
            _jwtAuthManagerService = jwtAuthManagerService;
            _logger = logger;
        }

        [HttpPost(nameof(Authenticate))]
        [SwaggerOperation(nameof(Authenticate))]
        [AllowAnonymous]
        public async Task<Result<UserDTO>> Authenticate(string email, string password)
        {
            _logger.LogInformation($"Executed -> Authenticate");

            return await _userService.Authenticate(email, password);
        }
    }
}