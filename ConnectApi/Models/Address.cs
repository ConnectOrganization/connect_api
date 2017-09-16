using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectApi.Models
{
    [Table("AddressInfo")]
    public class AddressInfo : ModelBase
    {
        [Key, ForeignKey("Company")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

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

        public virtual Company Company { get; set; }
    }
}