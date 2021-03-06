﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Zanaetchii.Contracts.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        TEntity Find(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        TEntity Update(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
