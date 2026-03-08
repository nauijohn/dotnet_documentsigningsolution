using DocumentSigningSolution.Infrastructure.Storage;

namespace DocumentSigningSolution.Application.Documents.Queries.DownloadDocumentById;

public class DownloadDocumentByIdQueryHandler(IDocumentStorage _documentStorage)
    : IRequestHandler<DownloadDocumentByIdQuery, ErrorOr<Stream>>
{
    public async Task<ErrorOr<Stream>> Handle(DownloadDocumentByIdQuery request, CancellationToken cancellationToken)
    {
        return await _documentStorage.GetByIdAsync(request.Id);
    }
}
