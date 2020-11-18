using EnterpriseCenterWeb.Algos;
using EnterpriseCenterWeb.Models;
using EnterpriseCenterWeb.Services.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Reflection;

namespace EnterpriseCenterWeb
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
            services.AddControllersWithViews();

            services.AddDbContext<EnterpriseCenterContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("EnterpriseCenterDatabase")));

            services.AddSingleton(typeof(ILogService), new LogToFileService(Directory.GetCurrentDirectory()));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                    {
                        Email = "raf.buko@gmail.com",
                        Name = "EnterpriseCenter : API",
                        Url = new System.Uri("https://www.github.com/RaBuko/"),
                    },
                    Title = "EnterpriseCenter : API",
                    Version = "v1",
                    Description = "API for EnterpriseCenter"
                });

                var xmlCommentFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentFile);
                //c.IncludeXmlComments(xmlCommentsFullPath);
            });

            services.AddTransient<AlgosService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
