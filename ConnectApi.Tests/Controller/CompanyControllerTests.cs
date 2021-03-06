﻿using System;
using System.Collections.Generic;
using System.Net;
using ConnectApi.Models;
using Flurl.Http;
using Xunit;

namespace ConnectApi.Tests.Controller
{
    [Trait("Category", "Integration")]
    [Collection("IntegrationTestCollection")]
    public class CompanyControllerTests
    {
        private readonly FlurlClient _client;

        public CompanyControllerTests(TestServerFixture fixture)
        {
            _client = fixture.FlurlClient;
        }

        [Fact(DisplayName = "Get with invalid id should return not found result")]
        public void GetWithInvalidIdShouldReturnNotFoundStatusCode()
        {
            var response = _client.WithUrl("companies/0").GetAsync().Result;

            //  Assertions
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact(DisplayName = "Get with valid id should return valid result")]
        public void GetWithValidIdShouldReturnValidResult()
        {
            var company = _client.WithUrl("companies/1").GetJsonAsync<Company>().Result;

            //  Assertions
            Assert.NotNull(company);
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
            Assert.Equal("INCOMETax", company.InocomeTaxPan);
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

        [Fact(DisplayName = "Get All Should Return All companies")]
        public void GetAllShouldReturnAllCompanies()
        {
            var result = _client.WithUrl("companies").GetJsonAsync<List<Company>>().Result;

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
                    Assert.Equal("INCOMETax", item.InocomeTaxPan);
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
    }
}