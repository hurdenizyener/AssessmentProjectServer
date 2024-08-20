namespace Application.Common.Pipelines.Caching;

public interface ICachableRequest
{
    string CacheKey { get; } // Cache Anahtarı
    string? CacheGroupKey { get; } //Cache Grup
    bool Bypass { get; } // Test çalışmaları gereği 
    TimeSpan? SlidingExpiration { get; } //Cache Ne Kadar Süre Duracak

}
