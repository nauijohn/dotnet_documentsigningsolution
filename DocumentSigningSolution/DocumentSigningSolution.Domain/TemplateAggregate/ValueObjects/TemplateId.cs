using DocumentSigningSolution.Domain.Common.DomainErrors;
using DocumentSigningSolution.Domain.Common.Models.Identities;

using ErrorOr;

namespace DocumentSigningSolution.Domain.TemplateAggregate.ValueObjects;
public sealed class TemplateId : AggregateRootId<Guid>
{
    private TemplateId(Guid value) : base(value)
    {
    }

    public static TemplateId CreateUnique()
    {
        return new TemplateId(Guid.NewGuid());
    }

    public static TemplateId Create(Guid value)
    {
        return new TemplateId(value);
    }

    public static ErrorOr<TemplateId> Create(string value)
    {
        if (!Guid.TryParse(value, out var guid))
        {
            return Errors.Template.InvalidTemplateId;
        }

        return new TemplateId(guid);
    }

}
