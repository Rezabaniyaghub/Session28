using AutoMapper;
using DataAccess;
using DataAccess.Entity;
using Domain.Abstracts;
using Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persentetion;
using Persentetion.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

var bulder = WebApplication.CreateBuilder(args);
bulder.Services.AddTransient<ISchoolRepository, SchoolRepository>();
bulder.Services.AddTransient<ISchoolService, SchoolService>();

bulder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
       bulder.Configuration.GetConnectionString("DefaultConnection")));
bulder.Services.AddDatabaseDeveloperPageExceptionFilter();


bulder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
bulder.Services.AddControllersWithViews();

IMapper mapper = MappingConfing.RegisterMaps().CreateMapper();
bulder.Services.AddSingleton(mapper);
bulder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


bulder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
bulder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Persentetion")));

bulder.Services.AddDatabaseDeveloperPageExceptionFilter();


var app = bulder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});

app.Run();