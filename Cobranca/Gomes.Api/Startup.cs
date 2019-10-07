using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Gomes.Domain.Context.Repository;
using Gomes.Repository.Context;
using Swashbuckle.AspNetCore;
using Microsoft.OpenApi.Models;

namespace Gomes.Api
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
            
            services.AddScoped<IRepositoryBilling, BillingRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            // 
            services.AddResponseCompression();
             services.AddSwaggerGen(c => {
                     c.SwaggerDoc("v1", new OpenApiInfo { Title = "Meu Desafio - API Cobrança", Version = "v1" });
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
