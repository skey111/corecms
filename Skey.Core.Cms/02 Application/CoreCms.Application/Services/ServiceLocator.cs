
using System;
namespace CoreCms.Application.Services
{
    public class ServiceLocator
    {
        public static IServiceProvider Services { get; private set; }

        public static void SetServices(IServiceProvider services)
        {
            Services = services;
        }
    }
}
