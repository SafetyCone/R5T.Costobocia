using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.Costobocia.Default
{
    [ServiceImplementationMarker]
    public class OrganizationsDirectoryNameProvider : IOrganizationsDirectoryNameProvider, IServiceImplementation
    {
        public Task<string> GetOrganizationsDirectoryName()
        {
            return Task.FromResult(OrganizationsDirectory.DefaultDirectoryName);
        }
    }
}
