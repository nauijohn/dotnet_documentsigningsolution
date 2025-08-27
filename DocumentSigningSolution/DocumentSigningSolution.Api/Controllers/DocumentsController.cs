using System.Text.Json;

using DocumentSigningSolution.Api.Controllers.Common;
using DocumentSigningSolution.Api.Controllers.Utilities.Extensions;

namespace DocumentSigningSolution.Api.Controllers;

[Route("[controller]")]
public class DocumentsController(ISender _mediator) : ApiController
{
    
    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateDocumentRequest request)
    {
        var command = request.Adapt<CreateDocumentCommand>();
        var response = await _mediator.Send(command);
        return response.Match(
            document => Ok(document.Adapt<DocumentResponse>()),
            Problem);
    }
    
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetDocumentsRequest request)
    {
        var query = request.Adapt<GetDocumentsQuery>();
        var response = await _mediator.Send(query);
        return response.Match(
            documents => Ok(documents.Adapt<DocumentResponse[]>()),
            Problem);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var query = id.Adapt<GetDocumentByIdQuery>();
        var response = await _mediator.Send(query);
        return response.Match(
            document => Ok(document.Adapt<DocumentResponse>()),
            Problem);
    }
    
    [HttpGet("download/{id}")]
    public async Task<IActionResult> DownloadById(string id)
    {
        var query = id.Adapt<DownloadDocumentByIdQuery>();
        var response = await _mediator.Send(query);
        return response.Match(
            stream =>
            {
                stream.Position = 0;
                var fileName = $"{id}.pdf"; // Or get from metadata
                return File(stream, "application/pdf", fileName);
            },
            Problem);
    }
    
    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(string id)
    {
        var request = await Request.ParseUpdateDocumentRequestAsync();
        var command = (request, id).Adapt<UpdateDocumentCommand>();
        var response = await _mediator.Send(command);
        return response.Match(
            document => Ok(document.Adapt<DocumentResponse>()),
            Problem);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var command = id.Adapt<DeleteDocumentCommand>();
        var response = await _mediator.Send(command);
        return response.Match(
            document => Ok(document.Adapt<DocumentResponse>()),
            Problem);
    }
}
