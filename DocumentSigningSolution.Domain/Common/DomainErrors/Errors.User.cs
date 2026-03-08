using ErrorOr;

namespace DocumentSigningSolution.Domain.Common.DomainErrors;
public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(
            code: "User.DuplicateEmail",
            description: "User with this email already exists.");
    }
}
