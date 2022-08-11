using JobSite.Data.Interfaces;
using JobSite.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JobSite.Data.Repository
{
    public class BuildingMaterialRepository : IAllBuildingMaterials
    {
        private readonly ApplicationDbContext appDBContent;

        public BuildingMaterialRepository(ApplicationDbContext appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<BuildingMaterial> AllBuildingMaterials => appDBContent.BuildingMaterials.Include(c => c.Caterogy);
        public IEnumerable<BuildingMaterial> GetFavBuildingMaterials => appDBContent.BuildingMaterials.Where(p => p.isFavourite).Include(c => c.Caterogy);
        public BuildingMaterial GetCertainBuildingMaterial(Guid buildingMaterialId) => appDBContent.BuildingMaterials.First(p => p.Id == buildingMaterialId);
    }
}
