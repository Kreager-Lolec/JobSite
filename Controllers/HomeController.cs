using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using JobSite.Data.Interfaces;
using JobSite.ViewModels;
using Microsoft.AspNetCore.Identity;
using JobSite.Data.Models;
using System.Security.Claims;
using JobSite.Data;

namespace JobSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllBuildingMaterials _allBuildingMaterials;
        private readonly IDeliveries _allDeliveries;
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _appDBContext;
        private Guid userGuid;

        public HomeController(IAllBuildingMaterials iAllBuildingMaterials, IDeliveries iAllDeliveries, ApplicationDbContext appDBContent)
        {
            _allBuildingMaterials = iAllBuildingMaterials;
            _allDeliveries = iAllDeliveries;
            _appDBContext = appDBContent;
        }
        public IActionResult Index()
        {
            var homeCommodity = new HomeViewModel()
            {
                AllBuildingMaterials = _allBuildingMaterials.AllBuildingMaterials,
                AllDeliveries = _allDeliveries.AllDeliveries,
                IdentifierType = 0,
            };
            if (User.Identity.IsAuthenticated)
            {
                userGuid = Guid.Parse(User.GetUserId());
                ViewBag.userGuid = userGuid.ToString();
            }
            return View(homeCommodity);
        }

        public Guid GetUserId()
        {
            userGuid = Guid.Parse(_userManager.GetUserId(HttpContext.User));
            return userGuid;
        }

        public IActionResult IndexDelivery()
        {
            var homeCommodity = new HomeViewModel()
            {
                AllBuildingMaterials = _allBuildingMaterials.AllBuildingMaterials,
                AllDeliveries = _allDeliveries.AllDeliveries,
                //IdentifierType = IdentifierType,
            };
            return View(homeCommodity);
        }
    }
}
