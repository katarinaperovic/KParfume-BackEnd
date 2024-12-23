﻿using KParfume.BuildingBlocks.Core.Domain;

namespace KParfume.BuildingBlocks.Core.UseCases;

public interface ICrudRepository<TEntity> where TEntity : Entity
{
    PagedResult<TEntity> GetPaged(int page, int pageSize);
    TEntity Get(long id);
    TEntity GetUntracked(long id);
    TEntity Create(TEntity entity);
    TEntity Update(TEntity entity);
    void Delete(long id);
}