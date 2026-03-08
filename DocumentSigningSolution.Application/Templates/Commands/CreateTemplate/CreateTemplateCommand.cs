using DocumentSigningSolution.Domain.TemplateAggregate;

namespace DocumentSigningSolution.Application.Templates.Commands.CreateTemplate;

public record CreateTemplateCommand(
    string Name, 
    string Description, 
    string Version,
    Stream File) : IRequest<ErrorOr<Template>>;