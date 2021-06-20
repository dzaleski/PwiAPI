using Microsoft.AspNetCore.Mvc;

namespace PwiAPI.DTOs
{
    public class HeaderDTO
    {
        [FromHeader]
        public string Authorization { get; set; }
    }
}
