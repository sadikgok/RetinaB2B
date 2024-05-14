using Business.Repositories.CariRepository;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarisController : ControllerBase
    {
        private readonly ICariService _cariService;

        public CarisController(ICariService cariService)
        {
            _cariService = cariService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(CariRegisterDto cariRegisterDto)
        {
            var result = await _cariService.Add(cariRegisterDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(Cari cari)
        {
            var result = await _cariService.Update(cari);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(Cari cari)
        {
            var result = await _cariService.Delete(cari);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetListDto()
        {
            var result = await _cariService.GetListDto();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{cariId}")]
        public async Task<IActionResult> GetById(int cariId)
        {
            var result = await _cariService.GetById(cariId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateCariBakiye(CariBakiyeDto cariBakiyeDto)
        {
            var result = await _cariService.UpdateCariBakiye(cariBakiyeDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CariPasswordChange(CariPasswordChangeDto cariDto)
        {
            var result = await _cariService.CariPasswordChange(cariDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
