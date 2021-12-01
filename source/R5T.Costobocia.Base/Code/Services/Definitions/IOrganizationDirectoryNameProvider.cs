using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.Costobocia
{
    [ServiceDefinitionMarker]
    public interface IOrganizationDirectoryNameProvider : IServiceDefinition
    {
        Task<string> GetOrganizationDirectoryName();
    }
}
