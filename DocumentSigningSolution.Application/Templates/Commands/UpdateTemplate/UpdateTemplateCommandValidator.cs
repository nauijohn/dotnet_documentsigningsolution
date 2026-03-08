namespace DocumentSigningSolution.Application.Templates.Commands.UpdateTemplate;

public class UpdateTemplateCommandValidator : AbstractValidator<UpdateTemplateCommand>
{
    public UpdateTemplateCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
        RuleFor(x => x.Name);
        RuleFor(x => x.Description);
        RuleFor(x => x.Version);
    }
}