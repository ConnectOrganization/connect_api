using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectApi.Models
{
    [Table("CompanyInfo")]
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string BusinessType { get; set; }
        public string CurrencyType { get; set; }
        public string Phone { get; set; }
        // ReSharper disable once InconsistentNaming
        public string GST { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? ClosedDate { get; set; }
    }
}
