using DocumentSigningSolution.Domain.FolderAggregate;
using DocumentSigningSolution.Domain.TemplateAggregate;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DocumentSigningSolution.Infrastructure.Persistence;
public class DocumentSigningSolutionDbContext(
    DbContextOptions<DocumentSigningSolutionDbContext> options)
    : IdentityDbContext(options)
{
    public DbSet<Document> Documents { get; set; } = null!;
    public DbSet<Folder> Folders { get; set; } = null!;
    public DbSet<Template> Templates { get; set; } = null!;
    // public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(DocumentSigningSolutionDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
