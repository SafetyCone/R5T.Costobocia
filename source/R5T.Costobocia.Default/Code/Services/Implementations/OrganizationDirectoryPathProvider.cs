using System;
using System.Threading.Tasks;

using R5T.Lombardy;


namespace R5T.Costobocia.Default
{
    public class OrganizationDirectoryPathProvider : IOrganizationDirectoryPathProvider
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
