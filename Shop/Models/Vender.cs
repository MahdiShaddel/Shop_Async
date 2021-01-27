using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    [Table("Vendor")]
    public class Vender
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MaxLength(20)]
        public string Title { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public ICollection<Tags>Tags { get; set; }
    }
}
