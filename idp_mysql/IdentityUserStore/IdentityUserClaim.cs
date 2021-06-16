using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace idp_mysql.IdentityUserStore
{
    public class IdentityUserClaim
    {
        [Key]
        public string ClaimId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Value { get; set; }
        [Required]
        public string UserSubjectId { get; set; }
        [ForeignKey("UserSubjectId")]
        public virtual IdentityUser IdentityUser { get; set; }
    }
}
