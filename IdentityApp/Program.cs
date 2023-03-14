using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using IdentityApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using IdentityApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Controllers & Razor Page support
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Application DbContext
builder.Services.AddDbContext<ProductDbContext>(opts =>
{
    opts.UseSqlServer(
        builder.Configuration.GetConnectionString("IdentityAppData")
    );
});

// Force navigation via https
builder.Services.AddHttpsRedirection(opts => {
    opts.HttpsPort = 44350;
});

builder.Services.AddDbContext<IdentityDbContext>(opts => {
    opts.UseSqlServer(
        builder.Configuration.GetConnectionString("IdentityAppUserData"),
        opts => opts.MigrationsAssembly("IdentityApp")
    );
});

// Implementation of IEmailSender used by Identity
builder.Services.AddScoped<IEmailSender, ConsoleEmailSender>();

// Identity Properties
builder.Services.AddDefaultIdentity<IdentityUser>(opts => {
    opts.User.RequireUniqueEmail = false;                           // Default: false

    opts.Password.RequiredLength = 8;                               // Default: 6
    opts.Password.RequiredUniqueChars = 1;                          // Default: 1
    opts.Password.RequireNonAlphanumeric = true;                    // Default: true
    opts.Password.RequireLowercase = false;                         // Default: true
    opts.Password.RequireUppercase = false;                         // Default: true
    opts.Password.RequireDigit = false;                             // Default: true

    opts.SignIn.RequireConfirmedEmail = false;                      // Default: false
    opts.SignIn.RequireConfirmedPhoneNumber = false;                // Default: false
    opts.SignIn.RequireConfirmedAccount = true;                     // Default: false

    opts.Lockout.MaxFailedAccessAttempts = 5;                       // Default: 5
    opts.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);  // Default: 5 minutes
    opts.Lockout.AllowedForNewUsers = true;                         // Default: true

}).AddEntityFrameworkStores<IdentityDbContext>();

// Social Logins
builder.Services.AddAuthentication()
    .AddFacebook(opts => {
        opts.AppId = builder.Configuration["Facebook:AppId"];
        opts.AppSecret = builder.Configuration["Facebook:AppSecret"];
    });

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();
});

app.Run();
