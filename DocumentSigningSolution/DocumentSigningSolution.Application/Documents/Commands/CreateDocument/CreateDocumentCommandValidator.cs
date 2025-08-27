namespace DocumentSigningSolution.Application.Documents.Commands.CreateDocument;
public class CreateDocumentCommandValidator : AbstractValidator<CreateDocumentCommand>
{
    public CreateDocumentCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(100);
        RuleFor(x => x.FilePath)
            .NotEmpty();
    }
}

