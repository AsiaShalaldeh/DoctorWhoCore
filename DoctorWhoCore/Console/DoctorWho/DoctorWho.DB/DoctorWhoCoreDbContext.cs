using Microsoft.EntityFrameworkCore;

namespace DoctorWho.DB
{
    public class DoctorWhoCoreDbContext: DbContext
    {
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Companion> Companions { get; set; }
        public DbSet<Enemy> Enemies { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<EpisodeEnemy> EpisodeEnemies { get; set; }
        public DbSet<EpisodeCompanion> EpisodeCompanions { get; set; }
        public DbSet<EpisodeSummary> EpisodeSummary { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=DESKTOP-TD29OVV;database=DoctorWhoCore;" +
                    "trusted_connection=true;TrustServerCertificate=True");
            }
            optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EpisodeSummary>().HasNoKey().ToView(null);

            // Configure many-to-many relationship between Episode and Companion 
            modelBuilder.Entity<EpisodeCompanion>()
            .HasKey(ec => new { ec.EpisodeId, ec.CompanionId });

            modelBuilder.Entity<EpisodeCompanion>()
                .HasOne(ec => ec.Episode)
                .WithMany(e => e.EpisodeCompanions)
                .HasForeignKey(ec => ec.EpisodeId);

            modelBuilder.Entity<EpisodeCompanion>()
                .HasOne(ec => ec.Companion)
                .WithMany(c => c.EpisodeCompanions)
                .HasForeignKey(ec => ec.CompanionId);

            // Configure many-to-many relationship between Episode and Enemy
            modelBuilder.Entity<EpisodeEnemy>()
            .HasKey(ee => new { ee.EpisodeId, ee.EnemyId });

            modelBuilder.Entity<EpisodeEnemy>()
                .HasOne(ee => ee.Episode)
                .WithMany(e => e.EpisodeEnemies)
                .HasForeignKey(ee => ee.EpisodeId);

            modelBuilder.Entity<EpisodeEnemy>()
                .HasOne(ee => ee.Enemy)
                .WithMany(e => e.EpisodeEnemies)
                .HasForeignKey(ee => ee.EnemyId);


            modelBuilder.Seed();
        }
    }
}