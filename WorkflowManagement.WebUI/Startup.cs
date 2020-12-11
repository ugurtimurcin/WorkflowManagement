using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WorkflowManagement.DataAccess.Concrete.EntityFrameworkCore.Context;
using WorkflowManagement.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using FluentValidation.AspNetCore;
using AutoMapper;
using WorkflowManagement.Business.DependencyInjectionContainer;
using WorkflowManagement.WebUI.CustomCollectionExtensions;

namespace WorkflowManagement.WebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddContainerWithDependencies();
            services.AddDbContext<WorkflowManagementContext>();
            services.AddIdentityConfiguration();
            services.AddAutoMapper(typeof(Startup));
            services.AddValidator();
            services.AddControllersWithViews().AddFluentValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStatusCodePagesWithReExecute("/Home/StatusCode", "?code={0}");

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            IdentityInitializer.SeedData(userManager, roleManager).Wait();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area}/{controller=Home}/{action=Index}/{id?}"
                    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
