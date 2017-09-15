using System;
using ConnectApi.Models;
using ConnectApi.Services;
using ConnectApi.Tests.Fixtures;
using Pagination;
using Sorting;
using Xunit;

namespace ConnectApi.Tests.Services
{
    [Trait("Category", "UnitTest")]
    public class CompanyServiceTests : IClassFixture<CompanyFixture>
    {
        private readonly ConnectDbContext _context;

        public CompanyServiceTests(CompanyFixture fixture)
        {
            _context = fixture.ConnectDbContext;
        }

        [Fact(DisplayName = "Get should return all companies")]
        public void GetShouldReturnAllCompanies()
        {
            var service = new CompanyService(_context);
            var result = service.GetList(new PaginationParams(), new SortingInfo());

            //  Assertions
            Assert.Equal(4, result.Count);
            Assert.Collection(result,
                item => { },
                item =>
                {
                    Assert.Equal("Propriteryship", item.BusinessType);
                    Assert.Equal(true, item.Active);
                    Assert.Equal(new DateTime(2012, 12, 2), item.AccountFrom);
                    Assert.Equal(new DateTime(2019, 12, 2), item.AccountTo);
                    Assert.Equal(new DateTime(2017, 10, 10), item.BooksFrom);
                    Assert.Equal("Industrial Shop and privt ltd", item.CompanyName);
                    Assert.Equal("FAX001", item.Fax);
                    Assert.Equal("RUP", item.CurrencyType);
                    Assert.Equal("01AFZPL5814M012", item.GST);
                    Assert.Equal("INCOMETaxPan", item.InocomeTaxPan);
                    Assert.Equal("0001", item.LandLine1);
                    Assert.Equal("0002", item.LandLine2);
                    Assert.Equal("0001", item.Licence1);
                    Assert.Equal("0002", item.Licence2);
                    Assert.Equal("123456789", item.Phone);
                    Assert.Equal("Industrial", item.PrintingName);
                    Assert.Equal("Industrial", item.ShortName);
                    Assert.Equal("Tax001", item.TaxReg1);
                    Assert.Equal("Tax002", item.TaxReg2);
                    Assert.Equal("Anand", item.CreatedBy);
                    Assert.Equal("Anand", item.ModifiedBy);

                    // Address
                    Assert.Equal("70/B, Bridnavan Nagar, DRC post", item.Address.Address);
                    Assert.Equal("Bangalore", item.Address.City);
                    Assert.Equal("sample@gmail.com", item.Address.Email);
                    Assert.Equal("555602", item.Address.PinCode);
                    Assert.Equal("Karnataka", item.Address.State);
                    Assert.Equal("Anand", item.Address.CreatedBy);
                    Assert.Equal("Anand", item.Address.ModifiedBy);
                },
                item => { },
                item => { }
            );
        }

        [Fact(DisplayName = "Get should return record for valid Id")]
        public void GetShouldReturnRecordForValidId()
        {
            var service = new CompanyService(_context);
            var company = service.GetById(1);

            //  Assertions
            Assert.Equal("Propriteryship", company.BusinessType);
            Assert.Equal(true, company.Active);
            Assert.Equal(new DateTime(2012, 12, 2), company.AccountFrom);
            Assert.Equal(new DateTime(2019, 12, 2), company.AccountTo);
            Assert.Equal(new DateTime(2017, 10, 10), company.BooksFrom);
            Assert.Equal("Industrial Shop and privt ltd", company.CompanyName);
            Assert.Equal("FAX001", company.Fax);
            Assert.Equal("RUP", company.CurrencyType);
            Assert.Equal("01AFZPL5814M012", company.GST);
            Assert.Equal("INCOMETaxPan", company.InocomeTaxPan);
            Assert.Equal("0001", company.LandLine1);
            Assert.Equal("0002", company.LandLine2);
            Assert.Equal("0001", company.Licence1);
            Assert.Equal("0002", company.Licence2);
            Assert.Equal("123456789", company.Phone);
            Assert.Equal("Industrial", company.PrintingName);
            Assert.Equal("Industrial", company.ShortName);
            Assert.Equal("Tax001", company.TaxReg1);
            Assert.Equal("Tax002", company.TaxReg2);
            Assert.Equal("Anand", company.CreatedBy);
            Assert.Equal("Anand", company.ModifiedBy);

            //  Address
            Assert.Equal("70/B, Bridnavan Nagar, DRC post", company.Address.Address);
            Assert.Equal("Bangalore", company.Address.City);
            Assert.Equal("sample@gmail.com", company.Address.Email);
            Assert.Equal("555602", company.Address.PinCode);
            Assert.Equal("Karnataka", company.Address.State);
            Assert.Equal("Anand", company.Address.CreatedBy);
            Assert.Equal("Anand", company.Address.ModifiedBy);
        }

        [Fact(DisplayName = "Get should return nothing for invalid Id")]
        public void GetShouldReturnNothingForInValidId()
        {
            var service = new CompanyService(_context);
            var company = service.GetById(0);

            //  Assertions
            Assert.Null(company);
        }
    }
}