using AutoMapper;
using Business.IServices;
using Business.Models;
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
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest registerRequest)
        {
            var registerModel = _mapper.Map<RegisterRequest, RegisterModel>(registerRequest);
            await _authService.RegisterUserAsync(registerModel);

            return Ok();
        }
    }
}
