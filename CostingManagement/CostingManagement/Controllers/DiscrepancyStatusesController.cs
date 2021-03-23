using CostingManagement.Core.Interfaces;
using CostingManagement.DTO.Lookup.DiscrepancyStatus;
using CostingManagement.Services.Lookup.DiscrepancyStatus;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CostingManagement.Controllers
{
    [Authorize]
    public class DiscrepancyStatusesController : BaseController
    {
        private readonly IDiscrepancyStatusService _discrepancyStatusService;

        public DiscrepancyStatusesController(
            IDiscrepancyStatusService discrepancyStatusService,
            IResponseDTO response,
            IHttpContextAccessor httpContextAccessor) : base(response, httpContextAccessor)
        {
            _discrepancyStatusService = discrepancyStatusService;
        }


        [Route("api/discrepancystatuses")]
        [HttpGet]
        public IResponseDTO SearchDiscrepancyStatuses([FromQuery] DiscrepancyStatusFilterDto filterDto)
        {
            _response = _discrepancyStatusService.SearchDiscrepancyStatuses(filterDto);
            return _response;
        }


        [Route("api/discrepancystatuses")]
        [HttpPost]
        public async Task<IResponseDTO> CreateDiscrepancyStatus([FromBody] CreateUpdateDiscrepancyStatusDto options)
        {
            _response = await _discrepancyStatusService.CreateDiscrepancyStatus(options, LoggedInUserId);
            return _response;
        }


        [Route("api/discrepancystatuses/{id}")]
        [HttpPut]
        public async Task<IResponseDTO> UpdateDiscrepancyStatus([FromRoute] int id, [FromBody] CreateUpdateDiscrepancyStatusDto options)
        {
            _response = await _discrepancyStatusService.UpdateDiscrepancyStatus(id, options, LoggedInUserId);
            return _response;
        }


        [Route("api/discrepancystatuses/{id}")]
        [HttpDelete]
        public async Task<IResponseDTO> RemoveDiscrepancyStatus([FromRoute] int id)
        {
            _response = await _discrepancyStatusService.RemoveDiscrepancyStatus(id);
            return _response;
        }
    }
}
