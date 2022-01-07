﻿using System.Net.Mime;
using Catalyte.Apparel.API.Filters;
using Catalyte.Apparel.Data;
using Catalyte.Apparel.Data.Context;
using Catalyte.Apparel.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Catalyte.Apparel.API
{
    public class Startup
    {
        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDataServices(Configuration);
            services.AddProviders();
            services.AddAutoMapper(typeof(MapperProfile));

            //services.AddAuthentication()
            //    .AddGoogle(options =>
            //    {
            //        // === GOOGLE AUTH W/O SECRETS MANAGER (USED FOR PROJECT -> EASIER TO MANAGE) ===
            //        //options.ClientId = Constants.GOOGLE_CLIENT_ID;
            //        //options.ClientSecret = Constants.GOOGLE_CLIENT_SECRET;

            //        // === GOOGLE AUTH WITH SECRETS MANAGER (BEST PRACTICE -> MORE INVOLVED) ===
            //        //IConfigurationSection googleAuthNSection =
            //        //    Configuration.GetSection("Authentication:Google");

            //        //options.ClientId = googleAuthNSection["ClientId"];
            //        //options.ClientSecret = googleAuthNSection["ClientSecret"];
            //    });            //services.AddAuthentication()
            //    .AddGoogle(options =>
            //    {
            //        // === GOOGLE AUTH W/O SECRETS MANAGER (USED FOR PROJECT -> EASIER TO MANAGE) ===
            //        //options.ClientId = Constants.GOOGLE_CLIENT_ID;
            //        //options.ClientSecret = Constants.GOOGLE_CLIENT_SECRET;

            //        // === GOOGLE AUTH WITH SECRETS MANAGER (BEST PRACTICE -> MORE INVOLVED) ===
            //        //IConfigurationSection googleAuthNSection =
            //        //    Configuration.GetSection("Authentication:Google");

            //        //options.ClientId = googleAuthNSection["ClientId"];
            //        //options.ClientSecret = googleAuthNSection["ClientSecret"];
            //    });

            services.AddControllers(options =>
            {
                options.Filters.Add(new HttpResponseExceptionFilter());
            })
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = context =>
                    {
                        var result = new BadRequestObjectResult(context.ModelState);
                        result.ContentTypes.Add(MediaTypeNames.Application.Json);
                        result.ContentTypes.Add(MediaTypeNames.Application.Xml);
                        return result;
                    };
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Catalyte.Apparel.API", Version = "v1" });
            });

            //Enable CORS
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApparelCtx db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalyte.Apparel.API v1"));

                //Enable CORS
                app.UseCors(options => options.WithOrigins().AllowAnyMethod().AllowAnyHeader());
            }
            if (env.IsProduction())
            {
                //Enable CORS
                app.UseCors(options => options.WithOrigins().AllowAnyMethod().AllowAnyHeader());
            }

            // Resets data on API startup
            db.Database.ExecuteSqlRaw("DROP SCHEMA public CASCADE; CREATE SCHEMA public;");
            db.Database.EnsureCreated();

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
