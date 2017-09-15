using System;
using ConnectApi.Models;
using ConnectApi.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Pagination;
using Sorting;

namespace ConnectApi.Controllers
{
    [Route("Companies")]
    public class CompanyController : AppControllerBase<ICompanyService, Company>
    {
        public CompanyController(ICompanyService service) : base(service)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">Found Record</response>
        /// <returns>Companies</returns>
        [ProducesResponseType(typeof(Company), 200)]
        [HttpGet]
        public IActionResult Get([FromQuery] PaginationParams paginationParams, SortingInfo sortingInfo)
        {
            var result = Service.GetList(paginationParams, sortingInfo);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Company</returns>
        /// <response code="200">Found Record</response>
        /// <response code="404">Record not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Company), 200)]
        [ProducesResponseType(typeof(Nullable), 404)]
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