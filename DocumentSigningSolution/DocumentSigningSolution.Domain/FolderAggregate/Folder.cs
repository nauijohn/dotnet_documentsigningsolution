using DocumentSigningSolution.Domain.Common.Models;
using DocumentSigningSolution.Domain.Common.Utilities;
using DocumentSigningSolution.Domain.DocumentAggregate;
using DocumentSigningSolution.Domain.FolderAggregate.ValueObjects;

namespace DocumentSigningSolution.Domain.FolderAggregate;

public sealed class Folder : AggregateRoot<FolderId, Guid>
{
    public string Path { get; private set; }
    public ICollection<Document> Documents { get; private set; } = [];
    public DateTime CreatedAt { get; private init; }
    public DateTime UpdatedAt { get; private set; }

    private Folder(
        FolderId id,
        string path) : base(id)
    {
        Path = path;
    }

    public static Folder Create(
        FolderId id,
        string path)
    {
        return new Folder(id, path);
    }

    public static Folder Create(
        string path)
    {
        return new Folder(FolderId.CreateUnique(), path)
        {
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        };
    }

    public static Folder Update(
        Folder original,
        Folder updates)
    {
        if (GuardUtils.IsChangedAndNotEmpty(original.Path, updates.Path))
        {
            original.Path = updates.Path;
        }

        original.UpdatedAt = DateTime.Now;
        return original;
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Folder()
    {
        // Required by EF
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

}