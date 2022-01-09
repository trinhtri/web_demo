using System.ComponentModel.DataAnnotations;
using DGod.SuparCar.Domain.Abstracts;

namespace DGod.SuparCar.Domain.Entities
{
    public class ETerm: BaseEntity
    {
        [MaxLength(200)]
        public string Name { get; set; }
        
        [MaxLength(200)]
        public string Slug { get; set; }

        public long TermGroup { get; set; }
    }
}
