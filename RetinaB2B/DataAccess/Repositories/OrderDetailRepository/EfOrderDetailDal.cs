using Core.DataAccess.EntityFramework;
using DataAccess.Context.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.OrderDetailRepository
{
    public class EfOrderDetailDal : EfEntityRepositoryBase<OrderDetail, SimpleContextDb>, IOrderDetailDal
    {
        public async Task<List<OrderDetailDto>> GetListDto(int orderId)
        {
            using (var contex = new SimpleContextDb())
            {
                var result = from orderDetail in contex.OrderDetails.Where(p => p.OrderId == orderId)
                             join product in contex.Products on orderDetail.ProductId equals product.Id
                             select new OrderDetailDto
                             {
                                 Id = orderDetail.Id,
                                 OrderId = orderDetail.OrderId,
                                 Price = orderDetail.Price,
                                 ProductId = orderDetail.ProductId,
                                 ProductName = product.Name,
                                 Quantity = orderDetail.Quantity,
                                 Total = orderDetail.Quantity * orderDetail.Price

                             };
                return await result.ToListAsync();
            }
        }
    }
}
