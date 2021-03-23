using CostingManagement.Core.Interfaces;
using CostingManagement.DTO.Lookup.PackageType;
using System.Threading.Tasks;

namespace CostingManagement.Services.Lookup.PackageType
{
    public interface IPackageTypeService
    {
        IResponseDTO SearchPackageTypes(PackageTypeFilterDto filterDto);
        Task<IResponseDTO> CreatePackageType(CreateUpdatePackageTypeDto options, int userId);
        Task<IResponseDTO> UpdatePackageType(int id, CreateUpdatePackageTypeDto options, int userId);
        Task<IResponseDTO> RemovePackageType(int id);
    }
}
