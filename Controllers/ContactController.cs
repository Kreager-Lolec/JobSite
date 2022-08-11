using JobSite.Data;
using JobSite.Data.Models;
using JobSite.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace JobSite.Controllers
{
    public class ContactController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationDbContext _appDBContext;

        public ContactController(ApplicationDbContext appDBContent, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appDBContext = appDBContent;
        }

        [HttpGet]
        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ContactResult(ContactUsViewModel model)
        {
            List<User> admins = (List<User>)await _userManager.GetUsersInRoleAsync("admin");
            if (ModelState.IsValid)
            {
                EmailService emailService = new EmailService();
                foreach (var item in admins)
                {
                    await emailService.SendEmailAsync(item.Email, "", $"Користувач з іменем: {model.name}" + "\n" + $"телефоном: {model.phone}" + "\n" + $"та електронною адресою: {model.email}" + "\n" +  $"надіслав наступне повідомлення:" + "\n" + $"{model.message}");
                }
                return View("OperationResult", new OperationResultViewModel() { textresult= "Ваше повідомлення успішно надіслано, адміністратор зв'яжеться з вами у найближчий час." });
            }
            return View("ContactUs", model);
        }
    }
}
