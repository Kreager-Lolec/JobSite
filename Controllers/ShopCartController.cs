using JobSite.Data.Models;
using JobSite.Data.Interfaces;
using JobSite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using JobSite.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JobSite.Controllers
{
    [Authorize]
    public class ShopCartController : Controller
    {
        private readonly IAllBuildingMaterials _allBuildingMaterials;
        private readonly ApplicationDbContext appDBContent;
        private ShopCart currentShopCart;

        public ShopCartController(ApplicationDbContext appDBContent, IAllBuildingMaterials iAllBuildingMaterials)
        {
            _allBuildingMaterials = iAllBuildingMaterials;
            this.appDBContent = appDBContent;
        }
        [Route("ShopCart")]
        [Route("ShopCart/[controller]")]
        [Route("ShopCart/[controller]/[action]")]
        public IActionResult Index()
        {
            List<ShopCartItem> invalidShopItems = new List<ShopCartItem>();

            currentShopCart = GetShopCart();
            if (currentShopCart == null)
            {
                return RedirectToAction("Login", "Account");
            }
            List<ShopCartItem> cart = currentShopCart.ShopCartItems;
            foreach (var item in cart)
            {
                if (item.BuildingMaterial == null)
                {
                    invalidShopItems.Add(item);
                }
            }
            for (int i = 0; i < invalidShopItems.Count; i++)
            {
                cart.Remove(invalidShopItems[i]);
                appDBContent.Remove(invalidShopItems[i]);
            }
            if (cart == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var ShopCartModel = new ShopCartViewModel
                {
                    shopCartItems = cart
                };
                return View(ShopCartModel);
            }
        }

        [Route("ShopCart")]
        [Route("ShopCart/[controller]")]
        [Route("ShopCart/[controller]/[action]")]
        public IActionResult AddToCart(Guid id)
        {
            BuildingMaterial buildingMaterial = _allBuildingMaterials.GetCertainBuildingMaterial(id);
            currentShopCart = GetShopCart();
            if (currentShopCart == null)
            {
                if (User.Identity.IsAuthenticated)
                {

                }
                return RedirectToAction("Login", "Account");
            }
            else
            {
                List<ShopCartItem> cart = currentShopCart.ShopCartItems;
                if (!cart.Any() || !isExistBool(id, cart))
                {
                    ShopCartItem shopCartItem = new ShopCartItem()
                    {
                        BuildingMaterial = buildingMaterial,
                        Quantity = 1,
                        ShopCartId = currentShopCart.Id,
                        ShopCart = currentShopCart,
                        DateCreated = DateTime.Now,
                    };
                    appDBContent.ShopCartItems.Add(shopCartItem);
                }
                else
                {
                    int index = isExistInt(id, cart);
                    if (index != -1)
                    {
                        appDBContent.ShopCartItems.ToList()[index].Quantity++;
                    }
                    else
                    {
                        appDBContent.ShopCartItems.Add(new ShopCartItem
                        {
                            BuildingMaterial = _allBuildingMaterials.GetCertainBuildingMaterial(id),
                            Quantity = 1,
                            ShopCartId = currentShopCart.Id,
                            ShopCart = currentShopCart,
                        });
                    }
                }
                appDBContent.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public IActionResult RiseQuantity(Guid id)
        {
            appDBContent.ShopCartItems.First(c => c.Id == id).Quantity++;
            appDBContent.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult ReduceQuantity(Guid id)
        {
            if (appDBContent.ShopCartItems.First(c => c.Id == id).Quantity > 0)
            {
                appDBContent.ShopCartItems.First(c => c.Id == id).Quantity--;
                appDBContent.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult SetQuantity(Guid id, int Quantity)
        {
            appDBContent.ShopCartItems.First(c => c.Id == id).Quantity = Quantity;
            appDBContent.SaveChanges();
            return RedirectToAction("Index");
        }

        //[Route("remove/{id}")]
        public IActionResult Remove(Guid id)
        {
            currentShopCart = GetShopCart();
            List<ShopCartItem> cart = currentShopCart.ShopCartItems;
            ShopCartItem removeItem = cart.First(c => c.BuildingMaterial.Id == id);
            appDBContent.ShopCartItems.Remove(removeItem);
            appDBContent.SaveChanges();
            return RedirectToAction("Index");
        }

        private int isExistInt(Guid id, List<ShopCartItem> cart)
        {
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].BuildingMaterial.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

        private bool isExistBool(Guid id, List<ShopCartItem> cart)
        {
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].BuildingMaterial.Id.Equals(id))
                {
                    return true;
                }
            }
            return false;
        }
        private ShopCart GetShopCart()
        {
            var user = appDBContent.Users.Include(p => p.ShopCart).ThenInclude(c => c.ShopCartItems).ThenInclude(s => s.BuildingMaterial).Where(c => c.Id == User.GetUserId()).FirstOrDefaultAsync();
            if (user.Result == null)
            {
                return null;
            }
            else if (user != null)
            {
                return user.Result.ShopCart;
            }
            return null;
        }
        [AllowAnonymous]
        public IActionResult Order()
        {
            return View("OperationResult", new OperationResultViewModel() { textresult = "Функціонал в розробці" });
        }
    }
}
