using DocumentSigningSolution.Domain.TemplateAggregate;

namespace DocumentSigningSolution.Application.Templates.Commands.CreateTemplate;

public class CreateTemplateCommandHandler(
    ITemplateRepository _templateRepository,
    ITemplateStorage _templateStorage)
    : IRequestHandler<CreateTemplateCommand, ErrorOr<Template>>
{
    public async Task<ErrorOr<Template>> Handle(CreateTemplateCommand request, CancellationToken cancellationToken)
    {
        var template = Template.Create(request.Name, request.Description, request.Version);
        
        await Task.WhenAll(
            _templateRepository.CreateAsync(template),
            _templateStorage.CreateAsync(template.Id.Value.ToString(), request.File));
        
        return template;
    }
}
