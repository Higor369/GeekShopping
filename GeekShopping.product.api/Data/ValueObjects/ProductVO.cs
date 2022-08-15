namespace GeekShopping.product.api.Data.ValueObjects
{
    public class ProductVO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
