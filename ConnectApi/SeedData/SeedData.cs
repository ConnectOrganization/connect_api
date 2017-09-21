using ConnectApi.Models;

namespace ConnectApi.SeedData
{
    public static class SeedData
    {
        /// <summary>
        /// Used to initialize dummy table data if no rows present in database.
        /// </summary>
        /// <param name="connectDbContext"></param>
        public static void Initialize(ConnectDbContext connectDbContext)
        {
            CompanyData.Initialize(connectDbContext);
            connectDbContext.SaveChanges();
        }
    }
}