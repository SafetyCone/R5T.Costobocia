﻿using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Bulgaria;
using R5T.Lombardy;

using R5T.T0063;


namespace R5T.Costobocia.Bulgaria
{
    public static partial class IServiceCollectionExtensions
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
                .Run(dropboxDirectoryPathProviderAction)
                .Run(organizationsDirectoryNameProviderAction)
                .Run(stringlyTypedPathOperatorAction)
                .AddSingleton<IOrganizationsDirectoryPathProvider, OrganizationsDirectoryPathProvider>();

            return services;
        }
    }
}
