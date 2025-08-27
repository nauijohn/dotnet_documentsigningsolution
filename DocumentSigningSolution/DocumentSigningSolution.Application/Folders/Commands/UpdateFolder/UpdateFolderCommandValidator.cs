namespace DocumentSigningSolution.Application.Folders.Commands.UpdateFolder;

public class UpdateFolderCommandValidator : AbstractValidator<UpdateFolderCommand>
{
    public UpdateFolderCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}