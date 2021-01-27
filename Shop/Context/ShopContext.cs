using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Host.Models.Identity;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Context
{
    public class ShopContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>,
      ApplicationUserRole, IdentityUserLogin<string>,
      IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ShopContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<Vender> vender { get; set; }
    }
}
