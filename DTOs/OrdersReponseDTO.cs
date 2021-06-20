using System;
using System.Collections.Generic;

namespace PwiAPI.DTOs
{
    public class OrdersReponseDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public DateTime? OrderDate { get; set; }
        public virtual IEnumerable<ProductOrderDTO> Products { get; set; }
    }
}
