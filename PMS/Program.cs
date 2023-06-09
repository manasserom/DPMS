using DesignPatterns.Repository;
using DesignPatterns.Models;
using System.Collections.Generic;
using DesignPatterns.Models.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//Injection Context
var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<DpmsContext>(options => options.UseSqlServer(connectionString));
//builder.Services.AddDbContextPool<DpmsContext>(o => o.UseSqlServer("Server=DELL\\SQLEXPRESS; Database=DPMS; Trusted_Connection=true; TrustServerCertificate=true;"));

//Injection Repository
//builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
//builder.Services.AddTransient(typeof(DesignPatterns.Repository.IRepository<>), typeof(DesignPatterns.Repository.Repository<>)); ;
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//builder.Services.AddDbContext<DpmsContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
//});

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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
