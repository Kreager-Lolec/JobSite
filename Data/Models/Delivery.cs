namespace JobSite.Data.Models
{
    public class Delivery
    {
        public Guid Id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public double distance { get; set; }
        public ushort price { get; set; }
        public bool isFavourite { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual CaterogyGoods CaterogyGood { set; get; }
    }
}
