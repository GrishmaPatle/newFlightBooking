using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace FlightRes.Service
{
    public static class ServiceDiscoveryExtension
    {
        public static SerializationInfo ConsulAddress { get; private set; }

        public static IServiceCollection AddConsulConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulConfig =>
            {
                var address = configuration.GetSection("ServiceDiscovery").GetSection("Consul").GetSection("Url").Value;
                consulConfig.Address = new Uri(address);
            }));
            return services;
        }
        public static IApplicationBuilder UseConsul(this IApplicationBuilder app, IConfiguration configuration)
        {
            var consulClient = app.ApplicationServices.GetRequiredService<IConsulClient>();
            //var lifeTime = app.ApplicationServices.GetRequiredService<IApplicationLifetime>();
            //var registration = new AgentServiceRegistration()
            //{
            //    ID = configuration.GetSection(Constants.ServiceDiscovery).GetSection(Constants.Service).GetSection("Id").Value,
            //    Name = configuration.GetSection(Constants.ServiceDiscovery).GetSection("Service").GetSection("Name").Value,
            //    Address = configuration.GetSection(Constants.ServiceDiscovery).GetSection("Service").GetSection("Host").Value,
            //    Port = Convert.ToInt32(configuration.GetSection("ServiceDiscovery").GetSection("Service").GetSection("Port").Value),
            //};

            var registrations = getRegistrationDetails(configuration);
            if (registrations.Count > 0)
            {
                foreach (var registration in registrations)
                {
                    consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
                    consulClient.Agent.ServiceRegister(registration).ConfigureAwait(true);
                }
            }
            //consulClient.Agent.ServiceDeregister("UserServiceId").ConfigureAwait(true);
            //consulClient.Agent.ServiceDeregister("AdminServiceId").ConfigureAwait(true);
            //consulClient.Agent.ServiceDeregister("AuthServiceId").ConfigureAwait(true);
            return app;
        }
        private static List<AgentServiceRegistration> getRegistrationDetails(IConfiguration configuration) =>
       configuration.GetSection("ServiceDiscovery").GetSection("Service").GetChildren().ToList()?.Select(x => new AgentServiceRegistration()
       {
           ID = x["Id"],
           Name = x["Name"],
           Address = x["Host"],
           Port = Convert.ToInt32(x["Port"]),
       }).ToList();
    }
}
