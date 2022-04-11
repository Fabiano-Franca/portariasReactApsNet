using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using dSalarial.Data.Context;
using dSalarial.Data.Repositories;
using dSalarial.Domain.Interfaces;
using dSalarial.Domain.Interfaces.Services;
using dSalarial.Domain.Services;

namespace dSalarial.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(
                options => options.UseSqlite(Configuration.GetConnectionString("Default"))
            );

            services.AddScoped<IAtividadeRepo, AtividadeRepo>();
            services.AddScoped<IGeralRepo, GeralRepo>();
            services.AddScoped<IAtividadeService, AtividadeService>();

            services.AddControllers()
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    });
            services.AddSwaggerGen(c =>
            {
                //Define a versão da API
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "dSalarial.API", Version = "v1" });
            });
            //Controle de acesso de permissão de origem
            //Estamos permitindo que nosso front-end consiga fazer requisições na nossa API
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Defini se o ambiente DEVELOPMENT | PRODUCTION
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "dSalarial.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //Permitindo que todos os Headers, Métodos e Origens acessem a API
            app.UseCors(option => option.AllowAnyHeader()
                                        .AllowAnyMethod()
                                        .AllowAnyOrigin());

            //Define os Endpoints
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
