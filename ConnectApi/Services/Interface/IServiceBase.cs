using System.Collections.Generic;
using ConnectApi.Models;
using Pagination;

namespace ConnectApi.Services.Interface
{
    public interface IServiceBase<T> where T : ModelBase
    {
        List<T> GetList();
        List<T> GetList(PaginationParams paginationParams);
        T GetById(int id);
    }
}