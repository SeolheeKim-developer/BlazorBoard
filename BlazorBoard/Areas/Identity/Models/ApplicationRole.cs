using Microsoft.AspNetCore.Identity;

namespace BlazorBoard.Areas.Identity.Models
{
    public class ApplicationRole : IdentityRole
    {
        public string? Description { get; set; }
    }
}
