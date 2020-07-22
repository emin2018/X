using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using X.API.Filters;
using X.Core.Repositories;
using X.Core.Services;
using X.Core.UnitOfWorks;
using X.Data.EntityFrameworkCore;
using X.Data.EntityFrameworkCore.Repositories;
using X.Data.EntityFrameworkCore.UnitOfWorks;
using X.Service.Services;
using X.API.Extensions;

namespace X.API
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
            services.AddScoped(typeof(NotFoundFilter<>));
            services.AddAutoMapper(typeof(Startup));
            #region Generic Repository AddScoped
            /*AddScoped Generic yapýmýzda eðer bir interface ile karþýlaþýrsa onu ne ile çalýþmasý gerekitiðini belirliyor
             eðer ikinci bir interface ile karþýlaþýrsa ilk oluþturduðunu kullanýyor yeniden oluþturmasý içinde yöntem var(services.AddTransient)
            fakat performans açýsýndan bu daha iyi */
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
            
            services.AddControllers();
            //attribute kontrolü kapatma kontrolü kendin saðlama
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",new OpenApiInfo
                {
                    Title = "Swagger API",
                    Description = "X Project Swagger",
                    Version = "v1"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCustomException();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json","Swagger API");
                options.RoutePrefix = "";
            });
        }
    }
}
