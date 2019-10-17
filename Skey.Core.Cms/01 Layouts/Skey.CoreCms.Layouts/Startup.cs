using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using CoreCms.Application.Services;
using CoreCms.Ioc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Skey.Core.Framework.Common.Helper;
using Skey.CoreCms.Layouts.Middleware;

namespace Skey.CoreCms.Layouts
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
            ConfigurationHelper.Configure(Configuration);
            services.AddControllersWithViews();
            //�����֤Cookie��Ϣ

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
             .AddCookie(options =>
             {
                 options.LoginPath = new PathString("/Home/Login");
                 options.AccessDeniedPath = new PathString("/Home/CusError");
             });
            services.AddMvc().AddNewtonsoftJson().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            });

            RegisterServices(services);
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

            app.UseAuthentication();
            ////���Ȩ���м��, һ��Ҫ����app.UseAuthentication��
            app.UsePermission(new PermissionMiddlewareOption()
            {
                LoginAction = @"/Home/Login",
                NoPermissionAction = @"/Home/CusError",
                //������ϴ����ݿ��в�������û���ȫ��Ȩ��
                UserPerssions = new List<UserPermission>()
                          {
                    new UserPermission { Url = "/Home/Login", UserName = "100" },
                    new UserPermission { Url = "/User/Index", UserName = "100" },
                    new UserPermission { Url = "/Home/Privacy", UserName = "100" },
                },
                NoCheckPermission = new List<string> { "/home/login", "/home/reg", "/home/index" },
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });


            //��ʼ������
            var httpContext = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();

            ClientHelper.Configure(httpContext);
        }

        private void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            NativeInjectorBootStrapper.RegisterServices(services);
            ServiceLocator.SetServices(services.BuildServiceProvider());
        }
    }
}
