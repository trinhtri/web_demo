using System.ComponentModel.DataAnnotations.Schema;
using DGod.SuparCar.Domain.Abstracts;

namespace DGod.SuparCar.Domain.Entities;

public class ETermRelationship: BaseEntity
{
    [ForeignKey("Post")]
    public long PostId { get; set; }
    [ForeignKey("TermTaxonomy")]
    public long TermTaxonomyId { get; set; }
    public virtual EPost Post { get; set; }
    public virtual ETermTaxonomy TermTaxonomy { get; set; }
}