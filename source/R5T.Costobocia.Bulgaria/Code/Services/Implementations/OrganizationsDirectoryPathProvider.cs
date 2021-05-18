using System;
using System.Threading.Tasks;

using R5T.Bulgaria;
using R5T.Lombardy;


namespace R5T.Costobocia.Bulgaria
{
    public class OrganizationsDirectoryPathProvider : IOrganizationsDirectoryPathProvider
    {
        private IDropboxDirectoryPathProvider DropboxDirectoryPathProvider { get; }
        private IOrganizationsDirectoryNameProvider OrganizationsDirectoryNameProvider { get; }
        private IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public OrganizationsDirectoryPathProvider(
            IDropboxDirectoryPathProvider dropboxDirectoryPathProvider,
            IOrganizationsDirectoryNameProvider organizationsDirectoryNameProvider,
            IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.DropboxDirectoryPathProvider = dropboxDirectoryPathProvider;
            this.OrganizationsDirectoryNameProvider = organizationsDirectoryNameProvider;
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        public async Task<string> GetOrganizationsDirectoryPath()
        {
            var gettingDropboxDirectoryPath = this.DropboxDirectoryPathProvider.GetDropboxDirectoryPath();
            var gettingOrganizationsDirectoryName = this.OrganizationsDirectoryNameProvider.GetOrganizationsDirectoryName();

            var dropboxDirectoryPath = await gettingDropboxDirectoryPath;
            var organizationsDirectoryName = await gettingOrganizationsDirectoryName;

            var organizationsDirectoryPath = this.StringlyTypedPathOperator.GetDirectoryPath(dropboxDirectoryPath, organizationsDirectoryName);
            return organizationsDirectoryPath;
        }
    }
}
