using HackM.Models;
using HackM.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDifficultyMode,DifficultyMode>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IStatisticFactory, StatisticFactory>();
builder.Services.AddScoped<ICreateStatistic, CreateStatistic>();
builder.Services.AddScoped<IStatistics, Statistics>();
builder.Services.AddScoped<IMessageFactory, MessageFactory>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddScoped<IRPSGame, RpsGame>();
builder.Services.AddSingleton<IHealth, Heart>();
builder.Services.AddScoped<IGameValid, GameValid>();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => 
    {
        options.LoginPath = "/Auth/Login";
        options.LogoutPath = "/Auth/LogOut";
        options.AccessDeniedPath = "/";
        options.Cookie.Name = "AuthCookie";
    });
builder.Services.AddScoped<IAuthUser, AuthUser>();
builder.Services.AddScoped<ICreateUser,CreateUser>();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<IdentityUser,IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
