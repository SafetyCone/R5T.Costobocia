using System;
using System.Threading.Tasks;

using R5T.Lombardy;

using R5T.T0064;


namespace R5T.Costobocia.Default
{
    [ServiceImplementationMarker]
    public class OrganizationDirectoryPathProvider : IOrganizationDirectoryPathProvider, IServiceImplementation
    {
        private IOrganizationDirectoryNameProvider OrganizationDirectoryNameProvider { get; }
        private IOrganizationsDirectoryPathProvider OrganizationsDirectoryPathProvider { get; }
        private IStringlyTypedPathOperator StringlyTypedPathOperator { get; }



        public OrganizationDirectoryPathProvider(
            IOrganizationDirectoryNameProvider organizationDirectoryNameProvider,
            IOrganizationsDirectoryPathProvider organizationsDirectoryPathProvider,
            IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.OrganizationDirectoryNameProvider = organizationDirectoryNameProvider;
            this.OrganizationsDirectoryPathProvider = organizationsDirectoryPathProvider;
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        public async Task<string> GetOrganizationDirectoryPath()
        {
            var gettingOrganizationsDirectoryPath = this.OrganizationsDirectoryPathProvider.GetOrganizationsDirectoryPath();
            var gettingOrganizationDirectoryName = this.OrganizationDirectoryNameProvider.GetOrganizationDirectoryName();

            var organizationsDirectoryPath = await gettingOrganizationsDirectoryPath;
            var organizationDirectoryName = await gettingOrganizationDirectoryName;

            var organizationDirectoryPath = this.StringlyTypedPathOperator.GetDirectoryPath(organizationsDirectoryPath, organizationDirectoryName);
            return organizationDirectoryPath;
        }
    }
}
