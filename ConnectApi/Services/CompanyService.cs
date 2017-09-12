using System.Collections.Generic;
using System.Linq;
using ConnectApi.Models;
using ConnectApi.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace ConnectApi.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ConnectDbContext _context;

        public CompanyService(ConnectDbContext connectDbContext)
        {
            _context = connectDbContext;
        }

        public List<Company> GetList()
        {
            return _context.Companies.Include(a => a.Address).AsNoTracking().ToList();
        }

        public Company GetById(int id)
        {
            var company = _context.Companies.Find(id);
            _context.Entry(company).Reference(a => a.Address).Load();
            return company;
        }
    }
}