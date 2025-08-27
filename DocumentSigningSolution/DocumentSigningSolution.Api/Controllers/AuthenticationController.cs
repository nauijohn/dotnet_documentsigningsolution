using DocumentSigningSolution.Api.Controllers.Common;

namespace DocumentSigningSolution.Api.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthenticationController(ISender _mediator) : ApiController
{

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = request.Adapt<RegisterCommand>();
        var response = await _mediator.Send(command);
        return response.Match(
            auth => Ok(auth.Adapt<AuthenticationResponse>()),
            Problem);

    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = request.Adapt<LoginQuery>();
        var response = await _mediator.Send(query);
        return response.Match(
            auth => Ok(auth.Adapt<AuthenticationResponse>()),
            Problem);
    }
}
