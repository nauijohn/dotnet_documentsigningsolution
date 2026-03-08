namespace DocumentSigningSolution.Infrastructure.Storage;

public class DocumentStorage(BlobServiceClient _blobServiceClient, IOptions<BlobStorageOptions> _options) 
    : Base.Storage(_blobServiceClient, _options.Value.DocumentContainerName), IDocumentStorage
{

}
