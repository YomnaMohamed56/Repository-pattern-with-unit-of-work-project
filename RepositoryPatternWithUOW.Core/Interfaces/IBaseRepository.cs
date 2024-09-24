﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RepositoryPatternWithUOW.Core.Consts;

namespace RepositoryPatternWithUOW.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        T Find(Expression<Func<T, bool>> predicate, string[] includes = null);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate, string[] includes = null);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate, int skip, int take);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate, int? skip, int? take,
            Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending);
        T Add(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);
        T Update(T entity);
        void Delete(T entity);  
        void DeleteRange(IEnumerable<T> entities);
        void Attach(T entity);
        int Count();
        int Count(Expression<Func<T, bool>> predicate); 
    }
}
