using DocumentSigningSolution.Application.Templates.Commands.CreateTemplate;
using DocumentSigningSolution.Application.Templates.Commands.DeleteTemplate;
using DocumentSigningSolution.Application.Templates.Commands.UpdateTemplate;
using DocumentSigningSolution.Application.Templates.Queries.GetTemplateById;
using DocumentSigningSolution.Application.Templates.Queries.GetTemplates;
using DocumentSigningSolution.Contracts.Templates;

namespace DocumentSigningSolution.Api.Common.Mapping;

public class TemplateMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateTemplateRequest, CreateTemplateCommand>()
            .MapWith(src => new CreateTemplateCommand(
                src.Name,
                src.Description,
                src.Version,
                src.File.OpenReadStream()));
        
        config.NewConfig<GetTemplatesRequest, GetTemplatesQuery>()
            .MapWith(src => new GetTemplatesQuery());
        
        config.NewConfig<string, GetTemplateByIdQuery>()
            .MapWith(src => new GetTemplateByIdQuery(src));
        
        config.NewConfig<(UpdateTemplateRequest Request, string Id), UpdateTemplateCommand>()
            .MapWith(src => new UpdateTemplateCommand(
                src.Id,
                src.Request.Name!,
                src.Request.Description!,
                src.Request.Version!,
                src.Request.File != null ? src.Request.File.OpenReadStream() : null!));
        
        config.NewConfig<string, DeleteTemplateCommand>()
            .MapWith(src => new DeleteTemplateCommand(src));
    }
}