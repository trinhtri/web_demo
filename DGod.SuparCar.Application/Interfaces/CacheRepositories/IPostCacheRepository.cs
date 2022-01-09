using DGod.SuparCar.Domain.Entities;

namespace DGod.SuparCar.Application.Interfaces.CacheRepositories;

public interface IPostCacheRepository
{
    Task<EPost> GetByIdAsync(long brandId);
}