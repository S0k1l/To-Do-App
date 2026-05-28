using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Application.Features.Auth.Commands.LoginUser;
using ToDoApi.Application.Features.Auth.Commands.RegisterUser;

namespace ToDoApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            try
            {
                var token = await _mediator.Send(command);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var token = await _mediator.Send(command);
            if (token == null)
            {
                return BadRequest("Wrong email or password.");
            }

            return Ok(new { Token = token });
        }
    }
}
