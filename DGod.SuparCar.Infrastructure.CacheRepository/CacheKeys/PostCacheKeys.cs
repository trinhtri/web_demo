namespace DGod.SuparCar.Infrastructure.CacheRepository.CacheKeys;

public static class PostCacheKeys
{
    public static string GetKey(long postId) => $"Post-{postId}";
    public static string ListKey => "PostList";
    public static string GetListKey(string name) => $"Posts-{name}";
}