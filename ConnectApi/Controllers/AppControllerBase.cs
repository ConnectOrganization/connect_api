using ConnectApi.Models;
using ConnectApi.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ConnectApi.Controllers
{
    public abstract class AppControllerBase<T, TU> : ControllerBase where T : IServiceBase<TU> where TU : ModelBase
    {
        protected T Service { get; }

        protected AppControllerBase(T service)
        {
            Service = service;
        }
    }
}