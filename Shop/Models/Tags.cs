using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    [Table("Tagnew")]
    public class Tags
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        [Column(TypeName ="varchar")]
        public string Name { get; set; }
        [Required]
        [MaxLength(20)]
        [Column(TypeName = "varchar")]
        public string Family { get; set; }
        [Required]
        [MaxLength(120)]
        [Column(TypeName = "varchar")]
        public string Address { get; set; }
        [Required]
        [MaxLength(12)]
        [Column(TypeName = "varchar")]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(12)]
        [Column(TypeName = "varchar")]
        public string PhoneMobile { get; set; }
        [ForeignKey("SVender")]
        public int VenderId { get; set; }
        public Vender Vender { get; set; }
    }
}
