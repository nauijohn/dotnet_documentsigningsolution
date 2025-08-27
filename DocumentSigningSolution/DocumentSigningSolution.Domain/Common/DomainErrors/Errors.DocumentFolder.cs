using ErrorOr;

namespace DocumentSigningSolution.Domain.Common.DomainErrors;
public static partial class Errors
{
    public static class Folder
    {
        public static Error InvalidId => Error.Validation(
            code: "Folder.InvalidId",
            description: "Folder ID is invalid");

        public static Error NotFound => Error.NotFound(
            code: "Folder.NotFound",
            description: "Folder with given ID does not exist");
    }
}