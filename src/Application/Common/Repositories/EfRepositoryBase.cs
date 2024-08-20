using Application.Common.Pagination;
using Application.Common.Repositories.Abstractions;
using Domain.Common;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Application.Common.Repositories;


public class EfRepositoryBase<TEntity, TContext>(TContext Context) : IAsyncRepository<TEntity>
where TEntity : BaseAuditableEntity
where TContext : DbContext
{
    public async Task<TEntity> AddAsync(TEntity entity)
    {
        entity.CreatedDate = DateTime.UtcNow;

        await Context.AddAsync(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? predicate = null, bool enableTracking = false, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Query();

        if (!enableTracking)
            queryable = queryable.AsNoTracking();
        if (predicate != null)
            queryable = queryable.Where(predicate);

        return await queryable.AnyAsync(cancellationToken);
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        Context.Remove(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        entity.LastModifiedDate = DateTime.UtcNow;

        Context.Update(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool enableTracking = false, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Query();

        if (!enableTracking)
            queryable = queryable.AsNoTracking();
        if (include != null)
            queryable = include(queryable);

        return await queryable.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<Paginate<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int index = 0, int size = 10, bool enableTracking = false, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Query();

        if (!enableTracking)
            queryable = queryable.AsNoTracking();
        if (include != null)
            queryable = include(queryable);
        if (predicate != null)
            queryable = queryable.Where(predicate);
        if (orderBy != null)
            return await orderBy(queryable).ToPaginateAsync(index, size, cancellationToken);

        return await queryable.ToPaginateAsync(index, size, cancellationToken);
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool enableTracking = false, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Query();

        if (!enableTracking)
            queryable = queryable.AsNoTracking();
        if (include != null)
            queryable = include(queryable);
        if (predicate != null)
            queryable = queryable.Where(predicate);
        if (orderBy != null)
            queryable = orderBy(queryable);

        return await queryable.ToListAsync(cancellationToken);
    }

    public IQueryable<TEntity> Query() => Context.Set<TEntity>();

}
