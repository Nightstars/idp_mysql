using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace idp_mysql.IdentityUserStore
{
    public class UserStoreDbContext : DbContext
    {
        #region initialize
        public UserStoreDbContext(DbContextOptions<UserStoreDbContext> options): base(options)
        {

        }
        #endregion

        public DbSet<IdentityUser> identityUser { get; set; }
        public DbSet<IdentityUserClaim> identityUserClaim { get; set; }
    }
}
