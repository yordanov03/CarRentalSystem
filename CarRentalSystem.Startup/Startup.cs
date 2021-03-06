using CarRentalSystem.Application;
using CarRentalSystem.Domain;
using CarRentalSystem.Infrastructure;
using CarRentalSystem.Web;
using CarRentalSystem.Web.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CarRentalSystem.Startup
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
            services.AddHttpContextAccessor();
            services.AddDomain();
            services.AddInfrastructure(this.Configuration);
            services.AddApplication(this.Configuration);
            services.AddWebComponents();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CarRentalSystem.Startup", Version = "v1" });
            });
            services.AddCors();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarRentalSystem.Startup v1"));
            }

            app.UseValidationExceptionHandler();

            app.UseCors(b =>
            {
                b.AllowAnyHeader();
                b.AllowAnyOrigin();
                b.AllowAnyMethod();
            });

                app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            }).Initialize();


        }
    }
}
