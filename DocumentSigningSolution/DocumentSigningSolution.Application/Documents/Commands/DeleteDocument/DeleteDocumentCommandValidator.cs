namespace DocumentSigningSolution.Application.Documents.Commands.DeleteDocument;
public class DeleteDocumentCommandValidator : AbstractValidator<DeleteDocumentCommand>
{
    public DeleteDocumentCommandValidator()
    {
        RuleFor(x => x.DocumentId)
            .NotEmpty();
    }
}

