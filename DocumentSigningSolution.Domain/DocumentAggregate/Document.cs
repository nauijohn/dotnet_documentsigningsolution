using DocumentSigningSolution.Domain.Common.Models;
using DocumentSigningSolution.Domain.Common.Models.Identities;
using DocumentSigningSolution.Domain.Common.Utilities;
using DocumentSigningSolution.Domain.DocumentAggregate.Enums;
using DocumentSigningSolution.Domain.DocumentAggregate.ValueObjects;
using DocumentSigningSolution.Domain.FolderAggregate;
using DocumentSigningSolution.Domain.FolderAggregate.ValueObjects;
using DocumentSigningSolution.Domain.TemplateAggregate;
using DocumentSigningSolution.Domain.TemplateAggregate.ValueObjects;

namespace DocumentSigningSolution.Domain.DocumentAggregate;
public sealed class Document : AggregateRoot<DocumentId, Guid>
{
    public string Name { get; private set; }
    public string Path { get; private set; }
    public DocumentStatus Status { get; private set; }
    public AggregateRootId<Guid> TemplateId { get; private set; } = null!;
    public Template Template { get; private set; } = null!;
    public AggregateRootId<Guid> FolderId { get; private set; } = null!;
    public Folder Folder { get; private set; } = null!;
    public DateTime CreatedAt { get; private init; }
    public DateTime UpdatedAt { get; private set; }

    private Document(
        DocumentId documentId,
        string name,
        string path,
        DocumentStatus status) : base(documentId)
    {
        Name = name;
        Path = path;
        Status = status;
    }

    public static Document Create(
        DocumentId documentId,
        string name,
        string path,
        DocumentStatus status)
    {
        return new Document(documentId, name, path, status);
    }

    public static Document Create(
        string name,
        string path,
        DocumentStatus status)
    {
        return new Document(DocumentId.CreateUnique(), name, path, status)
        {
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        };
    }
    
    public static Document Create(
        string name,
        string path,
        DocumentStatus status,
        TemplateId templateId,
        FolderId folderId)
    {
        return new Document(DocumentId.CreateUnique(), name, path, status)
        {
            TemplateId = templateId,
            FolderId = folderId,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        };
    }

    public static Document Update(
        Document original,
        Document updates)
    {
        if (GuardUtils.IsChangedAndNotEmpty(original.Name, updates.Name))
        {
            original.Name = updates.Name;
        }
        
        if (GuardUtils.IsChangedAndNotEmpty(original.Path, updates.Path))
        {
            original.Path = updates.Path;
        }
        
        if (GuardUtils.IsChangedAndNotEmpty(original.Status.Name, updates.Status?.Name))
        {
            original.Status = updates.Status!;
        }
        
        original.UpdatedAt = DateTime.Now;
        return original;
    }

#pragma warning disable CS8618
    private Document()
    {
        // Required by EF
    }
#pragma warning restore CS8618

}