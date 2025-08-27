namespace DocumentSigningSolution.Application.Documents.Queries.DownloadDocumentById;
public class DownloadDocumentByIdQueryValidator : AbstractValidator<DownloadDocumentByIdQuery>
{
    public DownloadDocumentByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}

