using CostingManagement.Core.Interfaces;
using CostingManagement.DTO.Lookup.VAT;
using CostingManagement.Services.Lookup.VAT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CostingManagement.Controllers
{
    [Authorize]
    public class VatsController : BaseController
    {
        private readonly IVatService _vatService;

        public VatsController(
            IVatService vatService,
            IResponseDTO response,
            IHttpContextAccessor httpContextAccessor) : base(response, httpContextAccessor)
        {
            _vatService = vatService;
        }


        [Route("api/vats")]
        [HttpGet]
        public IResponseDTO SearchVats([FromQuery] VatFilterDto filterDto)
        {
            _response = _vatService.SearchVats(filterDto);
            return _response;
        }


        [Route("api/vats")]
        [HttpPost]
        public async Task<IResponseDTO> CreateVat([FromBody] CreateUpdateVatDto options)
        {
            _response = await _vatService.CreateVat(options, LoggedInUserId);
            return _response;
        }


        [Route("api/vats/{id}")]
        [HttpPut]
        public async Task<IResponseDTO> UpdateVat([FromRoute] int id, [FromBody] CreateUpdateVatDto options)
        {
            _response = await _vatService.UpdateVat(id, options, LoggedInUserId);
            return _response;
        }


        [Route("api/vats/{id}")]
        [HttpDelete]
        public async Task<IResponseDTO> RemoveVat([FromRoute] int id)
        {
            _response = await _vatService.RemoveVat(id);
            return _response;
        }
    }
}
