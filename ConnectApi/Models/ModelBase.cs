using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectApi.Models
{
    public abstract class ModelBase
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        [MaxLength(20)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [Required]
        [MaxLength(20)]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public bool Active { get; set; }
    }
}