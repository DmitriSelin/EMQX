using EMQX.Api.Models;
using EMQX.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EMQX.Api.Controllers
{
    [ApiController]
    [Route("/")]
    public sealed class EMQXController : ControllerBase
    {
        private readonly IEMQXService _emqxService;

        public EMQXController(IEMQXService emqxService)
        {
            _emqxService = emqxService;
        }

        [HttpPost]
        public async Task<IActionResult> ConnectAsync(MessageRequest request)
        {
            var result = await _emqxService.ConnectAsync(request);
            return Ok(result);
        }
    }
}