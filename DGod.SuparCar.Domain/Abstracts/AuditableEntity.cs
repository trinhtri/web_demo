using DGod.SuparCar.Domain.Interfaces;

namespace DGod.SuparCar.Domain.Abstracts;

public abstract class AuditableEntity : IAuditableBaseEntity
{
    public long Id { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }
    
    public DateTime CreatedOnGmt { get; set; }

    public string LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }
    
    public DateTime LastModifiedOnGmt { get; set; }
}