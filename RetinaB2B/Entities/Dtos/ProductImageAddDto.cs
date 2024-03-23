using Microsoft.AspNetCore.Http;

namespace Entities.Dtos
{
    public class ProductImageAddDto
    {
        public int StokId { get; set; }
        public IFormFile[] Images { get; set; }
    }
}
