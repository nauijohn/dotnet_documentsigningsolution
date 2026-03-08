using DocumentSigningSolution.Domain.TemplateAggregate;
using DocumentSigningSolution.Domain.TemplateAggregate.ValueObjects;

namespace DocumentSigningSolution.Application.Templates.Commands.UpdateTemplate;

public class UpdateTemplateCommandHandler(
    ITemplateRepository _templateRepository,
    ITemplateStorage _templateStorage)
    : IRequestHandler<UpdateTemplateCommand, ErrorOr<Template>>
{
    public async Task<ErrorOr<Template>> Handle(UpdateTemplateCommand request, CancellationToken cancellationToken)
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

        var updatedTemplate = request.Adapt<Template>();
        var newTemplate = Template.Update(template, updatedTemplate);
        
        await _templateRepository.UpdateAsync(newTemplate);
        if (request?.File is not null)
        {
            await _templateStorage.UpdateAsync(template.Id.Value.ToString(), request.File);
        }
        
        return newTemplate;
    }
}
