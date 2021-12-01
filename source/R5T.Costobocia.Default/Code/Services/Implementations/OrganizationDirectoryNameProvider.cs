using System;
using System.Threading.Tasks;

using R5T.Ostrogothia;

using R5T.T0064;


namespace R5T.Costobocia.Default
{
    [ServiceImplementationMarker]
    public class OrganizationDirectoryNameProvider : IOrganizationDirectoryNameProvider, IServiceImplementation
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
