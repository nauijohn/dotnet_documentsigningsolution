namespace DocumentSigningSolution.Application.Folders.Queries.GetFolderById;

public class GetFolderByIdQueryValidator : AbstractValidator<GetFolderByIdQuery>
{
    public GetFolderByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}