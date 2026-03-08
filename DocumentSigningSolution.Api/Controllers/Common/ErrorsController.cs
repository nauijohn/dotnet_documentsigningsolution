namespace DocumentSigningSolution.Api.Controllers.Common;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult HandleError()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        return Problem(detail: exception?.InnerException?.Message);
    }
}
