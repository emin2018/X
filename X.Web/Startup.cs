using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using X.Core.Repositories;
using X.Core.Services;
using X.Core.UnitOfWorks;
using X.Data.EntityFrameworkCore;
using X.Data.EntityFrameworkCore.Repositories;
using X.Data.EntityFrameworkCore.UnitOfWorks;
using X.Service.Services;

namespace X.Web
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
            services.AddAutoMapper(typeof(Startup));
            #region Generic Repository AddScoped
            /*AddScoped Generic yap�m�zda e�er bir interface ile kar��la��rsa onu ne ile �al��mas� gerekiti�ini belirliyor
             e�er ikinci bir interface ile kar��la��rsa ilk olu�turdu�unu kullan�yor yeniden olu�turmas� i�inde y�ntem var(services.AddTransient)
            fakat performans a��s�ndan bu daha iyi */
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service.Services.Service<>));
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPersonProductRelationService, PersonProductRelationService>();
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            #endregion
            services.AddDbContext<XDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:SqlConStr"].ToString(),ops=>ops.MigrationsAssembly("X.Data"));
            });
            services.AddControllersWithViews();
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
        }
    }
}
