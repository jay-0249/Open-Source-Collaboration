using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Phase1_Projects_Backend.Models;
using Phase1_Projects_Backend.Models.Repositories;
using Phase1_Projects_Backend.Services;
using Microsoft.EntityFrameworkCore;
namespace Phase1_Projects_Backend
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
            string cons = Configuration.GetConnectionString("ConnectionStr");
            services.AddDbContext<ProjectDbContext>(options => options.UseSqlServer(cons));
            services.AddScoped<ProjectDbContext>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectService, ProjectService>();

            //The following code creates two CORS policies
            services.AddCors(options =>
            {
                options.AddPolicy("withoutHeaderPolicy",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200", "http://localhost:54230");
                    });
                options.AddPolicy("withHeaderPolicy",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200", "http://localhost:54230")
                                                                            .AllowAnyHeader()
                                                                            .AllowAnyMethod();
                    });
            });
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Phase1_Projects_Backend", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Phase1_Projects_Backend v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //Add this line if you want to use cors
            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
