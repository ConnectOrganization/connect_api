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
            var response = _client.WithUrl("companies/1").GetJsonAsync<Company>().Result;

            //  Assertions
            Assert.NotNull(response);
        }

        [Fact(DisplayName = "Get All Should Return All companies")]
        public void GetAllShouldReturnAllCompanies()
        {
            var result = _client.WithUrl("companies").GetJsonAsync<List<Company>>().Result;

            //  Assertions
            Assert.Equal(1, result.Count);
        }
    }
}