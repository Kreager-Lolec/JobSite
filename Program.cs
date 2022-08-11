using Microsoft.AspNetCore;

namespace JobSite
{
    public class Program
    {
        public static void Main(string[] args)
            {
            CreateWebHostBuilder(args).Build().Run();
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().ConfigureKestrel((context, options) =>
            {
                options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(10);
            });
    }
}
