using educae.identidade.App.Data;
using educae.identidade.App.Extensions;
using EstartandoDevsWebApiCore.Identidade;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace src.Configuration;

public static class IdentityConfig
{
    public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AutenticacaoDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("IdentityConnection")));

        services.AddDefaultIdentity<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddErrorDescriber<IdentityMensagensPortugues>()
            .AddEntityFrameworkStores<AutenticacaoDbContext>()
            .AddDefaultTokenProviders();

        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 5;
        });

        services.AddJwtConfiguration(configuration);
        
        return services;
    }
}