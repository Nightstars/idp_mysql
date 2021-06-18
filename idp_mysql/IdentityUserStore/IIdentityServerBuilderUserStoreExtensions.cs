using IdentityServer4.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace idp_mysql.IdentityUserStore
{
    public static class IIdentityServerBuilderUserStoreExtensions
    {
        public static IIdentityServerBuilder AddUserStore(this IIdentityServerBuilder builder,Action<DbContextOptionsBuilder> userStoreOptions=null)
        {
            builder.Services.AddDbContext<UserStoreDbContext>(userStoreOptions);
            builder.Services.AddTransient<UserStore>();
            return builder;
        }
    }
}
