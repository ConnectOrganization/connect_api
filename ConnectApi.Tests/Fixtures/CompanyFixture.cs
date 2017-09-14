namespace ConnectApi.Tests.Fixtures
{
    public class CompanyFixture : FixtureBase
    {
        protected override void Setup()
        {
            SeedData.CompanyData.Initialize(ConnectDbContext);
            ConnectDbContext.SaveChanges();
        }
    }
}