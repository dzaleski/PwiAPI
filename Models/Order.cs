using System.Collections.Generic;

namespace PwiAPI.Models
{
    public class Order : EntityBase
    {
        public virtual IEnumerable<Product> Products { get; set; }
    }
}
