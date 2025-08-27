using Microsoft.AspNetCore.Http;

namespace DocumentSigningSolution.Contracts.Documents;
public record UpdateDocumentRequest(
    string? Name,
    string? Path,
    string? Status,
    IFormFile? File,
    string? TemplateId,
    string? FolderId
    );