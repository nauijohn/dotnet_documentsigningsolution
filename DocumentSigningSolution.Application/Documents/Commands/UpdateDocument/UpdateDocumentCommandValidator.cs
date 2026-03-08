namespace DocumentSigningSolution.Application.Documents.Commands.UpdateDocument;
public class UpdateDocumentCommandValidator : AbstractValidator<UpdateDocumentCommand>
{
    public UpdateDocumentCommandValidator()
    {
        RuleFor(x => x.DocumentId)
            .NotEmpty();
    }
}

