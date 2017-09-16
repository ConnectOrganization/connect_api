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
        protected readonly ConnectDbContext _context;
        protected readonly IValidator<T> _validator;
        protected ServiceBase(ConnectDbContext context, IValidator<T> validator)
        {
            _context = context;
            _validator = validator;
        }

        protected ServiceBase(ConnectDbContext context)
        {
            _context = context;
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
            _context.Update(entity, _validator);
            _context.SaveChanges();
            return entity;
        }

        public virtual T Add(T entity)
        {
			_context.Add(entity, _validator);
			_context.SaveChanges();
			return entity;
        }
    }
}