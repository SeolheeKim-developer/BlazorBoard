using BlazorBoard.Models.Projects;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorBoard.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Broth> Broths { get; set; }
        public DbSet<Board> Boards { get; set; }

        public DbSet<Garnish> Garnishes { get; set; }
       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Broth>().HasData(
                new Broth() { Id = 1, Name = "Bean Broth", IsVegan = true },
                new Broth() { Id = 2, Name = "Anchovy Broth", IsVegan = false }
                );
            builder.Entity<Board>().HasData(
                new Board { Id = 1, Name ="Bean Noodle", BrothId = 1},
                new Board { Id = 2, Name = "Party Noodle", BrothId = 2 }
                );
        }
    }
}