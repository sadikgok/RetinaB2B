namespace Entities.Concrete
{
    public class CustomerReliationship
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int PriceListId { get; set; }
        public decimal Discount { get; set; }

    }
}
