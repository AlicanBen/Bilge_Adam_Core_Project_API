using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bilge_Adam_Core_Project.BLL;
using Bilge_Adam_Core_Project.BLL.Abstract;
using Bilge_Adam_Core_Project.BLL.Concreate;
using Bilge_Adam_Core_Project.Dal.Concreate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Bilge_Adam_Core_Project.Restful_API
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
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });
            //var conn = Configuration.GetConnectionString("xqRoJ1FKnq");
            //services.AddDbContext<BilgeAdamCoreProjectContext>(options => options.UseMySql(conn));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin());
            if (env.IsDevelopment())
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
