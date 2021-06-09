using Azure.Storage.Blobs;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


namespace BenMedica.Api
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
            services.AddControllers()
                .AddNewtonsoftJson(options => {
                    //options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
                })
            .AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null);

            services.AddMvc()
        .ConfigureApiBehaviorOptions(options => {
            options.SuppressModelStateInvalidFilter = true;
        }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            //services.Configure<ApiBehaviorOptions>(options => {
            //    options.InvalidModelStateResponseFactory = actionContext => {
            //        var actionExecutingContext = actionContext as Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext;

            //        if (actionContext.ModelState.ErrorCount > 0 && actionExecutingContext.ActionArguments.Count == actionContext.ActionDescriptor.Parameters.Count) {
            //            return new BadRequestObjectResult(actionContext.ModelState);
            //        }
            //        return new BadRequestObjectResult(actionContext.ModelState);
            //    };

            //});


            //services.Configure<ApiBehaviorOptions>(options =>
            //{
            //    options.InvalidModelStateResponseFactory = context =>
            //    {
            //        var problemDetails = new ValidationProblemDetails(context.ModelState);

            //        var result = new BadRequestObjectResult(problemDetails);

            //        result.ContentTypes.Add("application/problem+json");
            //        result.ContentTypes.Add("application/problem+xml");

            //        return result;
            //    };
            //});
            //services.AddProblemDetails();

            //services.AddProblemDetails(setup => {
            //    //setup.IncludeExceptionDetails = _ => !Environment.IsDevelopment();
            //    setup.Map<ErrorSchema>(exception => new ErrorSchema {
            //        ErrorOccured = exception.ErrorOccured,
            //        ErrorCode= exception.ErrorCode
            //        //Title = exception.Message,
            //        //Detail = exception.Description,
            //        //Balance = exception.Balance,
            //        //Status = StatusCodes.Status403Forbidden,
            //        //Type = exception.Type
            //    }) ;

            services.AddTransient<SmartAltsResponse>();



            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BenMedica.Api", Version = "v1" });
                c.IncludeXmlComments(xmlPath);
            });
            services.AddSingleton(x => new BlobServiceClient(Configuration.GetValue<string>("AzureBlobStorageConnectionString")));
            services.AddSingleton<IBlobService, BlobServices>();
            //services.ConfigureApiBehaviorOptions(options => {
            //    options.SuppressUseValidationProblemDetailsForInvalidModelStateResponses = false;
            //});
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseProblemDetails();
        }
    }
}
