namespace PwiAPI.DTOs
{
    public class OrderShortResponseDTO
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public string OrderDate { get; set; }
        public float TotalCost { get; set; }
    }
}
