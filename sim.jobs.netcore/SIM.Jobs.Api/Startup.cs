using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SIM.Jobs.Core.Interfaces.Repositories;
using SIM.Jobs.Core.Interfaces.Repositories.Shared;
using SIM.Jobs.Core.Interfaces.Services;
using SIM.Jobs.Core.Models.Shared;
using SIM.Jobs.Core.Services;
using SIM.Jobs.Infrastructure.Repositories;

namespace SIM.Jobs.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        private const string DefaultAssemblyNamesPrefix = "SIM";
        public IConfiguration Configuration { get; }
        protected virtual string AssemblyNamesPrefix
        {
            get
            {
                return DefaultAssemblyNamesPrefix;
            }
        }
        /// <summary>
        /// gets all assemblies
        /// </summary>
        /// <value></value>
        protected virtual IEnumerable<Assembly> ProjectAssemblies
        {
            get
            {
                var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(m => m.GetName().Name.StartsWith(AssemblyNamesPrefix, true, CultureInfo.InvariantCulture));
                return assemblies;
            }
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddLogging();
             //Add Swagger relates setting  
            
            services.AddSwaggerGen();
            services.AddScoped<IUnitOfWork, UnitOfWork>(serviceProvider =>
            {
                var connectionString = Configuration.GetConnectionString("DefaultConection");
                return new UnitOfWork(connectionString);
            });



            #region  Add Services
                services.AddScoped<IJobsService, JobsService>();
                services.AddScoped<IDepartmentsService, DepartmentsService>();
                services.AddScoped<ILocationsService, LocationsService>();
            #endregion

            #region  Add Repositories
                services.AddScoped<IJobsRepository, JobsRepository>();
                services.AddScoped<IDepartmentsRepository, DepartmentsRepository>();
                services.AddScoped<ILocationsRepository, LocationsRepository>();
            #endregion
            
            #region  SqlServer Config Section
            
      
            services.AddDbContext<DbContext> (options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConection")));
            // services.Configure<SQLServerDockerConfig>(Configuration.GetSection("SQLServerDockerConfig"));
            #endregion

            // Auto Mapper Configurations
            services.AddAutoMapper(ProjectAssemblies);
            services.AddControllers().AddNewtonsoftJson();
        }
        /// <summary>
        /// // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="logger"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        
          
            //PrepDB.PrepPopulation(app);
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();    
            app.UseSwaggerUI(c =>    
            {    
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Common Auth API");    
            }); 
        }
    }
}