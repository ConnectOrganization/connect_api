using System;
using System.Net.Http;
using ConnectApi.Models;
using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace ConnectApi.Tests
{
    public class TestServerFixture : IDisposable
    {
        private readonly TestServer _server;
        private ConnectDbContext Context { get; }

        public TestServerFixture()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>())
            {
                BaseAddress = new Uri("http://localhost:5000")
            };

            FlurlClient = new FlurlClient {Settings = {HttpClientFactory = new HttpClientFactory(_server)}};

            var provider = _server.Host.Services;
            Context = provider.GetRequiredService<ConnectDbContext>();
        }

        public FlurlClient FlurlClient { get; }

        public void Dispose()
        {
            Context.Database.EnsureDeleted();
            Context.Dispose();
            FlurlClient.Dispose();
            _server.Dispose();
        }
    }

    public class HttpClientFactory : DefaultHttpClientFactory
    {
        private readonly TestServer _testServer;

        public HttpClientFactory(TestServer server)
        {
            _testServer = server;
        }

        public override HttpClient CreateClient(Url url, HttpMessageHandler handler)
        {
            return _testServer.CreateClient();
        }

        public override HttpMessageHandler CreateMessageHandler()
        {
            return _testServer.CreateHandler();
        }
    }
}