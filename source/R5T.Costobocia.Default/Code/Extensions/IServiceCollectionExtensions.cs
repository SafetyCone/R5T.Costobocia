using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Lombardy;
using R5T.Ostrogothia;

using R5T.T0063;


namespace R5T.Costobocia.Default
{
    public static partial class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="OrganizationsDirectoryNameProvider"/> implementation of <see cref="IOrganizationsDirectoryNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddOrganizationsDirectoryNameProvider(this IServiceCollection services)
        {
            services.AddSingleton<IOrganizationsDirectoryNameProvider, OrganizationsDirectoryNameProvider>();

            return services;
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
                .Run(organizationDirectoryNameProviderAction)
                .Run(organizationsDirectoryPathProviderAction)
                .Run(stringlyTypedPathOperatorAction)
                .AddSingleton<IOrganizationDirectoryPathProvider, OrganizationDirectoryPathProvider>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="OrganizationDirectoryNameProvider"/> implementation of <see cref="IOrganizationDirectoryNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddOrganizationDirectoryNameProvider(this IServiceCollection services,
            IServiceAction<IOrganizationProvider> organizationProviderAction)
        {
            services
                .Run(organizationProviderAction)
                .AddSingleton<IOrganizationDirectoryNameProvider, OrganizationDirectoryNameProvider>();

            return services;
        }
    }
}
