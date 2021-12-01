using System;

using R5T.Bulgaria;
using R5T.Lombardy;

using R5T.T0062;
using R5T.T0063;


namespace R5T.Costobocia.Bulgaria
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="OrganizationsDirectoryPathProvider"/> implementation of <see cref="IOrganizationsDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IOrganizationsDirectoryPathProvider> AddOrganizationsDirectoryPathProviderAction(this IServiceAction _,
            IServiceAction<IDropboxDirectoryPathProvider> dropboxDirectoryPathProviderAction,
            IServiceAction<IOrganizationsDirectoryNameProvider> organizationsDirectoryNameProviderAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            var serviceAction = _.New<IOrganizationsDirectoryPathProvider>(services => services.AddOrganizationsDirectoryPathProvider(
                dropboxDirectoryPathProviderAction,
                organizationsDirectoryNameProviderAction,
                stringlyTypedPathOperatorAction));

            return serviceAction;
        }
    }
}
