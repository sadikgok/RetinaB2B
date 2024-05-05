using Business.Repositories.IslemDetayRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IslemDetailsController : ControllerBase
    {
        private readonly IIslemDetayService _ıslemDetayService;

        public IslemDetailsController(IIslemDetayService ıslemDetayService)
        {
            _ıslemDetayService = ıslemDetayService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(IslemDetay ıslemDetay)
        {
            var result = await _ıslemDetayService.Add(ıslemDetay);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(IslemDetay ıslemDetay)
        {
            var result = await _ıslemDetayService.Update(ıslemDetay);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("[action]/{islemId}")]
        public async Task<IActionResult> Delete(int islemId)
        {
            var result = await _ıslemDetayService.Delete(new IslemDetay { IslemId = islemId });
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _ıslemDetayService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _ıslemDetayService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
