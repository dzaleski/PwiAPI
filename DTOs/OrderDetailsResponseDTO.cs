using System.Collections.Generic;

namespace PwiAPI.DTOs
{
    public class OrderDetailsResponseDTO
    {
        public float TotalOrderPrice { get; set; }
        public IEnumerable<ProductOrderResponseDTO> products{ get; set; }
    }
}
