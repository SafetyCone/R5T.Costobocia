using System;
using System.Threading.Tasks;


namespace R5T.Costobocia
{
    public interface IOrganizationsDirectoryPathProvider
    {
        Task<string> GetOrganizationsDirectoryPath();
    }
}
