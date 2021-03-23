using CostingManagement.Core.Interfaces;
using CostingManagement.DTO.Lookup.PackageType;
using CostingManagement.Services.Lookup.PackageType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CostingManagement.Controllers
{
    [Authorize]
    public class PackageTypesController : BaseController
    {
        private readonly IPackageTypeService _packageTypeService;

        public PackageTypesController(
            IPackageTypeService packageTypeService,
            IResponseDTO response,
            IHttpContextAccessor httpContextAccessor) : base(response, httpContextAccessor)
        {
            _packageTypeService = packageTypeService;
        }


        [Route("api/packagetypes")]
        [HttpGet]
        public IResponseDTO SearchPackageTypes([FromQuery] PackageTypeFilterDto filterDto)
        {
            _response = _packageTypeService.SearchPackageTypes(filterDto);
            return _response;
        }


        [Route("api/packagetypes")]
        [HttpPost]
        public async Task<IResponseDTO> CreatePackageType([FromBody] CreateUpdatePackageTypeDto options)
        {
            _response = await _packageTypeService.CreatePackageType(options, LoggedInUserId);
            return _response;
        }


        [Route("api/packagetypes/{id}")]
        [HttpPut]
        public async Task<IResponseDTO> UpdatePackageType([FromRoute] int id, [FromBody] CreateUpdatePackageTypeDto options)
        {
            _response = await _packageTypeService.UpdatePackageType(id, options, LoggedInUserId);
            return _response;
        }


        [Route("api/packagetypes/{id}")]
        [HttpDelete]
        public async Task<IResponseDTO> RemovePackageType([FromRoute] int id)
        {
            _response = await _packageTypeService.RemovePackageType(id);
            return _response;
        }

    }
}
