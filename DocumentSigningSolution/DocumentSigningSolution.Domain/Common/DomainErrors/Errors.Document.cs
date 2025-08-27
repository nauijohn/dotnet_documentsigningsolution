using ErrorOr;

namespace DocumentSigningSolution.Domain.Common.DomainErrors;
public static partial class Errors
{
    public static class Document
    {
        public static Error InvalidDocumentId => Error.Validation(
            code: "Document.InvalidId",
            description: "Document ID is invalid");

        public static Error NotFound => Error.NotFound(
            code: "Document.NotFound",
            description: "Document with given ID does not exist");
    }
}