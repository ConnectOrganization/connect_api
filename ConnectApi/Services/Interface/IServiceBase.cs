using System.Collections.Generic;
using ConnectApi.Models;
using Pagination;
using Sorting;

namespace ConnectApi.Services.Interface
{
    public interface IServiceBase<T> where T : ModelBase
    {
        List<T> GetList();
        List<T> GetList(PaginationParams paginationParams, SortingInfo sortingInfo);
        T GetById(int id);
        T Put(T entity);
    }
}