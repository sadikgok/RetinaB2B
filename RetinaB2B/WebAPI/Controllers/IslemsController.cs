using Business.Repositories.IslemRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IslemsController : ControllerBase
    {
        private readonly IIslemService _ıslemService;

        public IslemsController(IIslemService ıslemService)
        {
            _ıslemService = ıslemService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] Islem islem)
        {
            int sonEklenenIslemId = await _ıslemService.Add(islem);
            return Ok(sonEklenenIslemId);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(Islem ıslem)
        {
            var result = await _ıslemService.Update(ıslem);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("[action]/{islemId}")]
        public async Task<IActionResult> Delete(int islemId)
        {
            var result = await _ıslemService.Delete(islemId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _ıslemService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _ıslemService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public IActionResult GetLastIslemId()
        {
            var result = _ıslemService.GetLastIslemId();
            return Ok(result);
        }

      

    }
}
