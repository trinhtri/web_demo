using DGod.SuparCar.Domain.Entities;

namespace DGod.SuparCar.Application.Interfaces.Repositories;

public interface IPostRepository
{
    IQueryable<EPost> Posts { get; }

    Task<List<EPost>> GetListAsync();

    Task<EPost> GetByIdAsync(long postId);

    Task<long> InsertAsync(EPost post);

    Task UpdateAsync(EPost post);

    Task DeleteAsync(EPost post);
}