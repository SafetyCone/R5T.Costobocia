using System;

using R5T.Ostrogothia;
using R5T.Lombardy;

using R5T.T0062;
using R5T.T0063;


namespace R5T.Costobocia.Default
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="OrganizationDirectoryNameProvider"/> implementation of <see cref="IOrganizationDirectoryNameProvider"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IOrganizationDirectoryNameProvider> AddOrganizationDirectoryNameProviderAction(this IServiceAction _,
            IServiceAction<IOrganizationProvider> organizationProviderAction)
        {
            var serviceAction = _.New<IOrganizationDirectoryNameProvider>(services => services.AddOrganizationDirectoryNameProvider(
                organizationProviderAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="OrganizationDirectoryPathProvider"/> implementation of <see cref="IOrganizationDirectoryPathProvider"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IOrganizationDirectoryPathProvider> AddOrganizationDirectoryPathProviderAction(this IServiceAction _,
            IServiceAction<IOrganizationDirectoryNameProvider> organizationDirectoryNameProviderAction,
            IServiceAction<IOrganizationsDirectoryPathProvider> organizationsDirectoryPathProviderAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            var serviceAction = _.New<IOrganizationDirectoryPathProvider>(services => services.AddOrganizationDirectoryPathProvider(
                organizationDirectoryNameProviderAction,
                organizationsDirectoryPathProviderAction,
                stringlyTypedPathOperatorAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="OrganizationsDirectoryNameProvider"/> implementation of <see cref="IOrganizationsDirectoryNameProvider"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IOrganizationsDirectoryNameProvider> AddOrganizationsDirectoryNameProviderAction(this IServiceAction _)
        {
            var serviceAction = _.New<IOrganizationsDirectoryNameProvider>(services => services.AddOrganizationsDirectoryNameProvider());
            return serviceAction;
        }
    }
}
