using Ardalis.SmartEnum;

namespace DocumentSigningSolution.Domain.DocumentAggregate.Enums;
public class DocumentStatus(string name, int value) : SmartEnum<DocumentStatus>(name, value)
{
    public static readonly DocumentStatus None = new(nameof(None), 0);
    public static readonly DocumentStatus Draft = new(nameof(Draft), 1);
    public static readonly DocumentStatus Signed = new(nameof(Signed), 2);
    public static readonly DocumentStatus Sent = new(nameof(Sent), 3);
    public static readonly DocumentStatus Completed = new(nameof(Completed), 4);
    public static readonly DocumentStatus Cancelled = new(nameof(Cancelled), 5);
}
