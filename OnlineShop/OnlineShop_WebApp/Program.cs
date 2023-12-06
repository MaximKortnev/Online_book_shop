using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Repositories;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop_WebApp.Interfaces;
using OnlineShop_WebApp.Repositories;
using OnlineShop_WebApp.Areas.Admin;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connection = builder.Configuration.GetConnectionString("online_shop");
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));
builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlServer(connection));

builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromHours(8);
    options.LoginPath = "/Auth/Login";
    options.LogoutPath = "/Auth/Logout";
    options.Cookie = new CookieBuilder { IsEssential = true };
});



builder.Services.AddTransient<IProductsRepository, ProductsDBRepository>();
builder.Services.AddTransient<ICartsRepository, CartsDBRepository>();
builder.Services.AddTransient<IOrdersRepository, OrdersDBRepository>();
builder.Services.AddTransient<IFavoritesRepository, FavoritesDBRepository>();
builder.Services.AddTransient<IComparisonRepository, ComparisonDBRepository>();
builder.Services.AddSingleton<IRolesRepository, InFileRolesRepository>();
builder.Services.AddSingleton<IUsersRepository, InFileUsersRepository>();
builder.Services.AddSingleton<IAdminUsersFunctions, AdminUsersFunctions>();





var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var userManager = services.GetRequiredService<UserManager<User>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    IdentityInitializer.Initialize(userManager, roleManager);

    SeedData.Initialize(services);
}
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
        name: "MyAreas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
        name: "Default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
