using DocumentSigningSolution.Domain.FolderAggregate;
using DocumentSigningSolution.Domain.FolderAggregate.ValueObjects;

namespace DocumentSigningSolution.Infrastructure.Persistence.Configurations;

public class FolderConfigurations : IEntityTypeConfiguration<Folder>
{
    public void Configure(EntityTypeBuilder<Folder> builder)
    {
        ConfigureFoldersTable(builder);
    }
    
    private static void ConfigureFoldersTable(EntityTypeBuilder<Folder> builder)
    {
        builder.ToTable("Folders");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => FolderId.Create(value));

        builder.Property(d => d.Path)
            .HasMaxLength(200);
        
        builder.HasIndex(d => d.Path)
            .IsUnique();

        builder.Property(d => d.CreatedAt);
        builder.Property(d => d.UpdatedAt);
    }
    
    private static void ConfigureAggregateRelationships(EntityTypeBuilder<Folder> builder)
    {
        builder.HasMany(d => d.Documents)
            .WithOne(t => t.Folder)
            .HasPrincipalKey(t => t.Id) // Explicitly match key
            .OnDelete(DeleteBehavior.Restrict); // or .SetNull / .Cascade
    }
}