using System;
using ConnectApi.Models;
using ConnectApi.Services;
using ConnectApi.Tests.Fixtures;
using Xunit;

namespace ConnectApi.Tests.Services
{
    [Trait("Category", "UnitTest")]
    [Trait("Category", "Company")]
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
            var result = service.GetList();

            //  Assertions
            Assert.Collection(result,
                keyValuePair =>
                {
                    Assert.Equal("Propriteryship", keyValuePair.BusinessType);
                    Assert.Equal(true, keyValuePair.Active);
                    Assert.Equal(new DateTime(2012, 12, 2), keyValuePair.AccountFrom);
                    Assert.Equal(new DateTime(2019, 12, 2), keyValuePair.AccountTo);
                    Assert.Equal(new DateTime(2017, 10, 10), keyValuePair.BooksFrom);
                    Assert.Equal("Industrial Shop and privt ltd", keyValuePair.CompanyName);
                    Assert.Equal("FAX001", keyValuePair.Fax);
                    Assert.Equal("RUP", keyValuePair.CurrencyType);
                    Assert.Equal("01AFZPL5814M012", keyValuePair.GST);
                    Assert.Equal("INCOMETaxPan", keyValuePair.InocomeTaxPan);
                    Assert.Equal("0001", keyValuePair.LandLine1);
                    Assert.Equal("0002", keyValuePair.LandLine2);
                    Assert.Equal("0001", keyValuePair.Licence1);
                    Assert.Equal("0002", keyValuePair.Licence2);
                    Assert.Equal("123456789", keyValuePair.Phone);
                    Assert.Equal("Industrial", keyValuePair.PrintingName);
                    Assert.Equal("Industrial", keyValuePair.ShortName);
                    Assert.Equal("Tax001", keyValuePair.TaxReg1);
                    Assert.Equal("Tax002", keyValuePair.TaxReg2);
                    Assert.Equal("Anand", keyValuePair.CreatedBy);
                    Assert.Equal("Anand", keyValuePair.ModifiedBy);

                    // Address
                    Assert.Equal("70/B, Bridnavan Nagar, DRC post", keyValuePair.Address.Address);
                    Assert.Equal("Bangalore", keyValuePair.Address.City);
                    Assert.Equal("sample@gmail.com", keyValuePair.Address.Email);
                    Assert.Equal("555602", keyValuePair.Address.PinCode);
                    Assert.Equal("Karnataka", keyValuePair.Address.State);
                    Assert.Equal("Anand", keyValuePair.Address.CreatedBy);
                    Assert.Equal("Anand", keyValuePair.Address.ModifiedBy);
                }
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