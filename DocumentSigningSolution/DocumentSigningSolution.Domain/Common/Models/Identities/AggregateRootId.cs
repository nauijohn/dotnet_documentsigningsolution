namespace DocumentSigningSolution.Domain.Common.Models.Identities;
public abstract class AggregateRootId<TId>(TId value) : EntityId<TId>(value)
{
}
