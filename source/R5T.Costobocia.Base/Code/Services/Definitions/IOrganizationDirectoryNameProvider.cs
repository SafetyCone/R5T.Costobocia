using System;
using System.Threading.Tasks;


namespace R5T.Costobocia
{
    public interface IOrganizationDirectoryNameProvider
    {
        Task<string> GetOrganizationDirectoryName();
    }
}
