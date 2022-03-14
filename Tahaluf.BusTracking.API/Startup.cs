using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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
            services.AddControllers();
            services.AddScoped<IDbContext, DbContext>();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
