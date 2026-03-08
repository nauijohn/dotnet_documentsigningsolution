using DocumentSigningSolution.Domain.TemplateAggregate;

namespace DocumentSigningSolution.Application.Templates.Queries.GetTemplates;

public record GetTemplatesQuery() : IRequest<ErrorOr<List<Template>>>;