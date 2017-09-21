using System;
using ConnectApi.Models;
using ConnectApi.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        public IActionResult Get([FromQuery] PaginationParams paginationParams,
            [FromQuery] SortingInfo sortingInfo)
        {
            var companies = Service.GetList(paginationParams, sortingInfo);
            return Ok(companies);
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
        public IActionResult Get([FromRoute] int id)
        {
            var company = Service.GetById(id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="companyJObject"></param>
        /// <returns>Company</returns>
        /// <response code="200">Found Record</response>
        /// <response code="404">Record not found</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Company), 200)]
        [ProducesResponseType(typeof(Nullable), 404)]
        public IActionResult Put([FromRoute] int id, [FromBody] JObject companyJObject)
        {
            var company = Service.GetById(id);
            if (company == null)
            {
                return NotFound();
            }

            JsonConvert.PopulateObject(companyJObject.ToString(), company);
            return Ok(Service.Put(company));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Company</returns>
        /// <response code="201">Found Record</response>
        [HttpPost]
        [ProducesResponseType(typeof(Company), 201)]
        public IActionResult Add([FromBody] Company company)
        {
            if (company == null)
            {
                return BadRequest();
            }

            return Created($"companies/{company.Id}", Service.Add(company));
        }
    }
}