using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectApi.Models
{
    [Table("Company")]
    public class AddressInfo : ModelBase
    {
        [Required]
        public string Address { get; set; }

        [Required]
        public string PinCode { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Email { get; set; }
    }
}