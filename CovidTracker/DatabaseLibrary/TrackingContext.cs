using Microsoft.EntityFrameworkCore;

namespace DatabaseLibrary
{
    public class TrackerContext : DbContext
    {
        
        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }

        public DbSet<TestCenter> TestCenters { get; set; }

        public DbSet<TestCenterManagement> TestCenterManagements { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Nation> Nations { get; set; }

        public DbSet<CitizenTestedAtTestCenter> CitizenTestedAtTestCenters { get; set; }
        public DbSet<CitizenWasAtLocation> CitizenWasAtLocations { get; set; }


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
                .WithMany(i => i.ManagesTestCenters)
                .HasForeignKey(b => b.ManagementName);

            //One to many relationship between TestCenter and Location
            modelBuilder.Entity<TestCenter>()
                .HasOne(t => t.PlacedIn)
                .WithMany(l => l.TestCentersAtLocation)
                .HasForeignKey(t => t.LocationAddress);

            //Many to many relationship between Citizen and TestCenter
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
