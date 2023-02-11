using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Bulgaria;
using R5T.Bulgaria.Standard;
using R5T.Dacia;
using R5T.Lombardy;
using R5T.Ostrogothia;
using R5T.Visigothia;

using R5T.Costobocia.Default;
using R5T.Costobocia.Bulgaria;


namespace R5T.Costobocia.Standard
{
    public static class IServiceCollectionExtensions
    {
        public static
            (
            IServiceAction<IOrganizationsDirectoryPathProvider> _,
            IServiceAction<IOrganizationsDirectoryNameProvider> OrganizationsDirectoryNameProviderAction,
            (
            IServiceAction<IDropboxDirectoryPathProvider> _,
            IServiceAction<IDropboxDirectoryNameProvider> DropboxDirectoryNameProviderAction,
            IServiceAction<IUserProfileDirectoryPathProvider> UserProfileDirectoryPathProviderAction
            ) DropboxDirectoryPathProviderAction
            )
        AddOrganizationsDirectoryPathProviderAction(this IServiceCollection services,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
#pragma warning disable IDE0042 // Deconstruct variable declaration
            var dropboxDirectoryPathProviderAction = services.AddDropboxDirectoryPathProviderAction(stringlyTypedPathOperatorAction);
#pragma warning restore IDE0042 // Deconstruct variable declaration

            var organizationsDirectoryNameProviderAction = services.AddOrganizationsDirectoryNameProviderAction_Old();

            var organizationsDirectoryPathProviderAction = services.AddOrganizationsDirectoryPathProviderAction_Old(
                dropboxDirectoryPathProviderAction._,
                organizationsDirectoryNameProviderAction,
                stringlyTypedPathOperatorAction);

            return
                (
                organizationsDirectoryPathProviderAction,
                organizationsDirectoryNameProviderAction,
                dropboxDirectoryPathProviderAction
                );
        }

        public static
            (
            IServiceAction<IOrganizationDirectoryPathProvider> _,
            IServiceAction<IOrganizationDirectoryNameProvider> OrganizationDirectoryNameProviderAction,
            (
            IServiceAction<IOrganizationsDirectoryPathProvider> _,
            IServiceAction<IOrganizationsDirectoryNameProvider> OrganizationsDirectoryNameProviderAction,
            (
            IServiceAction<IDropboxDirectoryPathProvider> _,
            IServiceAction<IDropboxDirectoryNameProvider> DropboxDirectoryNameProviderAction,
            IServiceAction<IUserProfileDirectoryPathProvider> UserProfileDirectoryPathProviderAction
            ) DropboxDirectoryPathProviderAction
            ) OrganizationsDirectoryPathProviderAction
            )
        AddOrganizationDirectoryPathProvider(this IServiceCollection services,
            IServiceAction<IOrganizationProvider> organizationProviderAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
#pragma warning disable IDE0042 // Deconstruct variable declaration
            var organizationsDirectoryPathProviderAction = services.AddOrganizationsDirectoryPathProviderAction(
#pragma warning restore IDE0042 // Deconstruct variable declaration
                stringlyTypedPathOperatorAction);

            var organizationDirectoryNameProviderAction = services.AddOrganizationDirectoryNameProviderAction_Old(
                organizationProviderAction);

            var organizationDirectoryPathProviderAction = services.AddOrganizationDirectoryPathProviderAction_Old(
                organizationDirectoryNameProviderAction,
                organizationsDirectoryPathProviderAction._,
                stringlyTypedPathOperatorAction);

            return
                (
                organizationDirectoryPathProviderAction,
                organizationDirectoryNameProviderAction,
                organizationsDirectoryPathProviderAction
                );
        }
    }
}
