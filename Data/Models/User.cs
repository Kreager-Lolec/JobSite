using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSite.Data.Models
{
    public class User : IdentityUser
    {
        public virtual ShopCart ShopCart { get; set; }
        public int identityHomeList { get; set; }
    }
}
