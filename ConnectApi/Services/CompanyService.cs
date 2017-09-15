using System.Collections.Generic;
using System.Linq;
using ConnectApi.Models;
using ConnectApi.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Pagination;
using Pagination.Extensions;
using Sorting;

namespace ConnectApi.Services
{
    public class CompanyService : ServiceBase<Company>, ICompanyService
    {
        private readonly ConnectDbContext _context;

        public CompanyService(ConnectDbContext connectDbContext)
        {
            _context = connectDbContext;
        }

        public override List<Company> GetList(PaginationParams paginationParams, SortingInfo sortingInfo)
        {
            sortingInfo.Add(nameof(Company.CompanyName), Sorting.Sorting.Asc);

            var query = _context.Companies.GetList(paginationParams).IncludeOrderBy(sortingInfo).Include(a => a.Address)
                .AsNoTracking();
            return query.ToList();
        }

        public override Company GetById(int id)
        {
            var company = _context.Companies.Find(id);
            if (company != null)
            {
                _context.Entry(company).Reference(a => a.Address).Load();
            }
            return company;
        }
    }
}