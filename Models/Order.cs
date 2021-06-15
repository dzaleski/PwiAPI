using System.Collections.Generic;

namespace PwiAPI.Models
{
    public class Order : EntityBase
    {
        public IEnumerable<Product> Products { get; set; }
    }
}
