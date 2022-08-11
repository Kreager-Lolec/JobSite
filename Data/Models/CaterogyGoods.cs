namespace JobSite.Data.Models
{
    public class CaterogyGoods
    {
        public Guid Id { set; get; }
        public string categoryName { set; get; }
        public string description { set; get; }
        public virtual List<BuildingMaterial> buildingMaterials { set; get; }
    }
}
