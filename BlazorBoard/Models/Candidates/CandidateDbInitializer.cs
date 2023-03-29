using System.Reflection.Metadata.Ecma335;

namespace BlazorBoard.Models.Candidates
{
    public class CandidateDbInitializer
    {
        public static void Initialize(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                var candidateDbContext = services.GetRequiredService<CandidateAppDbContext>();

                if (!candidateDbContext.Candidates.Any())
                {
                    candidateDbContext.Candidates.Add(
                        new Candidate { FirstName = "Tera", LastName = "Campigotto", IsEnrollment = false });
                    
                    candidateDbContext.SaveChanges();
                }
            }
        }
    }
}
