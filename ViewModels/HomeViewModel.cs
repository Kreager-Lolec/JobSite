using JobSite.Data.Models;

namespace JobSite.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<BuildingMaterial> AllBuildingMaterials { get; set; }
        public IEnumerable<Delivery> AllDeliveries { get; set; }
        public int IdentifierType { get; set; }
    }
}
