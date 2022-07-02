using AutoMapper;
using Business.IServices;
using Business.Models;
using Business.Servises.IServices;
using Meetup_API.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace Meetup_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RegisterAsync([FromBody] AuthRequest registerRequest)
        {
            var registerModel = _mapper.Map<AuthRequest, AuthModel>(registerRequest);
            await _authService.RegisterUserAsync(registerModel);

            return Ok();
        }

        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> LoginAsync([FromBody] AuthRequest loginRequest)
        {
            var loginModel = _mapper.Map<AuthRequest, AuthModel>(loginRequest);
            var loginSuccessModel = await _authService.LoginAsync(loginModel);

            return Ok(loginSuccessModel);
        }
    }
}
