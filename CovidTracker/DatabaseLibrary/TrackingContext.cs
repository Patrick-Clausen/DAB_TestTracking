using Microsoft.EntityFrameworkCore;

namespace DatabaseLibrary
{
    public class TrackerContext : DbContext
    {
        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }

        public DbSet<TestCenter> TestCenters { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Nation> Nations { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server = localhost\\SQLEXPRESS; Database = master; Trusted_Connection = True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One to one relationship between TestCenter and TestCenterManagement
            modelBuilder.Entity<TestCenter>()
                .HasOne(b => b.HasManagement)
                .WithOne(i => i.ManagesTestCenter)
                .HasForeignKey<TestCenterManagement>(b => b.ManagedTestCenterName);

            //Many to many relationship between Citizen and TestCenter
            modelBuilder.Entity<CitizenTestedAtTestCenter>()
                .HasKey(cttc => new {cttc.CitizenSSN, cttc.TestCenterName});
            modelBuilder.Entity<CitizenTestedAtTestCenter>()
                .HasOne(cttc => cttc.TestedCitizen)
                .WithMany(c => c.Tests)
                .HasForeignKey(cttc => cttc.CitizenSSN);
            modelBuilder.Entity<CitizenTestedAtTestCenter>()
                .HasOne(cttc => cttc.TestedAt)
                .WithMany(tc => tc.Tests)
                .HasForeignKey(cttc => cttc.TestCenterName);

            //Many to many relationship between Citizen and Location
            modelBuilder.Entity<CitizenWasAtLocation>()
                .HasKey(cwal => new {cwal.VisitingCitizenSSN, cwal.VisitedLocationAddress});
            modelBuilder.Entity<CitizenWasAtLocation>()
                .HasOne(cwal => cwal.VisitingCitizen)
                .WithMany(c => c.WasAtLocations)
                .HasForeignKey(cwal => cwal.VisitingCitizenSSN);
            modelBuilder.Entity<CitizenWasAtLocation>()
                .HasOne(cwal => cwal.VisitedLocation)
                .WithMany(l => l.Visits)
                .HasForeignKey(cwal => cwal.VisitedLocationAddress);
        }
    }
}
