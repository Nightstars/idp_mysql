using IdentityServer4.Models;
using IdentityServerHost.Quickstart.UI;
using idp_mysql.IdentityUserStore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace idp_mysql
{
    public static  class SeedUser
    {
        public static void SeedData(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            var userContext = serviceScope.ServiceProvider.GetRequiredService<UserStoreDbContext>();
            //添加Config中的Users数据到数据库
            if (!userContext.identityUser.Any())
            {
                int index = 0;
                foreach (var user in TestUsers.Users)
                {
                    IdentityUser identityUser = new IdentityUser {
                        IsActive = user.IsActive,
                        Password = user.Password.Sha256(),
                        ProviderName = user.ProviderName,
                        ProviderSubjectId = user.ProviderSubjectId,
                        SubjectId = user.SubjectId,
                        Username = user.Username,
                        IdentityUserClaims = user.Claims.Select(x => new IdentityUserClaim {
                            ClaimId = (index++).ToString(),
                            Name = x.Type,
                            Value = x.Value
                        }).ToList()
                    };
                    userContext.identityUser.Add(identityUser);
                }
                userContext.SaveChanges();
            }

        }
        
    }
}
