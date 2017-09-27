using System;
using System.Linq;
using ConnectApi.Models;

namespace ConnectApi.SeedData
{
    public class CompanyData
    {
        /// <summary>
        /// Used to initialize dummy table data if no rows present in database.
        /// </summary>
        /// <param name="connectDbContext"></param>
        public static void Initialize(ConnectDbContext connectDbContext)
        {
            if (!connectDbContext.Companies.Any())
            {
                connectDbContext.Companies.AddRange(
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
                        InocomeTaxPan = "INCOMETax",
                        LandLine1 = "0001",
                        LandLine2 = "0002",
                        Licence1 = "0001",
                        Licence2 = "0002",
                        PrintingName = "Industrial",
                        ShortName = "Industrial",
                        TaxReg1 = "Tax001",
                        TaxReg2 = "Tax002"
                    },
                    new Company
                    {
                        BusinessType = "Partnership",
                        CompanyName = "Partner Shop and privt ltd",
                        CurrencyType = "INR",
                        GST = "GST0123456789",
                        AccountFrom = new DateTime(2013, 11, 11),
                        AccountTo = new DateTime(2022, 11, 23),
                        Phone = "990099988",
                        CreatedBy = "Developer",
                        CreatedDate = new DateTime(2017, 10, 10),
                        Address = new AddressInfo
                        {
                            Active = true,
                            Address = "Industrial Area",
                            City = "Bangalore",
                            State = "Karnataka",
                            CreatedDate = new DateTime(2017, 10, 10),
                            CreatedBy = "Developer",
                            Email = "partnership@gmail.com",
                            PinCode = "555602",
                            ModifiedBy = "Developer",
                            ModifiedDate = new DateTime(2017, 10, 10)
                        },
                        Active = true,
                        ModifiedBy = "Developer",
                        ModifiedDate = new DateTime(2017, 10, 10),
                        BooksFrom = new DateTime(2017, 10, 10),
                        Fax = "PartnerFax",
                        InocomeTaxPan = "PartnerTax",
                        LandLine1 = "0003",
                        LandLine2 = "0004",
                        Licence1 = "0002",
                        Licence2 = "0003",
                        PrintingName = "PartnerShip",
                        ShortName = "PartnerShip",
                        TaxReg1 = "Tax002",
                        TaxReg2 = "Tax003"
                    },
                    new Company
                    {
                        BusinessType = "Pvt Ltd",
                        CompanyName = "Bison Shop and privt ltd",
                        CurrencyType = "INR",
                        GST = "GST0123456790",
                        AccountFrom = new DateTime(2014, 12, 12),
                        AccountTo = null,
                        Phone = "990099989",
                        CreatedBy = "Developer",
                        CreatedDate = new DateTime(2017, 10, 10),
                        Address = new AddressInfo
                        {
                            Active = true,
                            Address = "Bison Area",
                            City = "Bangalore",
                            State = "Karnataka",
                            CreatedDate = new DateTime(2017, 10, 10),
                            CreatedBy = "Developer",
                            Email = "partnership@gmail.com",
                            PinCode = "555602",
                            ModifiedBy = null,
                            ModifiedDate = null
                        },
                        Active = true,
                        ModifiedBy = null,
                        ModifiedDate = null,
                        BooksFrom = null,
                        Fax = null,
                        InocomeTaxPan = null,
                        LandLine1 = null,
                        LandLine2 = null,
                        Licence1 = null,
                        Licence2 = null,
                        PrintingName = "PartnerShip",
                        ShortName = "PartnerShip",
                        TaxReg1 = null,
                        TaxReg2 = null
                    },
                    new Company
                    {
                        BusinessType = "Public Ltd",
                        CompanyName = "Public limited",
                        CurrencyType = "INR",
                        GST = "GST0123456791",
                        AccountFrom = new DateTime(2015, 01, 01),
                        AccountTo = null,
                        Phone = "990099990",
                        CreatedBy = "Developer",
                        CreatedDate = new DateTime(2017, 01, 01),
                        Address = new AddressInfo
                        {
                            Active = false,
                            Address = "Public Area",
                            City = "Bangalore",
                            State = "Karnataka",
                            CreatedDate = new DateTime(2017, 10, 10),
                            CreatedBy = "Developer",
                            Email = "public@gmail.com",
                            PinCode = "555602",
                            ModifiedBy = null,
                            ModifiedDate = null
                        },
                        Active = false,
                        ModifiedBy = null,
                        ModifiedDate = null,
                        BooksFrom = null,
                        Fax = null,
                        InocomeTaxPan = null,
                        LandLine1 = null,
                        LandLine2 = null,
                        Licence1 = null,
                        Licence2 = null,
                        PrintingName = "Public Ltd",
                        ShortName = "Public Ltd",
                        TaxReg1 = null,
                        TaxReg2 = null
                    }
                );
            }
        }
    }
}