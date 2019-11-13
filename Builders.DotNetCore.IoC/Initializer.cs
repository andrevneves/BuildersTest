using Builders.DotNetCore.WebApi.Domain.Interfaces;
using Builders.DotNetCore.WebApi.Domain.Interfaces.Repositories;
using Builders.DotNetCore.WebApi.Domain.Interfaces.Services;
using Builders.DotNetCore.WebApi.Domain.Services;
using Builders.DotNetCore.WebApi.Infrastructure.Implementation;
using Builders.DotNetCore.WebApi.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Builders.DotNetCore.IoC
{
    public static class Initializer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IBinaryTreeService, BinaryTreeService>();
            services.AddSingleton<INodeRepository, NodeRepository>();
            services.AddSingleton<ICorreiosService, CorreiosService>();
            
        }
    }
}
