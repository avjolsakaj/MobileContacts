using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using FluentValidation.AspNetCore;
using MC.DAL.Context;
using MC.DTO;
using MC.WebApi.Filters;
using MC.WebApi.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace MC.WebApi
{
#pragma warning disable 1591

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
            // Register the Swagger generator, defining 1 or more Swagger documents
            _ = services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Mobile Contact API",
                    Description = "Web Api for MC application",
                    Contact = new OpenApiContact
                    {
                        Name = "MC - Mobile Contacts",
                        Email = "avjolsakaj@outlook.com"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under MC",
                    }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "MC Authorization header using the Bearer scheme.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "bearer",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "MC"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new List<string>()
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            DependencyInjection.Inject(services);

            // Cors Enable for everything
            // TODO: change this when finished
            _ = services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithExposedHeaders("X-Total-Count"));
            });

            _ = services.AddDbContext<MCContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MCDb"), sqlOptions =>
                    sqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)));

            _ = services.AddControllers(options => options.Filters.Add(typeof(ValidationFilterAttribute)))
                .AddNewtonsoftJson()
                .AddFluentValidation(fv =>
                {
                    _ = fv.RegisterValidatorsFromAssemblyContaining<IBaseDTO>();
                    fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                _ = app.UseDeveloperExceptionPage();
            }

            _ = app.UseHttpsRedirection();

            _ = app.UseStaticFiles();

            // Use Cors
            _ = app.UseCors("CorsPolicy");

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            _ = app.UseSwagger();
            //app.UseSwagger(c => c.SerializeAsV2 = true);

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.) specifying the Swagger
            // JSON endpoint.
            _ = app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MC API V1"));

            _ = app.UseRouting();

            _ = app.UseAuthentication();
            _ = app.UseAuthorization();

            _ = app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }

#pragma warning restore 1591
}
