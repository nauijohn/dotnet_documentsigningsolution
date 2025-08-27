using DocumentSigningSolution.Domain.Common.DomainErrors;
using DocumentSigningSolution.Domain.Common.Models.Identities;

using ErrorOr;

namespace DocumentSigningSolution.Domain.DocumentAggregate.ValueObjects;
public sealed class DocumentId : AggregateRootId<Guid>
{
    private DocumentId(Guid value) : base(value)
    {
    }

    public static DocumentId CreateUnique()
    {
        return new DocumentId(Guid.NewGuid());
    }

    public static DocumentId Create(Guid value)
    {
        return new DocumentId(value);
    }

    public static ErrorOr<DocumentId> Create(string value)
    {
        if (!Guid.TryParse(value, out var guid))
        {
            return Errors.Document.InvalidDocumentId;
        }

        return new DocumentId(guid);
    }
}