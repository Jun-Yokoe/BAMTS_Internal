using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAMTS_Internal_WebAPIService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private readonly string MyAllowSpecificOrigins = "BAMTSWebAPIServiceAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy(this.MyAllowSpecificOrigins, builder =>
            {
                builder.AllowAnyOrigin()    // すべてのオリジンからの CORS 要求を許可
                       .AllowAnyMethod()    // すべての HTTP メソッドを許可
                       .AllowAnyHeader();   // すべての作成者要求ヘッダーを許可
            })); //★追加（だいがいそうやけど、ネットワーク越しにアクセスされる場合に必要）★
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BAMTS_Internal_WebAPIService", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //    app.UseSwagger();
            //    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BAMTS_Internal_WebAPIService v1"));
            //}
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BAMTS_Internal_WebAPIService v1"));

            app.UseCors(this.MyAllowSpecificOrigins); //★追加（だいがいそうやけど、ネットワーク越しにアクセスされる場合に必要）★
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/excel", async context =>
            //    {
            //        ExcelExport ee = new ExcelExport();
            //        await ee.Export(context);
            //    });


            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
