namespace PwiAPI.DTOs
{
    public class ProductOrderResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public float TotalPrice { get; set; }
        public CategoryDTO Category { get; set; }
        public int Quantity { get; set; }
        public float TotalOrderPrice { get; set; }
    }
}
