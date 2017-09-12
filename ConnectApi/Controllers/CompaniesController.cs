using System.Collections.Generic;
using ConnectApi.Models;
using ConnectApi.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ConnectApi.Controllers
{
    [Route("Companies")]
    public class CompaniesController : AppControllerBase<ICompaniesService, Company>
    {
        public CompaniesController(ICompaniesService service) : base(service)
        {
        }

        [HttpGet]
        public IEnumerable<Company> Get()
        {
            var result = Service.GetList();
            return result;
        }

        [HttpGet("{id}")]
        public Company Get(int id)
        {
            return Service.GetById(id);
        }
    }
}