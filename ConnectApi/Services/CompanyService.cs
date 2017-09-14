using System.Collections.Generic;
using System.Linq;
using ConnectApi.Models;
using ConnectApi.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Pagination;
using Pagination.Extensions;

namespace ConnectApi.Services
{
    public class CompanyService : ServiceBase<Company>, ICompanyService
    {
        private readonly ConnectDbContext _context;

        public CompanyService(ConnectDbContext connectDbContext)
        {
            _context = connectDbContext;
        }

        public override List<Company> GetList(PaginationParams paginationParams)
        {
            return _context.Companies.GetList(paginationParams).OrderBy(o => o.CompanyName).Include(a => a.Address)
                .AsNoTracking().ToList();
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