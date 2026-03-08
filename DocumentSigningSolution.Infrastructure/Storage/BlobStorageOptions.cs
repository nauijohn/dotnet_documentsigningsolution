namespace DocumentSigningSolution.Infrastructure.Storage;
public class BlobStorageOptions
{
    public const string SectionName = "BlobStorageOptions";
    public string DefaultConnection { get; init; } = null!;
    public string TemplateContainerName { get; set; } = null!;
    public string DocumentContainerName { get; set; } = null!;
}
