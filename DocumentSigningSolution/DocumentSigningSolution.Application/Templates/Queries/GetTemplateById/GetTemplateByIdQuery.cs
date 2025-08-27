using DocumentSigningSolution.Domain.TemplateAggregate;

namespace DocumentSigningSolution.Application.Templates.Queries.GetTemplateById;

public record GetTemplateByIdQuery(string Id) : IRequest<ErrorOr<Template>>;