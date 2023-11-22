using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Repositories;
using OnlineShop.Db;
using OnlineShop_WebApp.Interfaces;
using OnlineShop_WebApp.Repositories;
using OnlineShop_WebApp.Areas.Admin;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connection = builder.Configuration.GetConnectionString("online_shop");
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection), ServiceLifetime.Scoped);

builder.Services.AddScoped<IProductsRepository, ProductsDBRepository>();
builder.Services.AddSingleton<ICartsRepository, InFileCartsRepository>();
builder.Services.AddSingleton<IOrdersRepository, InFileOrdersRepository>();
builder.Services.AddSingleton<IFavoritesRepository, InFileFavoritesRepository>();
builder.Services.AddSingleton<IComparisonRepository, ComparisonRepository>();
builder.Services.AddScoped<IAdminProductsFunctions, AdminProductsFunctions>();
builder.Services.AddSingleton<IRolesRepository, InFileRolesRepository>();
builder.Services.AddSingleton<IAdminOrdersFunctions, AdminOrdersFunctions>();
builder.Services.AddSingleton<IUsersRepository, InFileUsersRepository>();
builder.Services.AddSingleton<IAdminUsersFunctions, AdminUsersFunctions>();
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
        name: "MyAreas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
        name: "Default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
