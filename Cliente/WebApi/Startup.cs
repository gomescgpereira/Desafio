using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Context.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Repository.Contexto.Entities;
using Microsoft.EntityFrameworkCore;
using Gomes.Infra.Contexto.Data;
using Domain.Context.Services;
using ApplicationService;
using Swashbuckle.AspNetCore;
using Microsoft.OpenApi.Models;



namespace WebApi
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("InMemoryDatabase"));
            

            services.AddCors();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IClientApplicationService, ClientApplicationService>();

             services.AddResponseCompression();
             services.AddSwaggerGen(c => {
                     c.SwaggerDoc("v1", new OpenApiInfo { Title = "Meu Desafio - API Cliente", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
             app.UseResponseCompression();
            app.UseSwagger();
            app.UseSwaggerUI( c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
