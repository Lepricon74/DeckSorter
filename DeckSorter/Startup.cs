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
//����� ��� ������������� ��������� ������-�������
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
            //�������� ������ ����������� � �� �� ����� appsettings.json
            string connection = Configuration.GetConnectionString("PostgreSQLLocalConnection");
            //string connection = Configuration.GetConnectionString("PostgreSQLExternalConnection");
            //��������� �������� DeckSorterContext � �������� ������� � ����������
            services.AddDbContext<DeckSorterContext>(options => options.UseNpgsql(connection));

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //����� ��� ����������� �������������� � NGINX
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            //�������� ����������� �����
            app.UseStaticFiles();

            //��������� ������������� 
            app.UseRouting();

            //������������� ������� �� ��������� � �������� �� ������ ���������
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
