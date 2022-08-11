using Microsoft.AspNetCore.Mvc;
using JobSite.Data.Interfaces;
using JobSite.ViewModels;

namespace JobSite.Controllers
{
    public class BuildingMaterialsController: Controller
    {
        private readonly IAllBuildingMaterials _allBuildingMaterials;
        private readonly ICaterogyGoods _allCategories;

        public BuildingMaterialsController(IAllBuildingMaterials iAllBuildingMaterials, ICaterogyGoods iCategoryBuildingMaterials)
        {
            _allBuildingMaterials = iAllBuildingMaterials;
            _allCategories = iCategoryBuildingMaterials;
        }

        [Route("BuildingMaterials")]
        [Route("BuildingMaterials/[controller]")]
        [Route("BuildingMaterials/[controller]/[action]")]
        public ViewResult List()
        {
            BuildingMaterialViewModel viewModel = new BuildingMaterialViewModel();
            viewModel.AllBuildingMaterials = _allBuildingMaterials.AllBuildingMaterials;
            viewModel.currentCategory = "Будівельні матеріали";
            return View(viewModel);
        }
    }
}
