using CostingManagement.Core.Interfaces;
using CostingManagement.DTO.Security.User;
using System.Threading.Tasks;

namespace CostingManagement.Services.Security.Account
{
    public interface IAccountService
    {
        Task<IResponseDTO> Login(LoginParamsDto loginParams);
        string GenerateJSONWebToken(int userId, string userName);
    }
}
