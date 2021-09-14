using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Emaritna.DAL.Context;
using Microsoft.OpenApi.Models;
using Emaritna.DAL.Entity.Users;
using Emaritna.DAL.IUnitOfWork;
using Emaritna.DAL.UnitOfWork;
using AutoMapper;
 using Microsoft.IdentityModel.Tokens;
using System.Text;
 using UsersManagement.Bll.Mapper;
using UsersManagement.Bll.IServices;
using UsersManagement.Bll.Services;
using UsersManagement.Bll.DTO;

namespace Emaritna.API
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
            services.AddControllers();

            #region Configer Database 
            services.AddDbContext<EmaritnaContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("EmaritnaConnection")));

            #endregion

            #region Idenity
            services.AddIdentity<ApplicationUser, IdentityRole>().
                AddEntityFrameworkStores<EmaritnaContext>();
            #endregion

            #region Swagger 
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Emaritna Api", Version = "v1" });

            });
            #endregion


            #region DAL UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            #region Service 
            services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
            services.AddScoped<IUserClaimsService, UserClaimsService>();
            services.AddScoped<IUsersManagementService, UsersManagementService>();
            #endregion

            #region Auto Mapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
               
                mc.AddProfile(new UsersMappingProfile());
            });

            

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            #endregion


            #region Configer app setting from appseting.json to model 
            services.Configure<ApplicationSettingData>(Configuration.GetSection("ApplicationSettingData"));
            #endregion

            string JWTKey = Configuration.GetSection("ApplicationSettingData").GetSection("JwtToken").Value;
            #region JWT setting 
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";

            }).AddJwtBearer("JwtBearer" , JwtBearerOptions =>
            {
                JwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(5)
                };

            });
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Emaritna Api");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            #region Sure Of Data base 
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<EmaritnaContext>();
                context.Database.Migrate();
            }

            #endregion
        }
    }
}
