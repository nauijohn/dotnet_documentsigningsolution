using DocumentSigningSolution.Domain.ApplicationUser;
using DocumentSigningSolution.Domain.FolderAggregate;
using DocumentSigningSolution.Domain.TemplateAggregate;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DocumentSigningSolution.Infrastructure.Persistence;
public class DocumentSigningSolutionDbContext(
    DbContextOptions<DocumentSigningSolutionDbContext> options)
    : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>(options)
{
    public DbSet<Document> Documents { get; set; } = null!;
    public DbSet<Folder> Folders { get; set; } = null!;
    public DbSet<Template> Templates { get; set; } = null!;
    public DbSet<User> DomainUsers { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(DocumentSigningSolutionDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
