using Microsoft.EntityFrameworkCore;

namespace DoctorWho.DB
{
    public class DoctorWhoCoreDbContext: DbContext
    {
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Companion> Companions { get; set; }
        public DbSet<Enemy> Enemies { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Doctor> Doctor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure many-to-many relationship between Episode and Enemy
            modelBuilder.Entity<Episode>()
                .HasMany(e => e.Enemies)
                .WithMany(e => e.Episodes)
                .UsingEntity<EpisodeEnemy>(
                join => join
                .HasOne<Enemy>()
                .WithMany()
                .HasForeignKey(ee => ee.EnemyId),
                join => join
                .HasOne<Episode>()
                .WithMany()
                .HasForeignKey(ee => ee.EpisodeId));

            // Configure many-to-many relationship between Episode and Companion 
            modelBuilder.Entity<Episode>()
                .HasMany(e => e.Companions)
                .WithMany(e => e.Episodes)
                .UsingEntity<EpisodeCompanion>(
                join => join
                .HasOne<Companion>()
                .WithMany()
                .HasForeignKey(ec => ec.CompanionId),
                join => join
                .HasOne<Episode>()
                .WithMany()
                .HasForeignKey(ec => ec.EpisodeId));

        }
    }
}