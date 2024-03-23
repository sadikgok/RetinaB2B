using Business.Repositories.CariHareketRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CariHareketsController : ControllerBase
    {
        private readonly ICariHareketService _cariHareketService;

        public CariHareketsController(ICariHareketService cariHareketService)
        {
            _cariHareketService = cariHareketService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(CariHareket cariHareket)
        {
            var result = await _cariHareketService.Add(cariHareket);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(CariHareket cariHareket)
        {
            var result = await _cariHareketService.Update(cariHareket);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(CariHareket cariHareket)
        {
            var result = await _cariHareketService.Delete(cariHareket);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _cariHareketService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _cariHareketService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{cariId}")]
        public async Task<IActionResult> GetCariHareketByCariId(int cariId)
        {
            var result = await _cariHareketService.GetCariHareketByCariId(cariId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

    }
}
