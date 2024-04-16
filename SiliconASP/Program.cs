using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Helpers.MiddleWare;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddDefaultIdentity<UserEntity>(x =>
{
    x.User.RequireUniqueEmail = true;
    x.SignIn.RequireConfirmedEmail = false;
    x.Password.RequiredLength = 8;

}).AddEntityFrameworkStores<DataContext>();

builder.Services.ConfigureApplicationCookie(x =>
{
    x.Cookie.HttpOnly = true;
    x.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    x.ExpireTimeSpan = TimeSpan.FromHours(1);
    x.SlidingExpiration = true;
    x.LoginPath = "/signin";
    x.LogoutPath = "/signout";
});

builder.Services.AddScoped<AddressRepo>();
builder.Services.AddScoped<UserRepo>();
builder.Services.AddScoped<FeautreRepo>();
builder.Services.AddScoped<FeatureItemRepo>();
builder.Services.AddScoped<FeatureService>();
builder.Services.AddScoped<AddressService>();

var app = builder.Build();

app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseUserSessionValidation();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
