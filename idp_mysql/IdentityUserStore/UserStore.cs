using IdentityServer4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace idp_mysql.IdentityUserStore
{
    public class UserStore
    {
        #region iniaialize
        private readonly UserStoreDbContext _userStoreDbContext;
        public UserStore(UserStoreDbContext userStoreDbContext)
        {
            _userStoreDbContext = userStoreDbContext;
        }
        #endregion

        #region get User by Id
        public IdentityUser FindBySubjectId(string subjectId)
        {
            return _userStoreDbContext.Set<IdentityUser>().Where(x => x.SubjectId.Equals(subjectId)).Include(x => x.IdentityUserClaims).SingleOrDefault();
        }
        #endregion

        #region get User by username
        public IdentityUser FindByUserName(string username)
        {
            return _userStoreDbContext.identityUser.Where(x => x.Username.Equals(username)).Include(x => x.IdentityUserClaims).SingleOrDefault();
        }
        #endregion

        #region validate password
        public bool ValidateCredentials(string username,string password)
        {
            password = password.Sha256();
            var user = _userStoreDbContext.identityUser.Where(x => x.Username.Equals(username) && x.Password.Equals(password)).Include(x => x.IdentityUserClaims).SingleOrDefault();
            return user != null;
        }
        #endregion
    }
}
