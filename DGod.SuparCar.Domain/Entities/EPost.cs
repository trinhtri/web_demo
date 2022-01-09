using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DGod.SuparCar.Domain.Abstracts;

namespace DGod.SuparCar.Domain.Entities;

public class EPost: AuditableEntity
{
    [Column(TypeName = "ntext")]
    public string PostContent { get; set; }
    public string PostTitle { get; set; }
    public string PostExcerpt { get; set; }
    [MaxLength(20)]
    public string PostType { get; set; }

    [MaxLength(20)]
    public string PostStatus { get; set; }

    [MaxLength(200)]
    public string PostName { get; set; }

    [ForeignKey("Parent")]
    public long? PostParentId { get; set; }

    public virtual EPost Parent { get; set; }
}