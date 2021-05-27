using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SUO.EntityFramework.Core.Repositor.Demo.Context;
using SUO.EntityFramework.Core.Repository;
using SUO.EntityFramework.Core.Repository.Interface;
using SUO.Swagger;

namespace SUO.EntityFramework.Core.Repositor.Demo
{
    public class Startup
    {
        public Startup(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
           // Configuration = configuration;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                //.AddJsonFile("autofac.json")//读取autofac.json文件
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.RegisterServiceCollection<MyContext>();

            var data = Configuration["Data"];
            //两种方式读取
            var defaultcon = Configuration.GetConnectionString("DefaultConnection");
            var devcon = Configuration["ConnectionStrings:DevConnection"];


            List<SwaggerDoc> swaggerModels = Configuration.GetSection("Swagger:SwaggerDoc").Get<List<SwaggerDoc>>();
            List<SwaggerFile> swaggerFiles = Configuration.GetSection("Swagger:SwaggerFile").Get<List<SwaggerFile>>();
            swaggerFiles.ForEach(a => a.FilePath=Path.Combine(AppContext.BaseDirectory, a.FilePath));
            services.SwaggerConfigureServices(swaggerModels, swaggerFiles, null);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.SwaggerConfigure();
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
