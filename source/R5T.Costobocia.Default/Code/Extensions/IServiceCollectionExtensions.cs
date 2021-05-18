using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Lombardy;
using R5T.Ostrogothia;


namespace R5T.Costobocia.Default
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="OrganizationDirectoryNameProvider"/> implementation of <see cref="IOrganizationDirectoryNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddOrganizationDirectoryNameProvider(this IServiceCollection services,
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
        public static IServiceAction<IOrganizationDirectoryNameProvider> AddOrganizationDirectoryNameProviderAction(this IServiceCollection services,
            IServiceAction<IOrganizationProvider> organizationProviderAction)
        {
            var serviceAction = ServiceAction.New<IOrganizationDirectoryNameProvider>(() => services.AddOrganizationDirectoryNameProvider(
                organizationProviderAction));

            return serviceAction;
        }
        
        /// <summary>
        /// Adds the <see cref="OrganizationDirectoryPathProvider"/> implementation of <see cref="IOrganizationDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddOrganizationDirectoryPathProvider(this IServiceCollection services,
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
        public static IServiceAction<IOrganizationDirectoryPathProvider> AddOrganizationDirectoryPathProviderAction(this IServiceCollection services,
            IServiceAction<IOrganizationDirectoryNameProvider> organizationDirectoryNameProviderAction,
            IServiceAction<IOrganizationsDirectoryPathProvider> organizationsDirectoryPathProviderAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            var serviceAction = ServiceAction.New<IOrganizationDirectoryPathProvider>(() => services.AddOrganizationDirectoryPathProvider(
                organizationDirectoryNameProviderAction,
                organizationsDirectoryPathProviderAction,
                stringlyTypedPathOperatorAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="OrganizationsDirectoryNameProvider"/> implementation of <see cref="IOrganizationsDirectoryNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddOrganizationsDirectoryNameProvider(this IServiceCollection services)
        {
            services.AddSingleton<IOrganizationsDirectoryNameProvider, OrganizationsDirectoryNameProvider>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="OrganizationsDirectoryNameProvider"/> implementation of <see cref="IOrganizationsDirectoryNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IOrganizationsDirectoryNameProvider> AddOrganizationsDirectoryNameProviderAction(this IServiceCollection services)
        {
            var serviceAction = ServiceAction.New<IOrganizationsDirectoryNameProvider>(() => services.AddOrganizationsDirectoryNameProvider());
            return serviceAction;
        }
    }
}
