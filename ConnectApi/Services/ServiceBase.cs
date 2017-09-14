using System.Collections.Generic;
using ConnectApi.Models;
using ConnectApi.Services.Interface;
using Pagination;

namespace ConnectApi.Services
{
    public abstract class ServiceBase<T> : IServiceBase<T> where T : ModelBase
    {
        public virtual List<T> GetList()
        {
            throw new System.NotImplementedException();
        }

        public virtual List<T> GetList(PaginationParams paginationParams)
        {
            throw new System.NotImplementedException();
        }

        public virtual T GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}