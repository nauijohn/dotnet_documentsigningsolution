namespace DocumentSigningSolution.Application.Folders.Commands.CreateFolder;

public class CreateFolderCommandValidator : AbstractValidator<CreateFolderCommand>
{
    public CreateFolderCommandValidator()
    {
        RuleFor(x => x.Path)
            .NotEmpty()
            .MaximumLength(100);
    }
}