using DocumentSigningSolution.Shared.Mappings;

using Microsoft.Extensions.DependencyInjection;

namespace DocumentSigningSolution.Shared;
public static class DependencyInjection
{
    public static IServiceCollection AddShared(this IServiceCollection services)
    {
        services.AddMappings();

        return services;
    }
}
