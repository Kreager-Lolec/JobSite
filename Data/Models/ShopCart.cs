using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSite.Data.Models
{
    public class ShopCart
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public virtual List<ShopCartItem> ShopCartItems { get; set; }
    }
}
