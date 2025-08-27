using DocumentSigningSolution.Domain.TemplateAggregate;

namespace DocumentSigningSolution.Application.Templates.Commands.UpdateTemplate;

public record UpdateTemplateCommand(
    string Id, 
    string Name, 
    string Description, 
    string Version,
    Stream File) : IRequest<ErrorOr<Template>>;