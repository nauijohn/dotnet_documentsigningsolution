namespace DocumentSigningSolution.Application.Templates.Commands.DeleteTemplate;

public class DeleteTemplateCommandValidator : AbstractValidator<DeleteTemplateCommand>
{
    public DeleteTemplateCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}