using Microsoft.AspNetCore.Http;

namespace DocumentSigningSolution.Contracts.Templates;

public record CreateTemplateRequest(
    string Name, 
    string Description, 
    string Version, 
    IFormFile File);