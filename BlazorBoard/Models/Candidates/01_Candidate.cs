using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace BlazorBoard.Models.Candidates
{
    /// <summary>
    /// Applicant
    /// </summary>
    public class CandidateBase
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }

        public bool IsEnrollment { get; set; }
    }
    public class Candidate :CandidateBase
    {
        //Empty
        
    }
}
