
using Infrastructure;
using Infrastructure.Repositories.TenantsRepo;
using Infrastructure.Repositories.UsersRepo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();

builder.Services.AddDbContext<TenantDbContext>(opt =>
  opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    sqlServerOptionsAction: options =>
    {
        options.MigrationsAssembly("Application");
    }));

builder.Services.AddHttpClient();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<ITenantRepository, TenantRepository>();
 
var app = builder.Build(); 

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.Run();
