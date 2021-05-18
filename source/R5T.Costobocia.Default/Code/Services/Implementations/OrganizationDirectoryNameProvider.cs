using System;
using System.Threading.Tasks;

using R5T.Ostrogothia;


namespace R5T.Costobocia.Default
{
    public class OrganizationDirectoryNameProvider : IOrganizationDirectoryNameProvider
    {
        private IOrganizationProvider OrganizationProvider { get; }



        public OrganizationDirectoryNameProvider(
            IOrganizationProvider organizationProvider)
        {
            this.OrganizationProvider = organizationProvider;
        }

        public async Task<string> GetOrganizationDirectoryName()
        {
            var organization = await this.OrganizationProvider.GetOrganization();

            // Assumes that the organization name is acceptable as a directory name.
            var organizationDirectoryName = organization.Name;
            return organizationDirectoryName;
        }
    }
}
