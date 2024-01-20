using Business.Repositories.CustomerReliationshipRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerReliationshipsController : ControllerBase
    {
        private readonly ICustomerReliationshipService _customerReliationshipService;

        public CustomerReliationshipsController(ICustomerReliationshipService customerReliationshipService)
        {
            _customerReliationshipService = customerReliationshipService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(CustomerReliationship customerReliationship)
        {
            var result = await _customerReliationshipService.Add(customerReliationship);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(CustomerReliationship customerReliationship)
        {
            var result = await _customerReliationshipService.Update(customerReliationship);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(CustomerReliationship customerReliationship)
        {
            var result = await _customerReliationshipService.Delete(customerReliationship);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _customerReliationshipService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _customerReliationshipService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
