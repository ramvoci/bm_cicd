using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;

namespace BenMedica.Api {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers()
                .AddNewtonsoftJson(options => {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
                    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                    options.SerializerSettings.DateFormatString = "MM/dd/yyyy HH:mm";
                })
            .AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null);

            services.AddMvc()
                    .ConfigureApiBehaviorOptions(options => {
                            options.SuppressModelStateInvalidFilter = true;
                            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddTransient<SmartAltsResponse>();
            
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            services.AddSwaggerGen(c => {
              c.SwaggerDoc("v1", new OpenApiInfo { Title = "BenMedica.Api", Version = "v1" });
              c.IncludeXmlComments(xmlPath);
              c.MapType<decimal>(()=> new OpenApiSchema { Type="number", Format="decimal" });
                //c.MapType<DateTime>(() => new OpenApiSchema {
                //    Type = "string",
                //    Format = "date-time",
                //    Example = new OpenApiString(DateTime.UtcNow.ToString("o"))
                //});
                //c.UseAllOfToExtendReferenceSchemas();
                //c.SchemaFilter<RequireValueTypePropertiesSchemaFilter>();
            });
            //services.AddSwaggerGenNewtonsoftSupport();
            services.AddSingleton(x => new BlobServiceClient(Configuration.GetValue<string>("AzureBlobStorageConnectionString")));
            services.AddSingleton<IBlobService, BlobServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();            
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BenMedica v1");               
                c.RoutePrefix = "api/swagger";
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "api/swagger");

            app.UseRewriter(option);

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
