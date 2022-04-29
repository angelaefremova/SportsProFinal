using GBCSporting_LAIR.Data;
using GBCSporting_LAIR.Helpers;
using GBCSporting_LAIR.Interfaces;
using GBCSporting_LAIR.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GBCSporting_LAIR
{
  public class Startup
  {
    public IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration) { Configuration = configuration; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddRouting(options => {
        options.LowercaseUrls = true;
        options.AppendTrailingSlash = true;
      });

      services.Configure<CookiePolicyOptions>(options =>
      {
        // This lamda determines wheter user consent for non-essential cookies is needed for a 
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
      });

      services.AddMvc();

      services.AddDbContext<SportsProContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("SportsProContext")));

      services.AddTransient<IUnitOfWork, UnitOfWorkRepo>();
      services.AddScoped<IUnitOfWork, UnitOfWorkRepo>();
      var config = new AutoMapper.MapperConfiguration(cfg => {
        cfg.AddProfile(new Helper());
      });
      var mapper = config.CreateMapper();
      services.AddSingleton(mapper);

      services.AddHttpContextAccessor();

    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseDeveloperExceptionPage();
      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseRouting();
    }
  }
}
