using Business.Repositories.StokGrupRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StokGrupsController : ControllerBase
    {
        private readonly IStokGrupService _stokGrupService;

        public StokGrupsController(IStokGrupService stokGrupService)
        {
            _stokGrupService = stokGrupService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(StokGrup stokGrup)
        {
            var result = await _stokGrupService.Add(stokGrup);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(StokGrup stokGrup)
        {
            var result = await _stokGrupService.Update(stokGrup);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(StokGrup stokGrup)
        {
            var result = await _stokGrupService.Delete(stokGrup);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _stokGrupService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _stokGrupService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
