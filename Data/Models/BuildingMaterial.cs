namespace JobSite.Data.Models
{
    public class BuildingMaterial
    {
        public Guid Id { get; set; }
        public Guid? ShopCartItemId { get; set; }
        public virtual ShopCartItem? ShopCartItem { get; set; }
        public string name { get; set; }
        public string mark { get; set; }
        public string img { get; set; }
        public ushort price { get; set; }
        public bool isFavourite { get; set; }
        public bool available { set; get; }
        public string unit { get; set; }
        public Guid CategoryId { get; set; }
        public virtual CaterogyGoods Caterogy { set; get; }
        public Guid CategorySolutionId { get; set; }
        public virtual Solute CategorySolution { set; get; }
    }
}
