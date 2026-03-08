using DocumentSigningSolution.Domain.TemplateAggregate.ValueObjects;

namespace DocumentSigningSolution.Application.Templates.Commands.DeleteTemplate;

public class DeleteTemplateCommandHandler(
    ITemplateRepository _templateRepository,
    ITemplateStorage _templateStorage)
    : IRequestHandler<DeleteTemplateCommand, ErrorOr<Unit>>
{
    public async Task<ErrorOr<Unit>> Handle(DeleteTemplateCommand request, CancellationToken cancellationToken)
    {
        var templateId = TemplateId.Create(request.Id);
        if (templateId.IsError)
        {
            return templateId.Errors;
        }

        var template = await _templateRepository.GetByIdAsync(templateId.Value);
        if (template is null)
        {
            return Errors.Template.NotFound;
        }
        
        await Task.WhenAll(
            _templateRepository.DeleteAsync(template),
            _templateStorage.DeleteByIdAsync(templateId.Value.Value.ToString())
        );
        
        return Unit.Value;
    }
}
