using CostingManagement.Core.Interfaces;
using CostingManagement.DTO.Lookup.DiscrepancyStatus;
using System.Threading.Tasks;

namespace CostingManagement.Services.Lookup.DiscrepancyStatus
{
    public interface IDiscrepancyStatusService
    {
        IResponseDTO SearchDiscrepancyStatuses(DiscrepancyStatusFilterDto filterDto);
        Task<IResponseDTO> CreateDiscrepancyStatus(CreateUpdateDiscrepancyStatusDto options, int userId);
        Task<IResponseDTO> UpdateDiscrepancyStatus(int id, CreateUpdateDiscrepancyStatusDto options, int userId);
        Task<IResponseDTO> RemoveDiscrepancyStatus(int id);
    }
}
