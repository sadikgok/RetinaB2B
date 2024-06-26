using Business.Repositories.IslemRepository;
using Business.Repositories.KasaHareketRepository;
using Business.Repositories.ProductRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KasaHareketsController : ControllerBase
    {
        private readonly IKasaHareketService _kasaHareketService;

        public KasaHareketsController(IKasaHareketService kasaHareketService)
        {
            _kasaHareketService = kasaHareketService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(KasaHareket kasaHareket)
        {
            var result = await _kasaHareketService.Add(kasaHareket);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(KasaHareket kasaHareket)
        {
            var result = await _kasaHareketService.Update(kasaHareket);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("[action]/{islemId}")]
        public async Task<IActionResult> Delete(int islemId)
        {
            var result = await _kasaHareketService.Delete(new KasaHareket { IslemId = islemId });
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _kasaHareketService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{islemId}")]
        public async Task<IActionResult> GetById(int islemId)
        {
            var result = await _kasaHareketService.GetById(islemId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{kasaId}")]
        public async Task<IActionResult> GetKasaHareketByKasaId(int kasaId)
        {
            var result = await _kasaHareketService.GetKasaHareketByKasaId(kasaId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

    }
}
