using Microsoft.Owin;
using MyBasicTaskManager.Repositories;
using Owin;
using Microsoft.Extensions.DependencyInjection;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using MyBasicTaskManager.Models.Infrastructure;

[assembly: OwinStartupAttribute(typeof(MyBasicTaskManager.Startup))]
namespace MyBasicTaskManager
{
    public partial class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IStaticDataRepository, StaticDataRepository>();
            services.AddScoped<ITasksRepository, TasksRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IStatisticsRepository, StatisticsRepository>();
            services.AddScoped<DatabaseModel, DatabaseModel>();


            services.AddControllersAsServices(typeof(Startup).Assembly.GetExportedTypes()
   .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition)
   .Where(t => typeof(IController).IsAssignableFrom(t)
      || t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)));
   //         services.AddControllersAsServices(typeof(Startup).Assembly.GetExportedTypes()
   //.Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition)
   //.Where(t => typeof(IController).IsAssignableFrom(t)
   //   || t.Name.EndsWith("Repository", StringComparison.OrdinalIgnoreCase)));
        }
        public void Configuration(IAppBuilder app)
        {
            var services = new ServiceCollection();
            ConfigureAuth(app);
            ConfigureServices(services);
            var resolver = new DefaultDependencyResolver(services.BuildServiceProvider());
            DependencyResolver.SetResolver(resolver);
        }
    }
    public class DefaultDependencyResolver : IDependencyResolver
    {
        protected IServiceProvider serviceProvider;

        public DefaultDependencyResolver(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public object GetService(Type serviceType)
        {
            return this.serviceProvider.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.serviceProvider.GetServices(serviceType);
        }
    }
    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddControllersAsServices(this IServiceCollection services,
           IEnumerable<Type> controllerTypes)
        {
            foreach (var type in controllerTypes)
            {
                services.AddTransient(type);
            }

            return services;
        }
    }
}
