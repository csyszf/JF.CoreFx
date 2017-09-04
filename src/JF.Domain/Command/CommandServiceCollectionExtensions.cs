using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace JF.Domain.Command
{
    public static class CommandServiceCollectionExtensions
    {
        public static IServiceCollection AddCommand<CmdHandlerType>(
            this IServiceCollection services
            )
        {
            return services.AddCommand(typeof(CmdHandlerType));
        }

        public static IServiceCollection AddCommand(
            this IServiceCollection services,
            Type cmdHandlerType)
        {
            foreach (var i in cmdHandlerType.GetTypeInfo().GetInterfaces())
            {
                var gtd = i.GetGenericTypeDefinition();
                if (gtd.Equals(typeof(ICommandHandler<,>)) || gtd.Equals(typeof(ICommandHandler<>)))
                {
                    services.AddScoped(i, cmdHandlerType);
                }
            }
            return services;
        }
    }
}
