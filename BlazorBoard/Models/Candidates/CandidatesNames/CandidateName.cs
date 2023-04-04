﻿using System.ComponentModel.DataAnnotations;

namespace BlazorBoard.Models.Candidates.CandidatesNames
{
    public class CandidateName
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }
        [StringLength(50)]
        public string? MiddleName { get; set; }

        public string? UseId { get; set; } = null;
    }
}
