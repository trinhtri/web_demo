namespace DGod.SuparCar.Domain.Interfaces;

internal interface IAuditableBaseEntity : IBaseEntity
{
    string CreatedBy { get; set; }

    DateTime CreatedOn { get; set; }

    DateTime CreatedOnGmt { get; set; }
    
    string LastModifiedBy { get; set; }
    
    DateTime? LastModifiedOn { get; set; }
    
    DateTime LastModifiedOnGmt { get; set; }
    
    
}