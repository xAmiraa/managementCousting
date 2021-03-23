using System.Linq;
using CostingManagement.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CostingManagement.Controllers
{

    [ApiController]
    public class BaseController : ControllerBase
    {

        private IHttpContextAccessor _httpContextAccessor;
        public IResponseDTO _response;

        public BaseController(IResponseDTO responseDTO, IHttpContextAccessor httpContextAccessor)
        {
            _response = responseDTO;
            _httpContextAccessor = httpContextAccessor;
        }


        public int LoggedInUserId 
        { get 
            {
                if(_httpContextAccessor.HttpContext?.User?.Claims?.Where(c => c.Type == "userid")?.SingleOrDefault()?.Value != null)
                {
                    return int.Parse(_httpContextAccessor.HttpContext?.User?.Claims?.Where(c => c.Type == "userid")?.SingleOrDefault()?.Value);
                }
                return 0;
            } 
        }
        public string LoggedInUserName { get { return _httpContextAccessor.HttpContext?.User?.Identity?.Name; } }
        public string ServerRootPath { get { return $"{Request.Scheme}://{Request.Host}{Request.PathBase}"; } }
        public string IP { get { return _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.MapToIPv4().ToString(); } }

    }
}