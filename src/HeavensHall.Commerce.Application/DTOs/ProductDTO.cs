
namespace HeavensHall.Commerce.Application.DTOs
{
    public class ProductDTO
    {
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public string Description { get; set; }
        public int Brand_Id { get; set; }
        public string Brand_Name { get; set; }
        public int Category_Id { get; set; }
        public string Category_Name { get; set; }
        public float Rating { get; set; }
        public bool Is_Active { get; set; }
        public string Color { get; set; }
        public int Stock_Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string[] Images { get; set; }
    }
}
