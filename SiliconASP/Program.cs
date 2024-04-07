using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddDefaultIdentity<UserEntity>(x =>
{
    x.User.RequireUniqueEmail = true;
    x.SignIn.RequireConfirmedEmail = false;
    x.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<DataContext>();

builder.Services.AddScoped<AddressRepo>();
builder.Services.AddScoped<UserRepo>();
builder.Services.AddScoped<FeautreRepo>();
builder.Services.AddScoped<FeatureItemRepo>();
builder.Services.AddScoped<FeatureService>();
builder.Services.AddScoped<AddressService>();
//builder.Services.AddAuthentication("AuthCookie").AddCookie("AuthCookie", x =>
//{
//    x.LoginPath = "/signin";
//    x.ExpireTimeSpan = TimeSpan.FromMinutes(60);
//});

var app = builder.Build();

app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
