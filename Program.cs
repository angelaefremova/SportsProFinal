using GBCSporting_LAIR.Models;
using GBCSporting_LAIR.Data;
using Microsoft.EntityFrameworkCore;
using GBCSporting_LAIR.Helpers;
using GBCSporting_LAIR.Interfaces;
using GBCSporting_LAIR.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();

builder.Services.AddRouting(options => {
  // Enable usability of lower case letter in the route
  options.LowercaseUrls = true;
  // Append the slash at the end of the route
  options.AppendTrailingSlash = true;
});

// IMPORTANT: Adding the Connection string, which links to the Database
builder.Services.AddDbContext<SportsProContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SportsProContext")));

builder.Services.AddTransient<IUnitOfWork, UnitOfWorkRepo>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();

var config = new AutoMapper.MapperConfiguration(cfg => {
  cfg.AddProfile(new Helper());
});
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();