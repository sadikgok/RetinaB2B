using Business.Repositories.DepoRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeposController : ControllerBase
    {
        private readonly IDepoService _depoService;

        public DeposController(IDepoService depoService)
        {
            _depoService = depoService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(Depo depo)
        {
            var result = await _depoService.Add(depo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(Depo depo)
        {
            var result = await _depoService.Update(depo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(Depo depo)
        {
            var result = await _depoService.Delete(depo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _depoService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _depoService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
