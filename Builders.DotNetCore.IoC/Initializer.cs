using Builders.DotNetCore.Domain.Interfaces;
using Builders.DotNetCore.Domain.Interfaces.Repositories;
using Builders.DotNetCore.Domain.Interfaces.Services;
using Builders.DotNetCore.Domain.Services;
using Builders.DotNetCore.Infrastructure.Implementation;
using Builders.DotNetCore.Infrastructure.Services;
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
