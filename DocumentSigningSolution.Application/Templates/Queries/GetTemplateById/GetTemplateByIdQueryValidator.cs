namespace DocumentSigningSolution.Application.Templates.Queries.GetTemplateById;

public class GetTemplateByIdQueryValidator: AbstractValidator<GetTemplateByIdQuery>
{
    public GetTemplateByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}