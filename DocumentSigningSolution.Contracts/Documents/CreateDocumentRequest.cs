using Microsoft.AspNetCore.Http;

namespace DocumentSigningSolution.Contracts.Documents;
public record CreateDocumentRequest(
    string Name,
    string Path,
    IFormFile File,
    string TemplateId,
    string FolderId);