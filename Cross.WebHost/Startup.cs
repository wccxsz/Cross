using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;
using Microsoft.AspNet.Identity.EntityFramework;
using Cross.DbFactory;
using Microsoft.AspNet.Identity;
using System.IO;
using Microsoft.AspNet.DataProtection;

namespace Cross.WebHost
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            // Setup configuration sources.
            var builder = new ConfigurationBuilder()
                .SetBasePath(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                //All environment variables in the process's context flow in as configuration values.
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<IdentityUser<int>, IdentityRole<int>>(options =>
            {
                options.Cookies.ApplicationCookieAuthenticationScheme = "ApplicationCookie";
                options.Cookies.ApplicationCookie.AuthenticationScheme = IdentityCookieOptions.ApplicationCookieAuthenticationType = "ApplicationCookie";
                options.Cookies.ApplicationCookie.DataProtectionProvider = new DataProtectionProvider(new DirectoryInfo("C:\\Github\\Identity\\artifacts"));
                options.Cookies.ApplicationCookie.CookieName = "Interop";
                options.Cookies.ApplicationCookie.AccessDeniedPath = "/Home/AccessDenied";
            })      
            
            .AddDefaultTokenProviders();

            services.AddMvc();

            // Add memory cache services
            services.AddCaching();

            // Add session related services.
            services.AddSession();

            services.AddEntityFramework()
                .AddNpgsql()
                .AddDbContext<Cross.DbFactory.CrossContext>(options =>
                {
                    options.UseNpgsql(Configuration["Data:DefaultConnection:ConnectionString"]);
                });


            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyMethod();
                    builder.AllowAnyOrigin();
                    builder.AllowAnyHeader();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(minLevel: LogLevel.Warning);

            // Configure Session.
            app.UseSession();

            // Add static files to the request pipeline
            app.UseStaticFiles();

            app.UseIdentity();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Login" });

                routes.MapRoute(
                    name: "api",
                    template: "Api/{controller}/{action}/{id?}");
            });
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
