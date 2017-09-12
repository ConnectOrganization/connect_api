using ConnectApi.Models;
using ConnectApi.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ConnectApi.Controllers
{
    [Route("Companies")]
    public class CompanyController : AppControllerBase<ICompanyService, Company>
    {
        public CompanyController(ICompanyService service) : base(service)
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = Service.GetList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var company = Service.GetById(id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }
    }
}