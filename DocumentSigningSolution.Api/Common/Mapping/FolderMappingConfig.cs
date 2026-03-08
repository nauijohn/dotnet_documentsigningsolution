namespace DocumentSigningSolution.Api.Common.Mapping;

public class FolderMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateFolderRequest, CreateFolderCommand>();

        config.NewConfig<GetFoldersRequest, GetFoldersQuery>()
            .MapWith(src => new GetFoldersQuery());

        config.NewConfig<string, GetFolderByIdQuery>()
            .MapWith(src => new GetFolderByIdQuery(src));

        config.NewConfig<(UpdateFolderRequest Request, string Id), UpdateFolderCommand>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<string, DeleteFolderCommand>()
            .MapWith(src => new DeleteFolderCommand(src));

        config.NewConfig<Folder, FolderResponse>()
            .Map(dest => dest.Id, src => src.Id.Value.ToString());
    }
}