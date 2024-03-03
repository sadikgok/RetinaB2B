using Business.Repositories.StokRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoksController : ControllerBase
    {
        private readonly IStokService _stokService;

        public StoksController(IStokService stokService)
        {
            _stokService = stokService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(Stok stok)
        {
            var result = await _stokService.Add(stok);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(Stok stok)
        {
            var result = await _stokService.Update(stok);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(Stok stok)
        {
            var result = await _stokService.Delete(stok);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _stokService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _stokService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{depoId}")]
        public async Task<IActionResult> GetStokByDepoId(int depoId)
        {
            var result = await _stokService.GetStokByDepoId(depoId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{groupId}")]
        public async Task<IActionResult> GetStokByGroupId(int groupId)
        {
            var result = await _stokService.GetStokByGroupId(groupId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetLastStokId()
        {
            var result = _stokService.GetLastStokId();
            return Ok(result);
        }
    }
}
