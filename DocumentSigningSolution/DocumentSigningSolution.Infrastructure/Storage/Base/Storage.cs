using DocumentSigningSolution.Application.Common.Interfaces.Storage.Base;

namespace DocumentSigningSolution.Infrastructure.Storage.Base;

public class Storage(BlobServiceClient _blobServiceClient, string _containerName) : IStorage
{
    private readonly BlobContainerClient _containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
    
    public async Task<Stream> GetByIdAsync(string id)
    {
        var blobClient = _containerClient.GetBlobClient(id);
        if (!await blobClient.ExistsAsync())
        {
            throw new FileNotFoundException($"The file '{id}' was not found in blob storage.");
        }
        
        var memoryStream = new MemoryStream();
        await blobClient.DownloadToAsync(memoryStream);
        memoryStream.Position = 0;
        return memoryStream;
    }

    public async Task CreateAsync(string id, Stream stream)
    {
        await _containerClient.CreateIfNotExistsAsync();
        await _containerClient.UploadBlobAsync(id, stream);
    }

    public async Task DeleteByIdAsync(string id)
    {
        var blobClient = _containerClient.GetBlobClient(id);
        await blobClient.DeleteIfExistsAsync();
    }
    
    public async Task UpdateAsync(string blobName, Stream newContent)
    {
        var blobClient = _containerClient.GetBlobClient(blobName);
        await blobClient.UploadAsync(newContent, overwrite: true);
    }
}