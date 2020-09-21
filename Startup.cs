using E_Commerce.Contexts;
using E_Commerce.Entities;
using E_Commerce.Interfaces;
using E_Commerce.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace E_Commerce
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
            services.AddControllersWithViews();
            services.AddScoped<ICategoryRepository, Categoryrepository>();
            services.AddScoped<IAdressRepository, AdressRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPhoneNumberrepository, PhoneNumberrepository>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddSession();
            services.AddDbContext<E_CommerceContext>();
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<E_CommerceContext>();
            services.AddAuthentication();

            services.ConfigureApplicationCookie(x =>
            {
                x.LoginPath = new PathString("/Home/AdminLogin");
                x.Cookie.Name = "ECOMMERCE";
                x.Cookie.HttpOnly = true;
                x.Cookie.SameSite = SameSiteMode.Strict;
                x.ExpireTimeSpan = System.TimeSpan.FromMinutes(60);
            }
                     );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager)
        {
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

            IdentityInitializer.CreateAdminUser(userManager,roleManager);

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession(); 
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

              
            });
        }
    }
}
