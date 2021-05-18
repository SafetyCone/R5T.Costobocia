using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Bulgaria;
using R5T.Dacia;
using R5T.Lombardy;


namespace R5T.Costobocia.Bulgaria
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="OrganizationsDirectoryPathProvider"/> implementation of <see cref="IOrganizationsDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddOrganizationsDirectoryPathProvider(this IServiceCollection services,
            IServiceAction<IDropboxDirectoryPathProvider> dropboxDirectoryPathProviderAction,
            IServiceAction<IOrganizationsDirectoryNameProvider> organizationsDirectoryNameProviderAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            services
                .AddSingleton<IOrganizationsDirectoryPathProvider, OrganizationsDirectoryPathProvider>()
                .Run(dropboxDirectoryPathProviderAction)
                .Run(organizationsDirectoryNameProviderAction)
                .Run(stringlyTypedPathOperatorAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="OrganizationsDirectoryPathProvider"/> implementation of <see cref="IOrganizationsDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IOrganizationsDirectoryPathProvider> AddOrganizationsDirectoryPathProviderAction(this IServiceCollection services,
            IServiceAction<IDropboxDirectoryPathProvider> dropboxDirectoryPathProviderAction,
            IServiceAction<IOrganizationsDirectoryNameProvider> organizationsDirectoryNameProviderAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            var serviceAction = ServiceAction.New<IOrganizationsDirectoryPathProvider>(() => services.AddOrganizationsDirectoryPathProvider(
                dropboxDirectoryPathProviderAction,
                organizationsDirectoryNameProviderAction,
                stringlyTypedPathOperatorAction));

            return serviceAction;
        }
    }
}
