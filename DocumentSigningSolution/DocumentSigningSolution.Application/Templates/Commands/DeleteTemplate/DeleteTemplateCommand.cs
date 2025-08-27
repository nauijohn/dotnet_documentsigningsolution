namespace DocumentSigningSolution.Application.Templates.Commands.DeleteTemplate;

public record DeleteTemplateCommand(string Id) : IRequest<ErrorOr<Unit>>;