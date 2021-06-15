using System.ComponentModel.DataAnnotations;

namespace PwiAPI.Models
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
