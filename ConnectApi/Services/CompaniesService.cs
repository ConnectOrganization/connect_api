﻿using System.Collections.Generic;
using System.Linq;
using ConnectApi.Models;
using ConnectApi.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace ConnectApi.Services
{
    public class CompaniesService : ICompaniesService
    {
        private readonly DbSet<Company> _repository;

        public CompaniesService(ConnectDbContext connectDbContext)
        {
            _repository = connectDbContext.Companies;
        }

        public List<Company> GetList()
        {
            return _repository.Include(a => a.Address).ToList();
        }

        public Company GetById(int id)
        {
            return _repository.Find(id);
        }
    }
}