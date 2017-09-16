using System;
using System.Collections.Generic;
using ConnectApi.Models;
using ConnectApi.Services.Interface;
using Pagination;
using Sorting;
using Validation;

namespace ConnectApi.Services
{
    public abstract class ServiceBase<T> : IServiceBase<T> where T : ModelBase, new()
    {
        protected readonly ConnectDbContext Context;
        protected readonly IValidator<T> Validator;

        protected ServiceBase(ConnectDbContext context, IValidator<T> validator)
        {
            Context = context;
            Validator = validator;
        }

        protected ServiceBase(ConnectDbContext context)
        {
            Context = context;
        }

        public virtual List<T> GetList()
        {
            throw new NotImplementedException();
        }

        public virtual List<T> GetList(PaginationParams paginationParams, SortingInfo sortingInfo)
        {
            throw new NotImplementedException();
        }

        public virtual T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public virtual T Put(T entity)
        {
            Context.Update(entity, Validator);
            Context.SaveChanges();
            return entity;
        }

        public virtual T Add(T entity)
        {
            Context.Add(entity, Validator);
            Context.SaveChanges();
            return entity;
        }
    }
}