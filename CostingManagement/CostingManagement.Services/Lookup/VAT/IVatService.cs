using CostingManagement.Core.Interfaces;
using CostingManagement.DTO.Lookup.VAT;
using System.Threading.Tasks;

namespace CostingManagement.Services.Lookup.VAT
{
    public interface IVatService
    {
        IResponseDTO SearchVats(VatFilterDto filterDto);
        Task<IResponseDTO> CreateVat(CreateUpdateVatDto options, int userId);
        Task<IResponseDTO> UpdateVat(int id, CreateUpdateVatDto options, int userId);
        Task<IResponseDTO> RemoveVat(int id);
    }
}
