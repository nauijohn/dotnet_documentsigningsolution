using DocumentSigningSolution.Application.Folders.Commands.UpdateFolder;
using DocumentSigningSolution.Domain.FolderAggregate;
using DocumentSigningSolution.Domain.FolderAggregate.ValueObjects;

namespace DocumentSigningSolution.Application.Common.Mapping;

public class FolderMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UpdateFolderCommand, Folder>()
            .MapWith(src => Folder.Create(
                FolderId.Create(src.Id).Value,
                src.Path));
    }
}