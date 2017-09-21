using System;
using ConnectApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ConnectApi.Tests.Fixtures
{
    public abstract class FixtureBase : IDisposable
    {
        public ConnectDbContext ConnectDbContext { get; }
        public IServiceProvider ServiceProvider { get; }

        protected FixtureBase()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            ServiceProvider = new ServiceCollection()
                .AddDbContext<ConnectDbContext>(
                    options => options.UseInMemoryDatabase()
                        .UseInternalServiceProvider(serviceProvider))
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            ConnectDbContext = (ConnectDbContext) ServiceProvider.GetService(typeof(ConnectDbContext));

            // ReSharper disable once VirtualMemberCallInConstructor
            Setup();
        }

        protected abstract void Setup();

        public void Dispose()
        {
            ConnectDbContext.Dispose();
        }
    }
}