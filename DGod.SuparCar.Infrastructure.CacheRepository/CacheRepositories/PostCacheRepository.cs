using DGod.SuparCar.Application.Interfaces.CacheRepositories;
using DGod.SuparCar.Application.Interfaces.Repositories;
using DGod.SuparCar.Domain.Entities;
using DGod.SuparCar.Infrastructure.CacheRepository.CacheKeys;
using AspNetCoreHero.Extensions.Caching;
using AspNetCoreHero.ThrowR;
using Microsoft.Extensions.Caching.Distributed;

namespace DGod.SuparCar.Infrastructure.CacheRepository.CacheRepositories;

public class PostCacheRepository: IPostCacheRepository
{
    private readonly IDistributedCache _distributedCache;
    private readonly IPostRepository _postRepository;
    public PostCacheRepository(IDistributedCache distributedCache, IPostRepository postRepository)
    {
        _distributedCache = distributedCache;
        _postRepository = postRepository;
    }
    public async Task<EPost> GetByIdAsync(long postId)
    {
        string cacheKey = PostCacheKeys.GetKey(postId);
        var post = await _distributedCache.GetAsync<EPost>(cacheKey);
        if (post == null)
        {
            post = await _postRepository.GetByIdAsync(postId);
            Throw.Exception.IfNull(post, "Post", "No Post Found");
            await _distributedCache.SetAsync(cacheKey, post);
        }
        return post;
    }

    public Task<List<EPost>> GetListByIdsAsync(long[] ids, string postType)
    {
        throw new NotImplementedException();
    }
}