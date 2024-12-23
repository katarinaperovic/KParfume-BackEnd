﻿using KParfume.BuildingBlocks.Core.Domain;
using KParfume.BuildingBlocks.Core.UseCases;
using Microsoft.EntityFrameworkCore;

namespace KParfume.BuildingBlocks.Infrastructure.Database;

public class CrudDatabaseRepository<TEntity, TDbContext> : ICrudRepository<TEntity>
    where TEntity : Entity
    where TDbContext : DbContext
{
    protected readonly TDbContext DbContext;
    private readonly DbSet<TEntity> _dbSet;

    public CrudDatabaseRepository(TDbContext dbContext)
    {
        DbContext = dbContext;
        _dbSet = DbContext.Set<TEntity>();
    }

    public PagedResult<TEntity> GetPaged(int page, int pageSize)
    {
        var task = _dbSet.GetPagedById(page, pageSize);
        task.Wait();
        return task.Result;
    }

    public TEntity Get(long id)
    {
        var entity = _dbSet.Find(id);
        if (entity == null) throw new KeyNotFoundException("Not found: " + id);
        return entity;
    }

    public TEntity GetUntracked(long id)
    {
        var entity = _dbSet.AsNoTracking().FirstOrDefault(e => e.Id == id);

        if (entity == null)
        {
            throw new KeyNotFoundException("Not found: " + id);
        }

        return entity;
    }

    public TEntity Create(TEntity entity)
    {
        try
        {
        _dbSet.Add(entity);
        DbContext.SaveChanges();
        return entity;
        }catch(Exception e)
        {
            throw new DbUpdateException(e.Message);
        }
    }

    public TEntity Update(TEntity entity)
    {
        try
        {
            DbContext.Update(entity);
            DbContext.SaveChanges();
        }
        catch (DbUpdateException e)
        {
            throw new KeyNotFoundException(e.Message);
        }
        return entity;
    }

    public void Delete(long id)
    {
        var entity = Get(id);
        _dbSet.Remove(entity);
        DbContext.SaveChanges();
    }
}