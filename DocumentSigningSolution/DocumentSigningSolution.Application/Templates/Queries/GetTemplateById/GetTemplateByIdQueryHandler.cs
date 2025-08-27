using DocumentSigningSolution.Domain.TemplateAggregate;
using DocumentSigningSolution.Domain.TemplateAggregate.ValueObjects;

namespace DocumentSigningSolution.Application.Templates.Queries.GetTemplateById;

public class GetTemplateByIdQueryHandler(ITemplateRepository _templateRepository)
    : IRequestHandler<GetTemplateByIdQuery, ErrorOr<Template>>
{
    public async Task<ErrorOr<Template>> Handle(GetTemplateByIdQuery request, CancellationToken cancellationToken)
    {
        var id = TemplateId.Create(request.Id);
        if (id.IsError)
        {
            return id.Errors;
        }

        var template = await _templateRepository.GetByIdAsync(id.Value);
        if (template is null)
        {
            return Errors.Template.NotFound;
        }

        return template;
    }
}