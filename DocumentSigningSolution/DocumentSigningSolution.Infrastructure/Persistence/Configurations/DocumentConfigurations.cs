using DocumentSigningSolution.Domain.TemplateAggregate.ValueObjects;

namespace DocumentSigningSolution.Infrastructure.Persistence.Configurations;
public class DocumentConfigurations : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        ConfigureDocumentsTable(builder);
        ConfigureAggregateRelationships(builder);
    }

    private static void ConfigureDocumentsTable(EntityTypeBuilder<Document> builder)
    {
        builder.ToTable("Documents");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => DocumentId.Create(value));

        builder.Property(d => d.Name)
            .HasMaxLength(100);

        builder.Property(d => d.Path)
            .HasMaxLength(200);

        builder.Property(d => d.Status)
            .HasConversion(
                status => status.Value,
                name => DocumentStatus.FromValue(name));

        builder.Property(d => d.CreatedAt);
        builder.Property(d => d.UpdatedAt);
        
        builder.HasIndex(d => new { d.Name, d.FolderId }).IsUnique();
    }
    
    private static void ConfigureAggregateRelationships(EntityTypeBuilder<Document> builder)
    {
        builder.HasOne(d => d.Template)
            .WithMany(t => t.Documents)
            .HasForeignKey(d => d.TemplateId)
            .HasPrincipalKey(t => t.Id)
            .OnDelete(DeleteBehavior.Restrict); // or .SetNull / .Cascade
        
        builder.HasOne(d => d.Folder)
            .WithMany(f => f.Documents)
            .HasForeignKey(d => d.FolderId)
            .HasPrincipalKey(t => t.Id)
            .OnDelete(DeleteBehavior.Restrict); // or .SetNull / .Cascade
    }
}
