using educae.biblioteca.infra.Data;
using educae.comunicacao.infra.Data;
using educae.contas.infra.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Configuration;

namespace webapi.Configuration; 

public static class ApiConfig
{
    private const string ConexaoBancoDeDados = "educaeConnection";
    private const string PermissoesDeOrigem = "_permissoesDeOrigem";

    public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();

        services.AddDbContext<UsuarioContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString(ConexaoBancoDeDados)));

        services.AddDbContext<ComunicacaoContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString(ConexaoBancoDeDados)));
        
        services.AddDbContext<BibliotecaContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString(ConexaoBancoDeDados)));

        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

        services.AddCors(options =>
        {
            // options.AddPolicy(PermissoesDeOrigem,
            // policy =>{
            //     policy.WithOrigins("http://www.conectedu.com",
            //                        "http://conectedu.com");
            // });

            options.AddPolicy(PermissoesDeOrigem,
                builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });
    }

    public static void UseApiConfiguration(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwaggerConfiguration();
            app.UseSwagger();
            app.UseSwaggerUI();

        }

        app.MapControllers();
        // app.UseAuthConfiguration();
        app.UseHttpsRedirection();
    }
}