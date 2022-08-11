using JobSite.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace JobSite
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var passwordHasher = new PasswordHasher<User>();

            string adminEmail = "juranskiy59@gmail.com";
            string adminEmail1 = "zhuranskyifop@gmail.com";

            string password = "Frostland34";
            string password1 = "Frostlandnano34";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("employee") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("employee"));
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User { Email = adminEmail, UserName = adminEmail, EmailConfirmed = true, ShopCart = new ShopCart(), identityHomeList = 0 };
                IdentityResult result = await userManager.CreateAsync(admin, passwordHasher.HashPassword(admin, password));
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
            if (await userManager.FindByNameAsync(adminEmail1) == null)
            {
                User admin1 = new User { Email = adminEmail1, UserName = adminEmail1, EmailConfirmed = true, ShopCart = new ShopCart(), identityHomeList = 0 };
                IdentityResult result = await userManager.CreateAsync(admin1, passwordHasher.HashPassword(admin1, password1));
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin1, "admin");
                }
            }
        }
    }
}
