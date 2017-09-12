using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectApi.Models
{
    [Table("CompanyInfo")]
    public class Company : ModelBase
    {
        [Required]
        [MaxLength(40)]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(20)]
        public string ShortName { get; set; }

        [Required]
        [MaxLength(20)]
        public string PrintingName { get; set; }

        [Required]
        [MaxLength(40)]
        public string BusinessType { get; set; }

        [Required]
        [MaxLength(3)]
        public string CurrencyType { get; set; }

        [Required]
        [MaxLength(10)]
        public string Phone { get; set; }

        [MaxLength(10)]
        public string LandLine1 { get; set; }

        [MaxLength(10)]
        public string LandLine2 { get; set; }

        [MaxLength(10)]
        public string Fax { get; set; }

        [Required]
        [MaxLength(15)]
        public string GST { get; set; }

        [MaxLength(10)]
        public string TaxReg1 { get; set; }

        [MaxLength(10)]
        public string TaxReg2 { get; set; }

        [MaxLength(10)]
        public string Licence1 { get; set; }

        [MaxLength(10)]
        public string Licence2 { get; set; }

        [MaxLength(10)]
        public string InocomeTaxPan { get; set; }

        [Required]
        public DateTime AccountFrom { get; set; }

        public DateTime? AccountTo { get; set; }

        public DateTime? BooksFrom { get; set; }

        public virtual  AddressInfo Address { get; set; }
    }
}