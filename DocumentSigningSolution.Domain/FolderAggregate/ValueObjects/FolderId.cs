using DocumentSigningSolution.Domain.Common.DomainErrors;
using DocumentSigningSolution.Domain.Common.Models.Identities;

using ErrorOr;

namespace DocumentSigningSolution.Domain.FolderAggregate.ValueObjects;

public sealed class FolderId : AggregateRootId<Guid>
{
    private FolderId(Guid value) : base(value)
    {
    }

    public static FolderId CreateUnique()
    {
        return new FolderId(Guid.NewGuid());
    }

    public static FolderId Create(Guid value)
    {
        return new FolderId(value);
    }

    public static ErrorOr<FolderId> Create(string value)
    {
        if (!Guid.TryParse(value, out var guid))
        {
            return Errors.Folder.InvalidId;
        }

        return new FolderId(guid);
    }
}