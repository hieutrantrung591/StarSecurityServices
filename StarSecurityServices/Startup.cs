using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StarSecurityServices.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading;
using System.Threading.Tasks;

namespace StarSecurityServices
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var stringConnectdb = Configuration.GetConnectionString("StarSecurity");
            services.AddSession();
            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.Conventions.AddPageRoute("/Areas/Customer/Views/Home/Index", "");
            });
            services.AddDbContext<StarSecurityDBContext>(options => options.UseSqlServer(stringConnectdb), ServiceLifetime.Scoped);
            services.AddSingleton<HtmlEncoder>(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.All }));
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddMemoryCache();
            services.AddHttpContextAccessor();
            services.AddAuthentication("CookieAuthentication")
                .AddCookie("CookieAuthentication", config =>
                {
                    config.Cookie.Name = "UserLoginCookie";
                    config.ExpireTimeSpan = TimeSpan.FromDays(1);
                    config.LoginPath = "/login.html";
                    config.LogoutPath = "/logout.html";
                    config.AccessDeniedPath = "/not-found.html";
                });
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings, only this changes expiration
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromDays(150);
                options.ExpireTimeSpan = TimeSpan.FromDays(150);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSession();   // <== login
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Who are you?
            app.UseAuthentication();

            // Are you allowed?
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Admin",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                  );
                endpoints.MapControllerRoute(
                    name: "Customer",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                  );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");
            });

            app.Use(async (context, next) =>
            {
                var currentThreadCulture = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
                currentThreadCulture.NumberFormat = NumberFormatInfo.InvariantInfo;

                Thread.CurrentThread.CurrentCulture = currentThreadCulture;
                Thread.CurrentThread.CurrentUICulture = currentThreadCulture;

                await next();
            });
        }
    }
}
