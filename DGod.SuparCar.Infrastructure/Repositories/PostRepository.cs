using DGod.SuparCar.Application.Interfaces.Repositories;
using DGod.SuparCar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DGod.SuparCar.Infrastructure.Repositories;

public class PostRepository: IPostRepository
{
    private readonly IRepositoryAsync<EPost> _repository;
    public PostRepository( IRepositoryAsync<EPost> repository)
    {
        _repository = repository;
    }
    public IQueryable<EPost> Posts => _repository.Entities;
    public Task<List<EPost>> GetListAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<EPost> GetByIdAsync(long postId)
    {
        return await _repository.Entities.Where(p => p.Id == postId).FirstOrDefaultAsync();
    }

    public async Task<long> InsertAsync(EPost post)
    {
        await _repository.AddAsync(post);
        return post.Id;
    }

    public async Task UpdateAsync(EPost post)
    {
        await _repository.UpdateAsync(post);
    }

    public async Task DeleteAsync(EPost post)
    {
        await _repository.DeleteAsync(post);
    }
}