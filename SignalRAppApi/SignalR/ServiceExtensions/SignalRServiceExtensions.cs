using Microsoft.Extensions.DependencyInjection;
using SignalR.Services;
using SignalR.Services.Interfaces;

namespace SignalR.ServiceExtensions
{
    public static class SignalRServiceExtensions
    {
        public static IServiceCollection AddSignalRServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
