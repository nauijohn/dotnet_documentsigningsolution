using DocumentSigningSolution.Domain.TemplateAggregate;
using DocumentSigningSolution.Domain.TemplateAggregate.ValueObjects;

namespace DocumentSigningSolution.Infrastructure.Persistence.Configurations;
public class TemplateConfigurations : IEntityTypeConfiguration<Template>
{
    public void Configure(EntityTypeBuilder<Template> builder)
    {
        ConfigureTemplatesTable(builder);
        ConfigureAggregateRelationships(builder);
    }

    private static void ConfigureTemplatesTable(EntityTypeBuilder<Template> builder)
    {
        builder.ToTable("Templates");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => TemplateId.Create(value));

        builder.Property(d => d.Name)
            .HasMaxLength(100);

        builder.Property(d => d.Description)
            .HasMaxLength(200);

        builder.Property(d => d.Version)
            .HasMaxLength(50);

        builder.Property(d => d.CreatedAt);
        builder.Property(d => d.UpdatedAt);

        builder.HasIndex(d => new { d.Name, d.Version }).IsUnique();
    }

    private static void ConfigureAggregateRelationships(EntityTypeBuilder<Template> builder)
    {
        builder.HasMany(d => d.Documents)
            .WithOne(t => t.Template)
            .HasPrincipalKey(t => t.Id) // Explicitly match key
            .OnDelete(DeleteBehavior.Restrict); // or .SetNull / .Cascade
    }
}
