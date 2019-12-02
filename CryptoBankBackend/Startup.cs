using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoBankBackend.Core.Interfaces.Repositories;
using CryptoBankBackend.Core.Interfaces.Services;
using CryptoBankBackend.Core.Services;
using CryptoBankBackend.Infrastructure.Context;
using CryptoBankBackend.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using CryptoBankBackend.Web.Profiles;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using AutoMapper;
using CryptoBankBackend.Middlewares;
using CryptoBankBackend.Core.Interfaces;
using CryptoBankBackend.Infrastructure.Notifications;

namespace CryptoBankBackend
{
    public class Startup
    {
        private readonly string _allowSpecificOrigins = "_allowSpecificOrigins";

        #region ----- PROPERTIES ------------------------------------------------------

        public IConfiguration Configuration { get; }

        #endregion

        #region ----- CONSTRUCTOR -----------------------------------------------------

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion

        #region ----- CONFIGURATION ---------------------------------------------------

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Register configuration.
            services.AddSingleton(Configuration);

            // Register notification.
            services.AddTransient<INotificationService, NotificationService>();

            // Register repositories.
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IOperationRepository, OperationRepository>();

            // Register services.
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IOperationService, OperationService>();

#if DEBUG
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(Configuration["SQL:ConnectionString:Staging"],
                optionsBuilder =>
                {
                    optionsBuilder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                    optionsBuilder.MigrationsAssembly("CryptoBankBackend.Infrastructure");
                }));
#else
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(Configuration["SQL:ConnectionString:Prod"],
                optionsBuilder =>
                {
                    optionsBuilder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                    optionsBuilder.MigrationsAssembly("CryptoBankBackend.Infrastructure");
                }));
#endif

            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
            });

            // Register Asp Core components.
            services.AddCors(options =>
            {
                options.AddPolicy(_allowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            services.AddLocalization();
            services.AddAutoMapper(typeof(DefaultProfile));
            services.AddMvc(options =>
            {
                options.MaxModelValidationErrors = 50;
            })
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Error;
            });

            // Register the Swagger generator, defining 1 or more Swagger documents.
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Xamarin Formation API",
                    Description = "Backend for Xamarin Formation project.",
                    Contact = new OpenApiContact
                    {
                        Name = "Stephan Arnas",
                        Email = "stephan.arnas@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/stephan-arnas/"),
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
#pragma warning disable CS0618 // https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/1269
                c.DescribeAllEnumsAsStrings();
#pragma warning restore CS0618
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                // Dpecifying the Swagger JSON endpoint.
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Xamarin Formation API V1");
                c.RoutePrefix = string.Empty;  // Set Swagger UI at apps root
            });

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseCors(_allowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }

        #endregion    
    }
}
