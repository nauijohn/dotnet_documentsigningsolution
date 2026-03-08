namespace DocumentSigningSolution.Application.Documents.Queries.GetDocumentById;
public class GetDocumentByIdQueryValidator : AbstractValidator<GetDocumentByIdQuery>
{
    public GetDocumentByIdQueryValidator()
    {
        RuleFor(x => x.DocumentId)
            .NotEmpty();
    }
}

