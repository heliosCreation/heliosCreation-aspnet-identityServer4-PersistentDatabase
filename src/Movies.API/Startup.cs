using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Movies.API.Data;
using Movies.API.Extensions.Services;
using Movies.API.Services;
using System.Reflection;

namespace Movies.API
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

            services.AddDbContext<MoviesContext>(options =>
                    options.UseInMemoryDatabase(("MoviesAPIContext")));

            services.AddBearerAuthenticationService();
            services.AddAuthorizationAndPoliciesService();

            services.AddHttpContextAccessor();

            services.AddSwaggerService();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<ILoggedInUserService, LoggedInUserService>();
            services.AddScoped<IApplicationUserProfileService, ApplicationUserProfileService>();
            services.AddScoped<IMovieRepository, MovieRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseCors(builder =>
           builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

                app.UseSwagger();
                app.UseSwaggerUI(opt =>
                {
                    opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie Api");
                    opt.RoutePrefix = string.Empty;
                });
            }


            app.UseHttpsRedirection();

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
