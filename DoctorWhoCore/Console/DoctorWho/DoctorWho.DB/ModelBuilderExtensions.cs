using Microsoft.EntityFrameworkCore;

namespace DoctorWho.DB
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author { AuthorId = 1, AuthorName = "John Doe" },
                new Author { AuthorId = 2, AuthorName = "Jane Doe" },
                new Author { AuthorId = 3, AuthorName = "Bob Smith" },
                new Author { AuthorId = 4, AuthorName = "Alice Johnson" },
                new Author { AuthorId = 5, AuthorName = "Tom Lee" }
            );
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { DoctorId = 1, DoctorNumber = 1234, DoctorName = "John Smith", BirthDate = new DateTime(1980, 1, 1), FirstEpisodeDate = new DateTime(2020, 1, 1), LastEpisodeDate = new DateTime(2020, 1, 7) },
                new Doctor { DoctorId = 2, DoctorNumber = 5678, DoctorName = "Jane Doe", BirthDate = new DateTime(1975, 5, 10), FirstEpisodeDate = new DateTime(2020, 2, 1), LastEpisodeDate = new DateTime(2020, 2, 15) },
                new Doctor { DoctorId = 3, DoctorNumber = 9012, DoctorName = "Bob Johnson", BirthDate = new DateTime(1990, 3, 15), FirstEpisodeDate = new DateTime(2020, 3, 1), LastEpisodeDate = new DateTime(2020, 3, 21) },
                new Doctor { DoctorId = 4, DoctorNumber = 3456, DoctorName = "Alice Lee", BirthDate = new DateTime(1985, 12, 25), FirstEpisodeDate = new DateTime(2020, 4, 1), LastEpisodeDate = new DateTime(2020, 4, 30) },
                new Doctor { DoctorId = 5, DoctorNumber = 7890, DoctorName = "Tom Wilson", BirthDate = new DateTime(1970, 7, 4), FirstEpisodeDate = new DateTime(2020, 5, 1), LastEpisodeDate = new DateTime(2020, 5, 31) }
            );
            modelBuilder.Entity<Companion>().HasData(
                new Companion { CompanionId = 1, CompanionName = "Rose Tyler", WhoPlayed = "Billie Piper" },
                new Companion { CompanionId = 2, CompanionName = "Martha Jones", WhoPlayed = "Freema Agyeman" },
                new Companion { CompanionId = 3, CompanionName = "Donna Noble", WhoPlayed = "Catherine Tate" },
                new Companion { CompanionId = 4, CompanionName = "Amy Pond", WhoPlayed = "Karen Gillan" },
                new Companion { CompanionId = 5, CompanionName = "Clara Oswald", WhoPlayed = "Jenna Coleman" }
            );
            modelBuilder.Entity<Enemy>().HasData(
                new Enemy { EnemyId = 1, EnemyName = "Daleks", Description = "Exterminate! Exterminate!" },
                new Enemy { EnemyId = 2, EnemyName = "Cybermen", Description = "Upgrade in progress." },
                new Enemy { EnemyId = 3, EnemyName = "The Master", Description = "Oh, you know who I am." },
                new Enemy { EnemyId = 4, EnemyName = "Weeping Angels", Description = "Don't blink!" },
                new Enemy { EnemyId = 5, EnemyName = "Silence", Description = "You forget them as soon as you look away." }
            );
            modelBuilder.Entity<Episode>().HasData(
                new Episode
                {
                    EpisodeId = 1,
                    SeriesNumber = 1,
                    EpisodeNumber = 1,
                    EpisodeType = "Regular",
                    Title = "An Unearthly Child",
                    EpisodeDate = new DateTime(1963, 11, 23),
                    Notes = "First appearance of the Doctor and the TARDIS.",
                    AuthorId = 1,
                    DoctorId = 1
                },
                new Episode
                {
                    EpisodeId = 2,
                    SeriesNumber = 2,
                    EpisodeNumber = 4,
                    EpisodeType = "Regular",
                    Title = "The Romans",
                    EpisodeDate = new DateTime(1965, 1, 16),
                    Notes = "Historical adventure featuring the first Doctor.",
                    AuthorId = 2,
                    DoctorId = 1
                },
                new Episode
                {
                    EpisodeId = 3,
                    SeriesNumber = 3,
                    EpisodeNumber = 10,
                    EpisodeType = "Regular",
                    Title = "The War Machines",
                    EpisodeDate = new DateTime(1966, 6, 25),
                    Notes = "First appearance of Ben and Polly.",
                    AuthorId = 3,
                    DoctorId = 2
                },
                new Episode
                {
                    EpisodeId = 4,
                    SeriesNumber = 4,
                    EpisodeNumber = 2,
                    EpisodeType = "Regular",
                    Title = "The Highlanders",
                    EpisodeDate = new DateTime(1966, 12, 17),
                    Notes = "Historical adventure featuring the second Doctor.",
                    AuthorId = 4,
                    DoctorId = 2
                },
                new Episode
                {
                    EpisodeId = 5,
                    SeriesNumber = 5,
                    EpisodeNumber = 1,
                    EpisodeType = "Regular",
                    Title = "Tomb of the Cybermen",
                    EpisodeDate = new DateTime(1967, 9, 2),
                    Notes = "First appearance of Victoria Waterfield.",
                    AuthorId = 5,
                    DoctorId = 2
                }
                );
            modelBuilder.Entity<EpisodeCompanion>().HasData(
                new EpisodeCompanion { EpisodeId = 1, CompanionId = 2 },
                new EpisodeCompanion { EpisodeId = 3, CompanionId = 2 },
                new EpisodeCompanion { EpisodeId = 5, CompanionId = 1 },
                new EpisodeCompanion { EpisodeId = 3, CompanionId = 4 },
                new EpisodeCompanion { EpisodeId = 2, CompanionId = 5 }
                );
            modelBuilder.Entity<EpisodeEnemy>().HasData(
                new EpisodeEnemy { EpisodeId = 1, EnemyId = 2 },
                new EpisodeEnemy { EpisodeId = 3, EnemyId = 2 },
                new EpisodeEnemy { EpisodeId = 5, EnemyId = 1 },
                new EpisodeEnemy { EpisodeId = 3, EnemyId = 4 },
                new EpisodeEnemy { EpisodeId = 2, EnemyId = 5 }
                );
        }
    }
}
