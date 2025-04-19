using JobSite.Data;
using JobSite.Data.Interfaces;
using JobSite.Data.Models;
using JobSite.Data.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;


namespace JobSite
{
    public class Startup
    {
        private readonly IConfigurationRoot _configuration;
        public Startup(IHostEnvironment hostingEnvironment)
        {
            _configuration = new ConfigurationBuilder().SetBasePath(hostingEnvironment.ContentRootPath).AddJsonFile("appsettings.json").Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            try
            {
                string connection = _configuration.GetConnectionString("DefaultConnection");
                services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));
                services.AddDatabaseDeveloperPageExceptionFilter();
                services.AddTransient<IAllBuildingMaterials, BuildingMaterialRepository>();
                services.AddTransient<ICaterogyGoods, CategoryRepository>();
                services.AddTransient<IDeliveries, DeliveryRepository>();
                services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
                services.AddDistributedMemoryCache();
                services.AddMvc(options => options.EnableEndpointRouting = false);
                services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.LoginPath = new PathString("/Account/Login");
                        options.AccessDeniedPath = new PathString("/Account/Login");
                        options.LogoutPath = new PathString("/Account/Logout");
                    });
                services.AddIdentity<User, IdentityRole>(opts =>
                {
                    opts.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+абвгґдеєжзиіїйклмнопрстуфхцчшщьюяАБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯйцукенгшщзхъфывапролджэячсмитьбюЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ ";
                    opts.User.RequireUniqueEmail = true;
                    opts.Password.RequireNonAlphanumeric = false;
                    opts.SignIn.RequireConfirmedEmail = true;
                }
                )
                    .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();
                services.AddSession(options =>
                            {
                                options.Cookie.HttpOnly = true;
                                options.Cookie.IsEssential = true;
                            });
                services.AddRazorPages();

                services.AddControllersWithViews();
            }
            catch (Exception)
            {

                throw;
            }
        }
        async public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            try
            {
                // Configure the HTTP request pipeline.


                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    app.UseMigrationsEndPoint();
                }
                else
                {
                    app.UseExceptionHandler("/Error");
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                    app.UseHsts();
                }
                app.UseHttpsRedirection();

                app.UseSession();

                app.UseStatusCodePages();

                app.UseStaticFiles();

                app.UseRouting();

                app.UseAuthentication();

                app.UseAuthorization();

                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
                    routes.MapRoute(
                        name: "shopcart",
                        template: "{controller=ShopCart}/{action=Index}/{id?}");
                    routes.MapRoute(
                        name: "BuyCommodity",
                        template: "{controller=ShopCart}/{action=Buy}/{id?}");
                    routes.MapRoute(
                        name: "CommodityList",
                        template: "{controller=BuildingMaterials}/{action=List}/{id?}");
                    routes.MapRoute(
                        name: "ChangePassword",
                        template: "{controller=Account}/{action=RedirectToPasswordPage}/{id?}");
                });
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                    // Перевіряємо, чи база пуста
                    var databaseCreator = db.Database.GetService<IRelationalDatabaseCreator>();
                    if (!databaseCreator.HasTables())
                    {
                        db.Database.Migrate();              // Створює таблиці згідно з усіма міграціями
                        DBObjects.Initial(db);              // Ініціалізує тестовими даними (якщо потрібно)
                    }

                    // Ініціалізація ролей і користувачів
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                    var rolesManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                    await RoleInitializer.InitializeAsync(userManager, rolesManager);
                }

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
