using System.ComponentModel.DataAnnotations;

namespace BlazorBoard.Models.Projects
{
    public class Broth
    {
        public int Id { get; set; }
        [Required]
        [StringLength(25)]
        public string? Name { get; set; }
        public bool IsVegan { get; set; }

        public List<Board> Boards { get; set; } = new();

    }

}
