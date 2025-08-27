using ErrorOr;

namespace DocumentSigningSolution.Domain.Common.DomainErrors;
public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Validation(
            code: "Auth.InvalidCredentials",
            description: "Invalid credentials.");
    }
}
