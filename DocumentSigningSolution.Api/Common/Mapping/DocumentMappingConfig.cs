using DocumentSigningSolution.Domain.DocumentAggregate.Enums;
using DocumentSigningSolution.Domain.DocumentAggregate.ValueObjects;

namespace DocumentSigningSolution.Api.Common.Mapping;
public class DocumentMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetDocumentsRequest, GetDocumentsQuery>()
            .MapWith(src => new GetDocumentsQuery());
        
        config.NewConfig<CreateDocumentRequest, CreateDocumentCommand>()
            .MapWith(src => 
                new CreateDocumentCommand(
                    src.Name, 
                    src.Path, 
                    src.File.OpenReadStream(), 
                    src.TemplateId, 
                    src.FolderId));

        config.NewConfig<(UpdateDocumentRequest Request, string DocumentId), UpdateDocumentCommand>()
            .MapWith(src => new UpdateDocumentCommand(
                src.DocumentId,
                src.Request.Name!,
                src.Request.Path!,
                src.Request.Status!,
                src.Request.File != null ? src.Request.File.OpenReadStream() : null!,
                src.Request.TemplateId!,
                src.Request.FolderId!
                ));
            
            // .Map(dest => dest.DocumentId, src => src.DocumentId)
            // .Map(dest => dest.Stream,
            //     src => src.Request.File != null ? src.Request.File.OpenReadStream() : null)
            // .Map(dest => dest.Name, src => src.Request.Name)
            // .Map(dest => dest.Path, src => src.Request.Path)
            // .Map(dest => dest.Status, src => src.Request.Status);
            // .Map(dest => dest, src => src.Request);

        config.NewConfig<string, DownloadDocumentByIdQuery>()
            .MapWith(src => new DownloadDocumentByIdQuery(src));

        config.NewConfig<string, DeleteDocumentCommand>()
            .MapWith(src => new DeleteDocumentCommand(src));

        config.NewConfig<string, GetDocumentByIdQuery>()
            .MapWith(src => new GetDocumentByIdQuery(src));

        config.NewConfig<Document, DocumentResponse>()
            .Map(dest => dest.Id, src => src.Id.Value.ToString());

        config.NewConfig<Document, DocumentResponse>();

    }
}
