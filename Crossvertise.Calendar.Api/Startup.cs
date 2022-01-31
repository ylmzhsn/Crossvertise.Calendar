namespace Crossvertise.Calendar.Api
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;

    using Crossvertise.Calendar.Service.Business.Abstract;
    using Crossvertise.Calendar.Service.Business.Concrete;
    using Crossvertise.Calendar.Service.Data.Abstract;
    using Crossvertise.Calendar.Service.Data.Concrete;
    using Crossvertise.Calender.Data;
    using Crossvertise.Calender.Data.Abstract;

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
            //Just need to change connection string once the app is running data will be created by the migration manager from the seed data
            services.AddDbContext<ApplicationContext>
            (
                options => options.UseSqlServer
                (
                    Configuration.GetConnectionString("DefaultConnection"),
                    optionsBuilder => optionsBuilder.MigrationsAssembly("Crossvertise.Calendar.Api")
                )
            );

            services.AddScoped<IApplicationContext, ApplicationContext>();
            services.AddScoped<IAppointmentDataService, AppointmentDataService>();
            services.AddScoped<IAppointmentService, AppointmentService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Crossvertise.Calendar.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Crossvertise.Calendar.Api v1"));
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
