using DocumentSigningSolution.Domain.Common.Models;
using DocumentSigningSolution.Domain.Common.Utilities;
using DocumentSigningSolution.Domain.DocumentAggregate;
using DocumentSigningSolution.Domain.TemplateAggregate.ValueObjects;

namespace DocumentSigningSolution.Domain.TemplateAggregate;

public sealed class Template : AggregateRoot<TemplateId, Guid>
{
    
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Version { get; private set; }
    public ICollection<Document> Documents { get; private set; } = [];
    public DateTime CreatedAt { get; private init; }
    public DateTime UpdatedAt { get; private set; }

    private Template(
        TemplateId documentTemplateId,
        string name,
        string description,
        string version) : base(documentTemplateId)
    {
        Name = name;
        Description = description;
        Version = version;
    }
    
    public static Template Create(
        TemplateId id,
        string name,
        string description,
        string version)
    {
        return new Template(
            id,
            name,
            description,
            version);
    }

    public static Template Create(
        string name,
        string description,
        string version)
    {
        return new Template(
            TemplateId.CreateUnique(),
            name,
            description,
            version)
        {
            CreatedAt = DateTime.Now, 
            UpdatedAt = DateTime.Now,
        };
    }
    
    public static Template Update(
        Template original,
        Template updates)
    {
        if (GuardUtils.IsChangedAndNotEmpty(original.Name, updates.Name))
        {
            original.Name = updates.Name;
        }
        
        if (GuardUtils.IsChangedAndNotEmpty(original.Description, updates.Description))
        {
            original.Description = updates.Description;
        }
        
        if (GuardUtils.IsChangedAndNotEmpty(original.Version, updates.Version))
        {
            original.Version = updates.Version;
        }
        
        original.UpdatedAt = DateTime.Now;
        return original;
    }

#pragma warning disable CS8618
    private Template()
    {
    }
#pragma warning restore CS8618
}
