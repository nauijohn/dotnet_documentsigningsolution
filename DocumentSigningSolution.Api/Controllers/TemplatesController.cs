using DocumentSigningSolution.Api.Controllers.Common;
using DocumentSigningSolution.Api.Controllers.Utilities.Extensions;
using DocumentSigningSolution.Application.Templates.Commands.CreateTemplate;
using DocumentSigningSolution.Application.Templates.Commands.DeleteTemplate;
using DocumentSigningSolution.Application.Templates.Commands.UpdateTemplate;
using DocumentSigningSolution.Application.Templates.Queries.GetTemplateById;
using DocumentSigningSolution.Application.Templates.Queries.GetTemplates;
using DocumentSigningSolution.Contracts.Templates;

namespace DocumentSigningSolution.Api.Controllers;

[Route("[controller]")]
public class TemplatesController(ISender _mediator) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateTemplateRequest request)
    {
        var command = request.Adapt<CreateTemplateCommand>();
        var response = await _mediator.Send(command);
        return response.Match(
            template => Ok(template.Adapt<TemplateResponse>()),
            Problem);
    }
    
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetTemplatesRequest request)
    {
        var query = request.Adapt<GetTemplatesQuery>();
        var response = await _mediator.Send(query);
        return response.Match(
            templates => Ok(templates.Adapt<TemplateResponse[]>()),
            Problem);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var query = id.Adapt<GetTemplateByIdQuery>();
        var response = await _mediator.Send(query);
        return response.Match(
            template => Ok(template.Adapt<TemplateResponse>()),
            Problem);
    }
    
    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(string id)
    {
        var request = await Request.ParseUpdateTemplateRequestAsync();
        var command = (request, id).Adapt<UpdateTemplateCommand>();
        var response = await _mediator.Send(command);
        return response.Match(
            folder => Ok(folder.Adapt<TemplateResponse>()),
            Problem);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var command = id.Adapt<DeleteTemplateCommand>();
        var response = await _mediator.Send(command);
        return response.Match(
            folder => Ok(folder.Adapt<TemplateResponse>()),
            Problem);
    }
}