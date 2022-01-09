using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DGod.SuparCar.Domain.Abstracts;

namespace DGod.SuparCar.Domain.Entities
{
    public class EOption: BaseEntity
    {   
        [MaxLength(191)]
        public string OptionName { get; set; }
        [Column(TypeName = "ntext")]
        public string OptionValue { get; set; }
    }
}