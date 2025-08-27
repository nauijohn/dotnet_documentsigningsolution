using DocumentSigningSolution.Domain.UserAggregate.ValueObjects;

namespace DocumentSigningSolution.Infrastructure.Persistence.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        ConfigureUsersTable(builder);
    }

    private static void ConfigureUsersTable(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value));

        builder.Property(d => d.FirstName)
            .HasMaxLength(100);

        builder.Property(d => d.LastName)
            .HasMaxLength(200);

        builder.Property(d => d.Email)
            .HasMaxLength(50);
        
        builder.Property(d => d.Password)
            .HasMaxLength(50);

        builder.Property(d => d.CreatedAt);
        builder.Property(d => d.UpdatedAt);

        builder.HasIndex(d => new { d.Email }).IsUnique();
    }
}