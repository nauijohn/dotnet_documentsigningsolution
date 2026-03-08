using Mapster;

using MapsterMapper;

using Microsoft.Extensions.DependencyInjection;

namespace DocumentSigningSolution.Shared.Mappings;
public static class DependencyInjection
{
    public static IServiceCollection AddMappings(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(AppDomain.CurrentDomain.GetAssemblies());

        services.AddSingleton(config);
        services.AddSingleton<IMapper, ServiceMapper>();

        return services;
    }
}
