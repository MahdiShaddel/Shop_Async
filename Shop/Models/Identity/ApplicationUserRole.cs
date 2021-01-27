using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Host.Models.Identity
{
    [Table("ApplicationUserRole")]
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        [Key]
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public ApplicationRole Role { get; set; }
    }
}
