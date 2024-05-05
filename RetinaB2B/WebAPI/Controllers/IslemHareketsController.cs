using Business.Repositories.IslemHareketRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IslemHareketsController : ControllerBase
    {
        private readonly IIslemHareketService _ıslemHareketService;

        public IslemHareketsController(IIslemHareketService ıslemHareketService)
        {
            _ıslemHareketService = ıslemHareketService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(IslemHareket ıslemHareket)
        {
            var result = await _ıslemHareketService.Add(ıslemHareket);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(IslemHareket ıslemHareket)
        {
            var result = await _ıslemHareketService.Update(ıslemHareket);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(IslemHareket ıslemHareket)
        {
            var result = await _ıslemHareketService.Delete(ıslemHareket);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _ıslemHareketService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _ıslemHareketService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{islemId}")]
        public async Task<IActionResult> GetIslemHareketByIslemId(int islemId)
        {
            var result = await _ıslemHareketService.GetIslemHareketByIslemId(islemId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

    }
}
