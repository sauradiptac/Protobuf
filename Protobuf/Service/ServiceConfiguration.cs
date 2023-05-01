using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Service.IService;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Service
{
    internal static class ServiceConfiguration
    {
        internal static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IResponseService, ResponseService>();
            services.AddSingleton<IProtobufService>(protobufService => new ProtobufService(protobufService.GetService<IResponseService>()));
        }
    }
}
