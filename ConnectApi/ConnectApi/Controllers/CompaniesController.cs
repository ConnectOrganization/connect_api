using System.Collections.Generic;
using ConnectApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConnectApi.Controllers
{
    [Route("Companies")]
    public class CompaniesController : ControllerBase
    {
        private readonly ConnectDbContext _connectDbContext;

        public CompaniesController(ConnectDbContext context)
        {
            _connectDbContext = context;
        }

        [HttpGet]
        public IEnumerable<Company> Get()
        {
            return _connectDbContext.Companies;
        }

        [HttpGet("{id}")]
        public Company Get(int id)
        {
            return _connectDbContext.Companies.Find(id);
        }
    }
}