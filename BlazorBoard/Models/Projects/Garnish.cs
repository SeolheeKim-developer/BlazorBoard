using System.ComponentModel.DataAnnotations;

namespace BlazorBoard.Models.Projects
{
    public class Garnish 
    {
        public int Id { get; set; }
        [Required]
        [StringLength(25)]
        public string? Name { get; set; }
        public int? BoardId { get; set; }
        public Board? Board { get; set; }
    }

}
