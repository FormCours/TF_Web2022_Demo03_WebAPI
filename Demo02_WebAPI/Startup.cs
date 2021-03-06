using Demo02_WebAPI.DAL;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo02_WebAPI
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
         // Ajout de la negociation du contenu (Autorisation du Json & XML
         services.AddControllers(c =>
         {
            c.RespectBrowserAcceptHeader = true; // Traite le "Accept" du Header
            c.ReturnHttpNotAcceptable = true; // Erreur 406 si le format n'est pas support?
         }).AddXmlDataContractSerializerFormatters(); // Ajout le format "XML"


         services.AddSwaggerGen(c =>
         {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo02_WebAPI", Version = "v1" });
         });

         services.AddDbContext<DataContext>(
            builder => builder.UseSqlServer(Configuration.GetConnectionString("default"))
         );

      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo02_WebAPI v1"));
         }

         app.UseHttpsRedirection();

         app.UseRouting();

         app.UseAuthorization();

         app.UseEndpoints(endpoints =>
         {
            endpoints.MapControllers();
         });
      }
   }
}
