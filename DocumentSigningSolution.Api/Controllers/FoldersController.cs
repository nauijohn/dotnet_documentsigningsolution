using DocumentSigningSolution.Api.Controllers.Common;

namespace DocumentSigningSolution.Api.Controllers;

[Route("[controller]")]
public class FoldersController(ISender _mediator) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateFolderRequest request)
    {
        var command = request.Adapt<CreateFolderCommand>();
        var response = await _mediator.Send(command);
        return response.Match(
            folder => Ok(folder.Adapt<FolderResponse>()),
            Problem);
    }
    
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetFoldersRequest request)
    {
        var query = request.Adapt<GetFoldersQuery>();
        var response = await _mediator.Send(query);
        return response.Match(
            folders => Ok(folders.Adapt<FolderResponse[]>()),
            Problem);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var query = id.Adapt<GetFolderByIdQuery>();
        var response = await _mediator.Send(query);
        return response.Match(
            folder => Ok(folder.Adapt<FolderResponse>()),
            Problem);
    }
    
    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(UpdateFolderRequest request, string id)
    {
        var command = (request, id).Adapt<UpdateFolderCommand>();
        var response = await _mediator.Send(command);
        return response.Match(
            folder => Ok(folder.Adapt<FolderResponse>()),
            Problem);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var command = id.Adapt<DeleteFolderCommand>();
        var response = await _mediator.Send(command);
        return response.Match(
            folder => Ok(folder.Adapt<FolderResponse>()),
            Problem);
    }
}