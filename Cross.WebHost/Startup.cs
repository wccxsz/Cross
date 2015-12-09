using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Cross.WebHost.Common;
using Cross.WebHost.Db;
using Microsoft.AspNet.Cors.Infrastructure;
using Microsoft.Data.Entity;

namespace Cross.WebHost
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        public Startup(IApplicationEnvironment applicationEnvironment)
        {
            // Below code demonstrates usage of multiple configuration sources. For instance a setting say 'setting1'
            // is found in both the registered sources, then the later source will win. By this way a Local config
            // can be overridden by a different setting while deployed remotely.
            var builder = new ConfigurationBuilder()
                .SetBasePath(applicationEnvironment.ApplicationBasePath)
                .AddJsonFile("config.json")
                //All environment variables in the process's context flow in as configuration values.
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<CrossContext>(options =>
                {
                    options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]);
                });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.WithOrigins("http://example.com");
                });
            });
            //添加跨域访问
            services.AddCors(options =>
            {
                var policy = new CorsPolicy();
                policy.Headers.Add("*");
                policy.Methods.Add("get,post");
                policy.Origins.Add("http://localhost:1337/");
                policy.SupportsCredentials = true;
                options.AddPolicy("mypolicy", policy);
            });

            services.AddMvc();

            // Add memory cache services
            services.AddCaching();

            // Add session related services.
            services.AddSession();

            


            //// Add application services.
            //services.AddTransient<IEmailSender, AuthMessageSender>();
            //services.AddTransient<ISmsSender, AuthMessageSender>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Debug);

            // StatusCode pages to gracefully handle status codes 400-599.
            app.UseStatusCodePagesWithRedirects("~/Home/StatusCodePage");

            // Display custom error page in production when error occurs
            // During development use the ErrorPage middleware to display error information in the browser
            app.UseDeveloperExceptionPage();

            app.UseDatabaseErrorPage();

            // Add the runtime information page that can be used by developers
            // to see what packages are used by the application
            // default path is: /runtimeinfo
            app.UseRuntimeInfoPage();

            Configure2(app);
        }


        public void Configure2(IApplicationBuilder app)
        {
            // Configure Session.
            app.UseSession();

            // Add static files to the request pipeline
            app.UseStaticFiles();

            // Add cookie-based authentication to the request pipeline
            //app.UseIdentity();
            // Add MVC to the request pipeline
            app.UseMvc(routes =>
            {

                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new {controller = "Home", action = "Index"});
            });
        }
    }
}
