using System.Collections.Generic;
using ConnectApi.Models;

namespace ConnectApi.Services.Interface
{
    public interface IServiceBase<T> where T : ModelBase
    {
        List<T> GetList();
        T GetById(int id);
    }
}