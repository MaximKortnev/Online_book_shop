using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShopWebApp.Repositories;
using OnlineShopWebApp.Interfaces;
using OnlineShop.DataBase.Interfaces;
using Serilog;
using OnlineShopWebApp.Areas.Admin;
using OnlineShop.DataBase;
using Microsoft.EntityFrameworkCore;

namespace OnlineShopWebApp
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
			string connection = Configuration.GetConnectionString("online_shop");
			services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));

			services.AddSingleton<IProductsRepository, ProductsDBRepository>();
            services.AddSingleton<ICartsRepository, InFileCartsRepository>();
            services.AddSingleton<IOrdersRepository, InFileOrdersRepository>();
            services.AddSingleton<IFavoritesRepository, InFileFavoritesRepository>();
            services.AddSingleton<IComparisonRepository, ComparisonRepository>();
            services.AddSingleton<IAdminProductsFunctions, AdminProductsFunctions>();
            services.AddSingleton<IRolesRepository, InFileRolesRepository>();
            services.AddSingleton<IAdminOrdersFunctions, AdminOrdersFunctions>();
            services.AddSingleton<IUsersRepository, InFileUsersRepository>();
            services.AddSingleton<IAdminUsersFunctions, AdminUsersFunctions>();
            services.AddControllersWithViews();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseSerilogRequestLogging();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
                endpoints.MapControllerRoute(
                    name: "MyAreas",
                    pattern: "{area:exists}/{controller=Administrator}/{action=Index}/{id?}");

				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
