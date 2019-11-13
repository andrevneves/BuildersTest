using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Builders.DotNetCore.Domain.Interfaces
{
    public interface IRepository<TEntity, TType> where TEntity : class
    {
        string Insert(TEntity entity);
        bool Delete(TType id);
        bool Exists(Expression<Func<TEntity, bool>> filter);
        IList<TEntity> GetAll();
        TEntity GetById(TType id);
        IList<TEntity> SearchFor(Expression<Func<TEntity, bool>> filter);
        bool Update(TEntity entity);
    }
}
