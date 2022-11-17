using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.EntityFramework;
using ClassLibrary.Repository.EF;
using ClassLibrary.RepositoryInterfaces;
using ClassLibrary.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace ReactApp
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
            services.AddCors(); 
            services.AddControllers();

            // In production, the React files will be served from this directory
            //Microsoft.AspNetCore.SpaServices.Extensions package
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

           

            //JWT authentication
            string key = Configuration.GetValue<string>("Settings:key");

            //Microsoft.AspNetCore.Authentication.JwtBearer package


            services.AddAuthentication(authenticationOptions =>
            {
                authenticationOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authenticationOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwtBearerOptions =>
                {
                    jwtBearerOptions.RequireHttpsMetadata = false;
                    jwtBearerOptions.SaveToken = true;
                    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });


            //add DbContext 
            services.AddEntityFrameworkSqlServer().AddDbContext<EcommerceContext>(
                 options => options.UseSqlServer(
                   Configuration.GetConnectionString("EcommerceConnection")));


            //specify implementation of IEcommerceService 
            //services registered with AddTransient are disposed after the request

            services.AddTransient<IEcommerceService, EcommerceService>(ctx =>
            {
                EcommerceContext context = ctx.GetService<EcommerceContext>();

                return new EcommerceService(new AccountRepository(context),
                                            new ProductRepository(context),
                                            new OrderRepository(context));
            });


            //film list service
            //services.AddEntityFrameworkSqlServer().AddDbContext<FilmContext>(
            // options => options.UseSqlServer(
            //   Configuration.GetConnectionString("EcommerceConnection")));

            //services.AddTransient<IFilmRepository, FilmRepository>(ctx =>
            //{
            //    FilmContext context = ctx.GetService<FilmContext>();
            //    return new FilmRepository(context);
            //});

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseSpaStaticFiles();
            app.UseRouting();

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
