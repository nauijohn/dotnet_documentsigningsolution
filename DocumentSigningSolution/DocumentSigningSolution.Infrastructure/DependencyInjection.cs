using DocumentSigningSolution.Application.Common.Interfaces.Persistence.Generics;
using DocumentSigningSolution.Infrastructure.Persistence.Repositories.Generics;

using Microsoft.AspNetCore.Identity;

namespace DocumentSigningSolution.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services
            .AddServices()
            .AddAuth(configuration)
            .AddPersistence(configuration)
            .AddBlobStorage(configuration);
        
        return services;
    }
    
    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        
        return services;
    }

    private static IServiceCollection AddPersistence(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddIdentity<IdentityUser, IdentityRole>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 8;
            options.User.RequireUniqueEmail = true;
        }).AddEntityFrameworkStores<DocumentSigningSolutionDbContext>();
        
        services.AddDbContext<DocumentSigningSolutionDbContext>(options =>
            options.UseSqlServer(connectionString));
        
        services.AddScoped(typeof(IRepository<,,>), typeof(Repository<,,>));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IDocumentRepository, DocumentRepository>();
        services.AddScoped<IFolderRepository, FolderRepository>();
        services.AddScoped<ITemplateRepository, TemplateRepository>();
        
        return services;
    }

    private static IServiceCollection AddBlobStorage(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        var blobStorageOptions = new BlobStorageOptions();
        configuration.Bind(BlobStorageOptions.SectionName, blobStorageOptions);

        services.AddSingleton(Options.Create(blobStorageOptions));
        services.AddSingleton(serviceProvider => new BlobServiceClient(blobStorageOptions.DefaultConnection));

        services.AddScoped<IDocumentStorage, DocumentStorage>();
        services.AddScoped<ITemplateStorage, TemplateStorage>();
        
        return services;
    }

    private static IServiceCollection AddAuth(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secret)),
            });

        return services;
    }
}
