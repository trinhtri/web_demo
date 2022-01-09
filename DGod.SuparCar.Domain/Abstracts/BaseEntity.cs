using DGod.SuparCar.Domain.Interfaces;

namespace DGod.SuparCar.Domain.Abstracts;

public abstract class BaseEntity: IBaseEntity
{
    public long Id { get; set; }
}