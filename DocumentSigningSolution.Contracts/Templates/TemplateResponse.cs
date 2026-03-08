namespace DocumentSigningSolution.Contracts.Templates;

public record TemplateResponse(
    string Id,
    string Name,
    string Description,
    string Version,
    DateTime CreatedAt,
    DateTime UpdatedAt);