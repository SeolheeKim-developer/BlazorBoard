using Microsoft.EntityFrameworkCore;

namespace BlazorBoard.Models.Candidates
{
    public class CandidateAppDbContext : DbContext
    {
        public CandidateAppDbContext() :base()
        {
            //Empty
        }
        public CandidateAppDbContext(DbContextOptions<CandidateAppDbContext> options) 
            : base(options)
        {
            //Empty
        }

        public DbSet<Candidate> Candidates { get; set; } = null!;//null 허용
    }
}
