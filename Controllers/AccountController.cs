using JobSite.Data;
using JobSite.Data.Models;
using JobSite.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobSite.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationDbContext _appDBContext;

        public AccountController(ApplicationDbContext appDBContent, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appDBContext = appDBContent;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new() { UserName = model.Email, Email = model.Email, ShopCart = new ShopCart() { ShopCartItems = new List<ShopCartItem>() }, identityHomeList = 0 };
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Password);
                await _appDBContext.SaveChangesAsync();
                if (result.Succeeded)
                {
                    // генерация токена для пользователя
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Action(
                        "ConfirmEmail",
                        "Account",
                        new { userId = user.Id, code = code },
                        protocol: HttpContext.Request.Scheme);
                    EmailService emailService = new();
                    await emailService.SendEmailAsync(model.Email, "Confirm your account",
                        $"Підтвердіть реєстрацію, перейшовши по посиланню: <a href='{callbackUrl}'>Підтвердити електронну пошту</a>");
                    await _userManager.AddToRoleAsync(user, "user");

                    return View("OperationResult", new OperationResultViewModel() { textresult = "Для завершення реєстрації перевірте електронну пошту і перейдіть по посиланню, вказаному в письмі" });
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View("Error");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
                return RedirectToAction("Index", "Home");
            else
                return View("Error");
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            _signInManager.SignOutAsync();
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    ModelState.AddModelError("", "Такого користувача не існує");
                }
                else if (model.Email == null)
                {
                    return Redirect(model.ReturnUrl);
                }
                else if (user != null)
                {
                    if (!await _userManager.IsEmailConfirmedAsync(user))
                    {
                        ModelState.AddModelError(string.Empty, "Ви не підтвердили свою електронну пошту");
                        return View(model);
                    }
                    else
                    {
                        var result =
                            await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, false);
                        if (result.Succeeded)
                        {
                            // проверяем, принадлежит ли URL приложению
                            if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                            {
                                return Redirect(model.ReturnUrl);
                            }
                            else
                            {
                                return RedirectToAction("Index", "Home");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Неправильний логін та (або) пароль");
                        }
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            User tempUser = _appDBContext.Users.First(c => c.Id == User.GetUserId());
            if (tempUser != null)
            {
                model.Id = tempUser.Id;
                model.Email = tempUser.Email;
            }
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(tempUser.Id);
                if (user != null)
                {
                    IdentityResult result =
                        await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return View("OperationResult", new OperationResultViewModel() { textresult = "Пароль успішно змінений." });
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Користувача не знайдено");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpGet]

        public IActionResult ConfirmPerson()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmPerson(ConfirmPersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    return View("OperationResult", new OperationResultViewModel() { textresult = "Даного користувача не знайдено" });
                }
                else if (user != null)
                {
                    var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var callbackUrl = Url.Action(
        "ResetPassword",
        "Account",
        new { email = user.Email, code = code },
        protocol: HttpContext.Request.Scheme);
                    EmailService emailService = new();
                    await emailService.SendEmailAsync(user.Email, "Confirm your person",
                        $"Підтвердіть зміну пароля, перейшовши по посиланню: <a href='{callbackUrl}'>Підтвердити зміну пароля</a>");
                    return View("OperationResult", new OperationResultViewModel() { textresult = "Для зміни пароля перевірте електронну пошту і перейдіть по посиланню, вказаному в письмі." });
                }
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string email, string code)
        {
            ResetPasswordViewModel model = new() { Email = email, Code = code };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("ResetPassword", model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return View("OperationResult", new OperationResultViewModel() { textresult = "Помилка зкидування паролю." });
            }
            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                return View("OperationResult", new OperationResultViewModel() { textresult = "Ваш пароль успішно змінений." });
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View("ResetPassword", model);
        }
    }
}
