namespace DocumentSigningSolution.Contracts.Documents;
public record DocumentResponse(
    string Id,
    string Name,
    string Path,
    string Status,
    DateTime CreatedAt,
    DateTime UpdatedAt);