using ErrorOr;

namespace DocumentSigningSolution.Domain.Common.DomainErrors;
public static partial class Errors
{
    public static class Template
    {
        public static Error InvalidTemplateId => Error.Validation(
            code: "Template.InvalidId",
            description: "Template ID is invalid");

        public static Error NotFound => Error.NotFound(
            code: "Template.NotFound",
            description: "Template with given ID does not exist");
    }
}