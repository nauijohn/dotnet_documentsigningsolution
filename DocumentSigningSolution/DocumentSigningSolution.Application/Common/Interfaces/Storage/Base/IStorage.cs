using DocumentSigningSolution.Domain.Common.Models;
using DocumentSigningSolution.Domain.Common.Models.Identities;

namespace DocumentSigningSolution.Application.Common.Interfaces.Storage.Base;
public interface IStorage
{
    Task CreateAsync(string id, Stream stream);
    Task UpdateAsync(string id, Stream stream);
    Task<Stream> GetByIdAsync(string id);
    Task DeleteByIdAsync(string id);
}
