using Ardalis.Specification;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using SusWarriors.Core.Interfaces;
using SusWarriors.Core.Interfaces.Data;

namespace SusWarriors.Infrastructure.Data;

public class CachedRepository<T> : IReadRepository<T> where T : class, IAggregateRoot
{
  private readonly IMemoryCache _cache;
  private readonly ILogger<CachedRepository<T>> _logger;
  private readonly IRepository<T> _sourceRepository;
  private readonly MemoryCacheEntryOptions _cacheOptions;

  private const string CheckingCacheFor = "Checking cache for {key}";
  private const string FetchingSourceDataFor = "Fetching source data for {key}";

  public CachedRepository(IMemoryCache cache,
      ILogger<CachedRepository<T>> logger,
      IRepository<T> sourceRepository)
  {
    _cache = cache;
    _logger = logger;
    _sourceRepository = sourceRepository;

    _cacheOptions = new MemoryCacheEntryOptions()
        .SetAbsoluteExpiration(relative: TimeSpan.FromSeconds(10));
  }

  public Task<T> AddAsync(T entity)
  {
    return _sourceRepository.AddAsync(entity);
  }

  public async Task<int> CountAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
  {
    if (!specification.CacheEnabled) 
      return await _sourceRepository.CountAsync(specification, cancellationToken);
    string key = $"{specification.CacheKey}-CountAsync";
    _logger.LogInformation(CheckingCacheFor, key);
    return await _cache.GetOrCreateAsync(key, async entry =>
    {
      entry.SetOptions(_cacheOptions);
      _logger.LogWarning(FetchingSourceDataFor, key);
      return await _sourceRepository.CountAsync(specification, cancellationToken);
    });
  }

  public async Task<int> CountAsync(CancellationToken cancellationToken = default)
  {
    string key = $"{nameof(T)}-CountAsync";
    return await _cache.GetOrCreateAsync(key, async entry =>
    {
      entry.SetOptions(_cacheOptions);
      _logger.LogWarning(FetchingSourceDataFor, key);
      return await _sourceRepository.CountAsync(cancellationToken);
    });
  }

  public async Task<bool> AnyAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
  {
    if (!specification.CacheEnabled)
      return await _sourceRepository.AnyAsync(specification, cancellationToken);
    string key = $"{specification.CacheKey}-AnyAsync";
    _logger.LogInformation(CheckingCacheFor, key);
    return await _cache.GetOrCreateAsync(key, async entry =>
    {
      entry.SetOptions(_cacheOptions);
      _logger.LogWarning(FetchingSourceDataFor, key);
      return await _sourceRepository.AnyAsync(specification, cancellationToken);
    });
  }

  public async Task<bool> AnyAsync(CancellationToken cancellationToken = new CancellationToken())
  {
    string key = $"{nameof(T)}-AnyAsync";
    return await _cache.GetOrCreateAsync(key, async entry =>
    {
      entry.SetOptions(_cacheOptions);
      _logger.LogWarning(FetchingSourceDataFor, key);
      return await _sourceRepository.AnyAsync(cancellationToken);
    });
  }

  public IAsyncEnumerable<T> AsAsyncEnumerable(ISpecification<T> specification)
  {
    return _sourceRepository.AsAsyncEnumerable(specification);
  }

  public Task DeleteAsync(T entity)
  {
    return _sourceRepository.DeleteAsync(entity);
  }

  public Task DeleteRangeAsync(IEnumerable<T> entities)
  {
    return _sourceRepository.DeleteRangeAsync(entities);
  }

  public Task<T> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default)
  {
    string key = $"{typeof(T).Name}-{id}";
    _logger.LogInformation("Checking cache for " + key);
    return _cache.GetOrCreate(key, entry =>
    {
      entry.SetOptions(_cacheOptions);
      _logger.LogWarning("Fetching source data for " + key);
      return _sourceRepository.GetByIdAsync(id, cancellationToken);
    });
  }

  [Obsolete]
  public async Task<T?> GetBySpecAsync(ISpecification<T> specification, CancellationToken cancellationToken = new CancellationToken())
  {
    string key = $"{nameof(T)}-GetBySpecAsync";
    return await _cache.GetOrCreateAsync(key, async entry =>
    {
      entry.SetOptions(_cacheOptions);
      _logger.LogWarning(FetchingSourceDataFor, key);
      return await _sourceRepository.GetBySpecAsync(specification, cancellationToken);
    });
  }

  public Task<T> GetBySpecAsync<Spec>(Spec specification,
    CancellationToken cancellationToken = default) where Spec : ISingleResultSpecification, ISpecification<T>
  {
    if (specification.CacheEnabled)
    {
      string key = $"{specification.CacheKey}-GetBySpecAsync";
      _logger.LogInformation("Checking cache for " + key);
      return _cache.GetOrCreate(key, entry =>
      {
        entry.SetOptions(_cacheOptions);
        _logger.LogWarning("Fetching source data for " + key);
        return _sourceRepository.GetBySpecAsync(specification, cancellationToken);
      });
    }
    return _sourceRepository.GetBySpecAsync(specification);
  }

  [Obsolete]
  public Task<TResult> GetBySpecAsync<TResult>(ISpecification<T, TResult> specification,
    CancellationToken cancellationToken = default)
  {
    if (specification.CacheEnabled)
    {
      string key = $"{specification.CacheKey}-GetBySpecAsync";
      _logger.LogInformation("Checking cache for " + key);
      return _cache.GetOrCreate(key, entry =>
      {
        entry.SetOptions(_cacheOptions);
        _logger.LogWarning("Fetching source data for " + key);
        return _sourceRepository.GetBySpecAsync(specification, cancellationToken);
      });
    }
    return _sourceRepository.GetBySpecAsync(specification, cancellationToken);
  }

  public async Task<T?> FirstOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken = new CancellationToken())
  {
    if (!specification.CacheEnabled)
      return await _sourceRepository.FirstOrDefaultAsync(specification, cancellationToken);
    string key = $"{specification.CacheKey}-FirstOrDefaultAsync";
    _logger.LogInformation(CheckingCacheFor, key);
    return await _cache.GetOrCreateAsync(key, async entry =>
    {
      entry.SetOptions(_cacheOptions);
      _logger.LogWarning(FetchingSourceDataFor, key);
      return await _sourceRepository.FirstOrDefaultAsync(specification, cancellationToken);
    });
  }

  public async Task<TResult?> FirstOrDefaultAsync<TResult>(ISpecification<T, TResult> specification,
    CancellationToken cancellationToken = default)
  {
    if (!specification.CacheEnabled)
      return await _sourceRepository.FirstOrDefaultAsync(specification, cancellationToken);
    string key = $"{specification.CacheKey}-FirstOrDefaultAsync";
    _logger.LogInformation(CheckingCacheFor, key);
    return await _cache.GetOrCreateAsync(key, async entry =>
    {
      entry.SetOptions(_cacheOptions);
      _logger.LogWarning(FetchingSourceDataFor, key);
      return await _sourceRepository.FirstOrDefaultAsync(specification, cancellationToken);
    });
  }

  public async Task<T?> SingleOrDefaultAsync(ISingleResultSpecification<T> specification,
    CancellationToken cancellationToken = default)
  {
    if (!specification.CacheEnabled)
      return await _sourceRepository.FirstOrDefaultAsync(specification, cancellationToken);
    string key = $"{specification.CacheKey}-FirstOrDefaultAsync";
    _logger.LogInformation(CheckingCacheFor, key);
    return await _cache.GetOrCreateAsync(key, async entry =>
    {
      entry.SetOptions(_cacheOptions);
      _logger.LogWarning(FetchingSourceDataFor, key);
      return await _sourceRepository.FirstOrDefaultAsync(specification, cancellationToken);
    });
  }

  public async Task<TResult?> SingleOrDefaultAsync<TResult>(ISingleResultSpecification<T, TResult> specification,
    CancellationToken cancellationToken = default)
  {
    if (!specification.CacheEnabled)
      return await _sourceRepository.FirstOrDefaultAsync(specification, cancellationToken);
    string key = $"{specification.CacheKey}-FirstOrDefaultAsync";
    _logger.LogInformation(CheckingCacheFor, key);
    return await _cache.GetOrCreateAsync(key, async entry =>
    {
      entry.SetOptions(_cacheOptions);
      _logger.LogWarning(FetchingSourceDataFor, key);
      return await _sourceRepository.FirstOrDefaultAsync(specification, cancellationToken);
    });
  }

  public Task<List<T>> ListAsync(CancellationToken cancellationToken = default)
  {
    string key = $"{typeof(T).Name}-List";
    _logger.LogInformation($"Checking cache for {key}");
    return _cache.GetOrCreate(key, entry =>
    {
      entry.SetOptions(_cacheOptions);
      _logger.LogWarning($"Fetching source data for {key}");
      return _sourceRepository.ListAsync(cancellationToken);
    });
  }

  public Task<List<T>> ListAsync(ISpecification<T> specification,
    CancellationToken cancellationToken = default)
  {
    if (specification.CacheEnabled)
    {
      string key = $"{specification.CacheKey}-ListAsync";
      _logger.LogInformation($"Checking cache for {key}");
      return _cache.GetOrCreate(key, entry =>
      {
        entry.SetOptions(_cacheOptions);
        _logger.LogWarning($"Fetching source data for {key}");
        return _sourceRepository.ListAsync(specification, cancellationToken);
      });
    }
    return _sourceRepository.ListAsync(specification, cancellationToken);
  }

  public Task<List<TResult>> ListAsync<TResult>(ISpecification<T, TResult> specification,
    CancellationToken cancellationToken = default)
  {
    if (specification.CacheEnabled)
    {
      string key = $"{specification.CacheKey}-ListAsync";
      _logger.LogInformation($"Checking cache for {key}");
      return _cache.GetOrCreate(key, entry =>
      {
        entry.SetOptions(_cacheOptions);
        _logger.LogWarning($"Fetching source data for {key}");
        return _sourceRepository.ListAsync(specification, cancellationToken);
      });
    }
    return _sourceRepository.ListAsync(specification, cancellationToken);
  }

  public Task SaveChangesAsync()
  {
    return _sourceRepository.SaveChangesAsync();
  }

  public Task UpdateAsync(T entity)
  {
    return _sourceRepository.UpdateAsync(entity);
  }
}
