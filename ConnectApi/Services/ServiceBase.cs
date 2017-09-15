using System;
using System.Collections.Generic;
using ConnectApi.Models;
using ConnectApi.Services.Interface;
using Pagination;
using Sorting;

namespace ConnectApi.Services
{
    public abstract class ServiceBase<T> : IServiceBase<T> where T : ModelBase
    {
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
            throw new NotImplementedException();
        }
    }
}