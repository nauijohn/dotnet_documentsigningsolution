namespace DocumentSigningSolution.Domain.Common.Utilities;

public static class GuardUtils
{
    public static Boolean IsChangedAndNotEmpty(string? original, string? updated)
    {
        return !string.IsNullOrEmpty(updated) && updated != original;
    }
}