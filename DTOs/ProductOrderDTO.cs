namespace PwiAPI.DTOs
{
    public class ProductOrderDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public int Quantity { get; set; }
        public CategoryDTO Category { get; set; }
    }
}
