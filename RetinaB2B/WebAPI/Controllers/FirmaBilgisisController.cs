using Business.Repositories.FirmaBilgisiRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirmaBilgisisController : ControllerBase
    {
        private readonly IFirmaBilgisiService _firmaBilgisiService;

        public FirmaBilgisisController(IFirmaBilgisiService firmaBilgisiService)
        {
            _firmaBilgisiService = firmaBilgisiService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(FirmaBilgisi firmaBilgisi)
        {
            var result = await _firmaBilgisiService.Add(firmaBilgisi);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(FirmaBilgisi firmaBilgisi)
        {
            var result = await _firmaBilgisiService.Update(firmaBilgisi);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(FirmaBilgisi firmaBilgisi)
        {
            var result = await _firmaBilgisiService.Delete(firmaBilgisi);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _firmaBilgisiService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _firmaBilgisiService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
