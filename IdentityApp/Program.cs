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
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ProductDbContext>(opts =>
{
    opts.UseSqlServer(
        builder.Configuration.GetConnectionString("IdentityAppData")
    );
});

builder.Services.AddHttpsRedirection(opts => {
    opts.HttpsPort = 44350;
});

builder.Services.AddDbContext<IdentityDbContext>(opts => {
    opts.UseSqlServer(
        builder.Configuration.GetConnectionString("IdentityAppUserData"),
        opts => opts.MigrationsAssembly("IdentityApp")
    );
});

builder.Services.AddScoped<IEmailSender, ConsoleEmailSender>();

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<IdentityDbContext>();

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