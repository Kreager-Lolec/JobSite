using System.ComponentModel.DataAnnotations;

namespace JobSite.Data.Models
{
    public class ShopCartItem
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? ShopCartId { get; set; }
        public virtual ShopCart? ShopCart { get; set; }
        public virtual BuildingMaterial? BuildingMaterial { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; }
        public double TotalCost(int quantity, int price)
        {
            return (double)quantity * price;
        }
    }
}
