using DocumentSigningSolution.Application.Templates.Commands.UpdateTemplate;
using DocumentSigningSolution.Domain.TemplateAggregate;
using DocumentSigningSolution.Domain.TemplateAggregate.ValueObjects;

namespace DocumentSigningSolution.Application.Common.Mapping;

public class TemplateMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UpdateTemplateCommand, Template>()
            .MapWith(src => Template.Create(
                TemplateId.Create(src.Id).Value,
                src.Name!,
                src.Description!,
                src.Version!));
    }
}