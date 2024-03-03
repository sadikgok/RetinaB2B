using Business.Repositories.StokBakiyesiRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StokBakiyesisController : ControllerBase
    {
        private readonly IStokBakiyesiService _stokBakiyesiService;

        public StokBakiyesisController(IStokBakiyesiService stokBakiyesiService)
        {
            _stokBakiyesiService = stokBakiyesiService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(StokBakiyesi stokBakiyesi)
        {
            var result = await _stokBakiyesiService.Add(stokBakiyesi);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(StokBakiyesi stokBakiyesi)
        {
            var result = await _stokBakiyesiService.Update(stokBakiyesi);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(StokBakiyesi stokBakiyesi)
        {
            var result = await _stokBakiyesiService.Delete(stokBakiyesi);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _stokBakiyesiService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _stokBakiyesiService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
