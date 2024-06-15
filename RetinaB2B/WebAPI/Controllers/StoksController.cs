using Business.Repositories.StokRepository;
using DataAccess.Context.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoksController : ControllerBase
    {
        private readonly IStokService _stokService;
        private object _dovizKuru;

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
        public async Task<IActionResult> UpdateStokAciklama(StokOzellikDto stok)
        {
            var result = await _stokService.UpdateStokAciklama(stok);
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

        [HttpGet("[action]/{stokId}")]
        public async Task<IActionResult> GetById(int stokId)
        {
            var result = await _stokService.GetById(stokId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{stokId}")]
        public async Task<IActionResult> GetStokAciklama(int stokId)
        {
            var result = await _stokService.GetStokAciklama(stokId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{barcode}")]
        public async Task<IActionResult> GetStokByBarcode(string barcode)
        {
            var result = await _stokService.GetStokByBarcode(barcode);
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

        [HttpGet("[action]")]
        public async Task<IActionResult> GetStokListForUI()
        {
            var result = await _stokService.GetStokListForUI();
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpGet("{page}/{pageSize}")]
        public async Task<IActionResult> GetPagedProducts(int pageNumber = 1, int pageSize = 1, string grup = "")
        {
            using (var context = new SimpleContextDb())
            {
                var result = from stok in context.Stoklar
                             where context.ProductImages.Any(p => p.StokId == stok.StokId)
                             select new ProductListDto
                             {
                                 StokId = stok.StokId,
                                 StokAdi = stok.StokAdi,
                                 SatisFiyati = stok.SatisFiyati,
                                 ToptanSatisFiyati = stok.ToptanSatisFiyati,
                                 BayiSatisFiyati = stok.BayiSatisFiyati,
                                 IndirimliSatisFiyati = stok.IndirimliSatisFiyati,
                                 IndirimliStokAdedi = stok.IndirimliStokAdedi,
                                 MainImageUrl = context.ProductImages
                                     .Where(p => p.StokId == stok.StokId && p.IsMainImage)
                                     .Select(s => s.ImageUrl)
                                     .FirstOrDefault() ?? "",
                                 Image = context.ProductImages
                                     .Where(p => p.StokId == stok.StokId)
                                     .Select(s => s.ImageUrl)
                                     .ToList()
                             };
                var pagedResult = await result
                                    .Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();
                var totalRecords = await result.CountAsync();

                return Ok(new
                {
                    TotalRecords = totalRecords,
                    Data = pagedResult
                });

                //var totalRecords = await context.Stoklar.CountAsync();
                //var stoks = await context.Stoklar
                //    .OrderBy(s => s.StokAdi)
                //    .Skip((pageNumber - 1) * pageSize)
                //    .Take(pageSize)
                //    .Select(stok => new ProductListDto
                //    {
                //        StokId = stok.StokId,
                //        StokAdi = stok.StokAdi,
                //        SatisFiyati = stok.SatisFiyati,
                //        MainImageUrl = context.ProductImages.Where(p => p.StokId == stok.StokId && p.IsMainImage).Select(s => s.ImageUrl).FirstOrDefault() ?? "",
                //        Image = context.ProductImages.Where(p => p.StokId == stok.StokId).Select(s => s.ImageUrl).ToList()
                //    })
                //    .ToListAsync();

                //return Ok(new { data = stoks, totalRecords = totalRecords });
            }
        }


        [HttpPost("[action]")]
        public IActionResult SetDovizKuru([FromBody] object data)
        {
            _dovizKuru = data;
            return Ok(new { message = "Veri alýndý", data });
        }

        [HttpGet("[action]")]
        public IActionResult PostDovizKuru()
        {
            return Ok(_dovizKuru);
        }
    }
}
