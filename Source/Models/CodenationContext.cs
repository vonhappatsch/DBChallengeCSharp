using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Models
{
    public class CodenationContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }

        public DbSet<Candidate> Candidates { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Submission> Submissions { get; set; }

        public DbSet<Challenge> Challenges { get; set; }

        public DbSet<Acceleration> Accelerations { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Codenation;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .Property(c => c.CompanyId).HasColumnName("id");

            modelBuilder.Entity<Candidate>()
                .HasKey(c => new { c.UserId, c.AccelerationId, c.CompanyId });

            modelBuilder.Entity<User>()
                .Property(e => e.UserId).HasColumnName("id");

            modelBuilder.Entity<Submission>()
                .HasKey(s => new { s.UserId, s.ChallengeId });

            modelBuilder.Entity<Challenge>()
                .Property(c => c.ChallengeId).HasColumnName("id");

            modelBuilder.Entity<Acceleration>()
                .Property(a => a.AccelerationId).HasColumnName("id");
        }
    }
}