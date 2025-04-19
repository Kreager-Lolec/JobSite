using JobSite.Data.Models;

namespace JobSite.ViewModels
{
    public class BuildingMaterialViewModel
    {
        public IEnumerable<BuildingMaterial> AllBuildingMaterials { get; set; }
        public string currentCategory { get; set; }
    }
}
