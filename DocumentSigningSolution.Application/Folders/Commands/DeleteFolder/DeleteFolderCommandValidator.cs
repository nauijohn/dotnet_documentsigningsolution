namespace DocumentSigningSolution.Application.Folders.Commands.DeleteFolder;

public class DeleteFolderCommandValidator : AbstractValidator<DeleteFolderCommand>
{
    public DeleteFolderCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}

