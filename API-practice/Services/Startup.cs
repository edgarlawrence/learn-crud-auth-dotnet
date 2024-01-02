using API_practice.Context;
using API_practice.Model;
using Microsoft.EntityFrameworkCore;

namespace API_practice.Services
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment()) 
            { 
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
