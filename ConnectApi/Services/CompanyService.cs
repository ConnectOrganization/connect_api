using System.Collections.Generic;
using System.Linq;
using ConnectApi.Models;
using ConnectApi.Services.Interface;
using ConnectApi.Validations;
using Microsoft.EntityFrameworkCore;
using Pagination;
using Pagination.Extensions;
using Sorting;

namespace ConnectApi.Services
{
    public class CompanyService : ServiceBase<Company>, ICompanyService
    {
        public CompanyService(ConnectDbContext connectDbContext, CompanyValidator companyValidator)
            : base(connectDbContext, companyValidator)
        {
        }

        public override List<Company> GetList(PaginationParams paginationParams, SortingInfo sortingInfo)
        {
            sortingInfo.Add(nameof(Company.CompanyName), Sorting.Sorting.Asc);

            var query = Context.Companies.GetList(paginationParams).IncludeOrderBy(sortingInfo).Include(a => a.Address)
                .AsNoTracking();
            return query.ToList();
        }

        public override Company GetById(int id)
        {
            var company = Context.Companies.Find(id);
            if (company != null)
            {
                Context.Entry(company).Reference(a => a.Address).Load();
            }
            return company;
        }

        public override Company Put(Company company)
        {
            return base.Put(company);
        }
    }
}