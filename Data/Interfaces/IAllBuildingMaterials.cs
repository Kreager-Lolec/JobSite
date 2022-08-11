using JobSite.Data.Models;
namespace JobSite.Data.Interfaces
{
    public interface IAllBuildingMaterials
    {
        IEnumerable<BuildingMaterial> AllBuildingMaterials { get; }
        IEnumerable<BuildingMaterial> GetFavBuildingMaterials { get; }
        BuildingMaterial GetCertainBuildingMaterial(Guid id);
    }
}
