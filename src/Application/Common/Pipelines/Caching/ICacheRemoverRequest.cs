namespace Application.Common.Pipelines.Caching;

public interface ICacheRemoverRequest
{
    string? CacheKey { get; }
    string? CacheGroupKey { get; }
    bool Bypass { get; }
}
