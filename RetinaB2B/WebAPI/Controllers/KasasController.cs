using Business.Repositories.KasaRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KasasController : ControllerBase
    {
        private readonly IKasaService _kasaService;

        public KasasController(IKasaService kasaService)
        {
            _kasaService = kasaService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(Kasa kasa)
        {
            var result = await _kasaService.Add(kasa);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(Kasa kasa)
        {
            var result = await _kasaService.Update(kasa);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(Kasa kasa)
        {
            var result = await _kasaService.Delete(kasa);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _kasaService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{kasaId}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _kasaService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
