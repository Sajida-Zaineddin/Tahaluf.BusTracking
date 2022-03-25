using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tahaluf.BusTracking.Core.Common;
using Tahaluf.BusTracking.Core.Repository;
using Tahaluf.BusTracking.Core.Service;
using Tahaluf.BusTracking.Infra.Common;
using Tahaluf.BusTracking.Infra.Repository;
using Tahaluf.BusTracking.Infra.Service;

namespace Tahaluf.BusTracking.API
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


            services.AddCors(corsOptions =>
            {
                corsOptions.AddPolicy("x",
                builder =>
                {
                    //builder.WithOrigins("http://127.0.0.1:4200", "http://localhost:4200", "https://localhost:4200")
                    // .AllowAnyHeader()
                    // .AllowAnyMethod();


                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });


            services.AddControllers();
            services.AddScoped<IDbContext, DbContext>();
            //Aboutus
            services.AddScoped<IAboutusRepository, AboutusRepository>();
            services.AddScoped<IAboutusService, AboutusService>();
            //AboutusEditor
            services.AddScoped<IAboutusEditorRepository, AboutusEditorRepository>();
            services.AddScoped<IAboutusEditorService, AboutusEditorService>();
            //Attendance
            services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            services.AddScoped<IAttendanceService, AttendanceService>();
            //Bus
            services.AddScoped<IBusRepository, BusRepository>();
            services.AddScoped<IBusService, BusService>();
            //Contactus
            services.AddScoped<IContactusRepository, ContactusRepository>();
            services.AddScoped<IContactusService, ContactusService>();
            //Role
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();
            //Route
            services.AddScoped<IRouteRepository, RouteRepository>();
            services.AddScoped<IRouteService, RouteService>();
            //Student
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentService, StudentService>();
            //Testimonial
            services.AddScoped<ITestimonialRepository, TestimonialRepository>();
            services.AddScoped<ITestimonialService, TestimonialService>();
            //User
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            //Website
            services.AddScoped<IWebsiteRepository, WebsiteRepository>();
            services.AddScoped<IWebsiteService, WebsiteService>();
            //WebsiteFooter
            services.AddScoped<IWebsitefooterRepository, WebsitefooterRepository>();
            services.AddScoped<IWebsitefooterService, WebsitefooterService>();
            //WebsiteHome
            services.AddScoped<IWebsitehomeRepository, WebsitehomeRepository>();
            services.AddScoped<IWebsitehomeService, WebsitehomeService>();
            //Login
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<ILoginService, LoginService>();

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    //ValidIssuer = "http://localhost:5000",
                    //ValidAudience = "http://localhost:5000",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("welcome to eqbal site"))
                };
            });
        }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();


            app.UseCors("x");


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
