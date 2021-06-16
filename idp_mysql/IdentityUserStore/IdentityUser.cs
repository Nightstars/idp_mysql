using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace idp_mysql.IdentityUserStore
{
    public class IdentityUser
    {
        [Key]
        [Required]
        public string SubjectId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string ProviderName { get; set; }
        public string ProviderSubjectId { get; set; }
        public bool IsActive { get; set; }
        public ICollection<IdentityUserClaim> IdentityUserClaims { get; set; }

    }

}
