using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DGod.SuparCar.Domain.Abstracts;

namespace DGod.SuparCar.Domain.Entities;

public class ETermTaxonomy: BaseEntity
{
    [ForeignKey("Term")]
    public long TermId { get; set; }

    [MaxLength(32)]
    public string Taxonomy { get; set; }

    [Column(TypeName = "ntext")]
    public string Description { get; set; }

    [ForeignKey("Parent")]
    public long? ParentId { get; set; }
    
    public long Count { get; set; }

    public virtual ETerm Term { get; set; }
    public virtual ETermTaxonomy Parent { get; set; }
}