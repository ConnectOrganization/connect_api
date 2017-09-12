using System;
using System.Linq;
using ConnectApi.Models;

namespace ConnectApi
{
    public class SeedData
    {
        /// <summary>
        /// Used to initialize dummy table data if no rows present in database.
        /// </summary>
        /// <param name="connectDbContext"></param>
        public static void Initialize(ConnectDbContext connectDbContext)
        {
            using (var context = connectDbContext)
            {
                if (!context.Companies.Any())
                {
                    context.Companies.AddRange(
                        new Company
                        {
                            BusinessType = "Propriteryship",
                            CompanyName = "Industrial Shop and privt ltd",
                            CurrencyType = "RUP",
                            GST = "01AFZPL5814M012",
                            AccountFrom = new DateTime(2012, 12, 2),
                            AccountTo = new DateTime(2019, 12, 2),
                            Phone = "123456789",
                            CreatedBy = "Anand",
                            CreatedDate = new DateTime(2017, 10, 10),
                            Address = new AddressInfo
                            {
                                Active = true,
                                Address = "70/B, Bridnavan Nagar, DRC post",
                                City = "Bangalore",
                                State = "Karnataka",
                                CreatedDate = new DateTime(2017, 10, 10),
                                CreatedBy = "Anand",
                                Email = "sample@gmail.com",
                                PinCode = "555602",
                                ModifiedBy = "Anand",
                                ModifiedDate = new DateTime(2017, 10, 10)
                            },
                            Active = true,
                            ModifiedBy = "Anand",
                            ModifiedDate = new DateTime(2017, 10, 10),
                            BooksFrom = new DateTime(2017, 10, 10),
                            Fax = "FAX001",
                            InocomeTaxPan = "INCOMETaxPan",
                            LandLine1 = "0001",
                            LandLine2 = "0002",
                            Licence1 = "0001",
                            Licence2 = "0002",
                            PrintingName = "Industrial",
                            ShortName = "Industrial",
                            TaxReg1 = "Tax001",
                            TaxReg2 = "Tax002"
                        }
                    );
                }

                context.SaveChanges();
            }
        }
    }
}