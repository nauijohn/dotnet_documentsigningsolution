namespace DocumentSigningSolution.Infrastructure.Storage;

public class TemplateStorage(BlobServiceClient _blobServiceClient, IOptions<BlobStorageOptions> _options) 
    : Base.Storage(_blobServiceClient, _options.Value.TemplateContainerName), ITemplateStorage
{
    
}
