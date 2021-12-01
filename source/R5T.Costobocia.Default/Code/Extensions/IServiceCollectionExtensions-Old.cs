using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Lombardy;
using R5T.Ostrogothia;


namespace R5T.Costobocia.Default
{
    public static partial class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="OrganizationDirectoryNameProvider"/> implementation of <see cref="IOrganizationDirectoryNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddOrganizationDirectoryNameProvider_Old(this IServiceCollection services,
            IServiceAction<IOrganizationProvider> organizationProviderAction)
        {
            services
                .AddSingleton<IOrganizationDirectoryNameProvider, OrganizationDirectoryNameProvider>()
                .Run(organizationProviderAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="OrganizationDirectoryNameProvider"/> implementation of <see cref="IOrganizationDirectoryNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IOrganizationDirectoryNameProvider> AddOrganizationDirectoryNameProviderAction_Old(this IServiceCollection services,
            IServiceAction<IOrganizationProvider> organizationProviderAction)
        {
            var serviceAction = ServiceAction.New<IOrganizationDirectoryNameProvider>(() => services.AddOrganizationDirectoryNameProvider_Old(
                organizationProviderAction));

            return serviceAction;
        }
        
        /// <summary>
        /// Adds the <see cref="OrganizationDirectoryPathProvider"/> implementation of <see cref="IOrganizationDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddOrganizationDirectoryPathProvider_Old(this IServiceCollection services,
            IServiceAction<IOrganizationDirectoryNameProvider> organizationDirectoryNameProviderAction,
            IServiceAction<IOrganizationsDirectoryPathProvider> organizationsDirectoryPathProviderAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            services
                .AddSingleton<IOrganizationDirectoryPathProvider, OrganizationDirectoryPathProvider>()
                .Run(organizationDirectoryNameProviderAction)
                .Run(organizationsDirectoryPathProviderAction)
                .Run(stringlyTypedPathOperatorAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="OrganizationDirectoryPathProvider"/> implementation of <see cref="IOrganizationDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IOrganizationDirectoryPathProvider> AddOrganizationDirectoryPathProviderAction_Old(this IServiceCollection services,
            IServiceAction<IOrganizationDirectoryNameProvider> organizationDirectoryNameProviderAction,
            IServiceAction<IOrganizationsDirectoryPathProvider> organizationsDirectoryPathProviderAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            var serviceAction = ServiceAction.New<IOrganizationDirectoryPathProvider>(() => services.AddOrganizationDirectoryPathProvider_Old(
                organizationDirectoryNameProviderAction,
                organizationsDirectoryPathProviderAction,
                stringlyTypedPathOperatorAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="OrganizationsDirectoryNameProvider"/> implementation of <see cref="IOrganizationsDirectoryNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddOrganizationsDirectoryNameProvider_Old(this IServiceCollection services)
        {
            services.AddSingleton<IOrganizationsDirectoryNameProvider, OrganizationsDirectoryNameProvider>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="OrganizationsDirectoryNameProvider"/> implementation of <see cref="IOrganizationsDirectoryNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IOrganizationsDirectoryNameProvider> AddOrganizationsDirectoryNameProviderAction_Old(this IServiceCollection services)
        {
            var serviceAction = ServiceAction.New<IOrganizationsDirectoryNameProvider>(() => services.AddOrganizationsDirectoryNameProvider_Old());
            return serviceAction;
        }
    }
}
