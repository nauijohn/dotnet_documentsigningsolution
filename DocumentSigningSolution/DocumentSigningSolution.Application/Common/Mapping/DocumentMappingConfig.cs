namespace DocumentSigningSolution.Application.Common.Mapping;
public class DocumentMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UpdateDocumentCommand, Document>()
            .MapWith(src => Document.Create(
                DocumentId.Create(src.DocumentId).Value,
                src.Name!,
                src.Path!,
                src.Status != null! ? DocumentStatus.FromName(src.Status, true) : null!));
    }
}
