using CoreCms.Application.Interfaces;
using CoreCms.Application.Services;
using CoreCms.DbRepository;
using CoreCms.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection; 

namespace CoreCms.Ioc
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //请求层
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //服务层
            services.AddSingleton<ILoginService, LoginService>();
            services.AddSingleton<ILearningService, LearningService>();
            services.AddSingleton<ILogService, LogService>();

            //数据层
            services.AddSingleton<IAccountInterface, AccountRepository>();
            services.AddSingleton<ILearningInfoInterface, LearningInfoRepository>();
            services.AddSingleton<ILearningTypeInterface, LearningTypeRepository>();
            services.AddSingleton<ILogModelsInterface, LogModelsRepository>();

        }
    }
}
