using System;
using System.Threading.Tasks;


namespace R5T.Costobocia.Default
{
    public class OrganizationsDirectoryNameProvider : IOrganizationsDirectoryNameProvider
    {
        public Task<string> GetOrganizationsDirectoryName()
        {
            return Task.FromResult(OrganizationsDirectory.DefaultDirectoryName);
        }
    }
}
