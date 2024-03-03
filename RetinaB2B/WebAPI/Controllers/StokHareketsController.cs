using Business.Repositories.StokHareketRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StokHareketsController : ControllerBase
    {
        private readonly IStokHareketService _stokHareketService;

        public StokHareketsController(IStokHareketService stokHareketService)
        {
            _stokHareketService = stokHareketService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(StokHareket stokHareket)
        {
            var result = await _stokHareketService.Add(stokHareket);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(StokHareket stokHareket)
        {
            var result = await _stokHareketService.Update(stokHareket);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(StokHareket stokHareket)
        {
            var result = await _stokHareketService.Delete(stokHareket);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _stokHareketService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _stokHareketService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
