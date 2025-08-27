using Microsoft.AspNetCore.Http;

namespace DocumentSigningSolution.Contracts.Templates;

public record UpdateTemplateRequest(
    string? Name, 
    string? Description, 
    string? Version,
    IFormFile? File);