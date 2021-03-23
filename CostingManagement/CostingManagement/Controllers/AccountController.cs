using CostingManagement.Controllers;
using CostingManagement.Core.Interfaces;
using CostingManagement.DTO.Security.User;
using CostingManagement.Services.Security.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CostingManagement.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;

        public AccountController(
           IAccountService accountService,
           IResponseDTO response,
           IHttpContextAccessor httpContextAccessor) : base(response, httpContextAccessor)
        {
            _accountService = accountService;
        }


        [Route("api/login")]
        [HttpPost]
        public async Task<IResponseDTO> Login([FromBody] LoginParamsDto loginParams)
        {
            _response = await _accountService.Login(loginParams);
            return _response;
        }

    }
}