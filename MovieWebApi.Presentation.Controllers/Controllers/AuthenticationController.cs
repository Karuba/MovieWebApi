
using AutoMapper;
using LoggerService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieWebApi.Contracts.Dto;
using MovieWebApi.Domain.Core.Entities;
using MovieWebApi.Services.Interfaces.Authentication;

namespace MovieWebApi.Presentation.Controllers.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationManager _authManager;

        public AuthenticationController(ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IAuthenticationManager authManager)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _authManager = authManager;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(UserRegistrationDto userRegistration)
        {
            var user = _mapper.Map<User>(userRegistration);
            var result = await _userManager.CreateAsync(user, userRegistration.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            await _userManager.AddToRolesAsync(user, new List<string>() { "User" });
            return StatusCode(201);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserAuthenticationDto user)
        {
            if (!await _authManager.ValidateUser(user))
            {
                string warn = $"{nameof(Authenticate)}: Authentication failed. Wrong user name or password.";
                _logger.LogWarn(warn);
                return Unauthorized(warn);
            }
            var userEntity = await _authManager.GetUserAsync(user.UserName);
            var userDto = _mapper.Map<UserDto>(userEntity);
            userDto.Roles = await _userManager.GetRolesAsync(userEntity);
            return Ok(new { Token = await _authManager.CreateToken(), User = userDto });
        }
    }
}
