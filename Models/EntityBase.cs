using System.ComponentModel.DataAnnotations;

namespace PwiAPI.Models
{
    public class EntityBase
    {
        [Key]
        public long Id { get; set; }
    }
}
