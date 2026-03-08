using DocumentSigningSolution.Domain.TemplateAggregate;

namespace DocumentSigningSolution.Application.Templates.Queries.GetTemplates;

public class GetTemplatesQueryHandler(ITemplateRepository _templateRepository)
    : IRequestHandler<GetTemplatesQuery, ErrorOr<List<Template>>>
{
    public async Task<ErrorOr<List<Template>>> Handle(GetTemplatesQuery request, CancellationToken cancellationToken)
    {
        var folder = await _templateRepository.GetAllAsync();
        return folder.ToList();
    }
}