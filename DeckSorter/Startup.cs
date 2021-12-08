using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DeckSorter.DBRepository;
//Нужно при использовании обратного прокси-сервера
using Microsoft.AspNetCore.HttpOverrides;

namespace DeckSorter
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Получаем строку подключения к БД из файла appsettings.json
            string connection = Configuration.GetConnectionString("PostgreSQLLocalConnection");
            //string connection = Configuration.GetConnectionString("PostgreSQLExternalConnection");
            //Добавляем контекст DeckSorterContext в качестве сервиса в приложение
            services.AddDbContext<DeckSorterContext>(options => options.UseNpgsql(connection));

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Нужно для корректного взаимодействия с NGINX
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            //Включаем статические файлы
            app.UseStaticFiles();

            //ПВключаем маршрутизацию 
            app.UseRouting();

            //Устанавливаем маршрут по умолчанию и маршруты на основе атрибутов
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");
                endpoints.MapControllers();
            });
        }
    }
}
