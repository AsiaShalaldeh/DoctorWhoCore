using Microsoft.EntityFrameworkCore;

namespace DoctorWho.DB.Repositories
{
    public class EpisodeRepository
    {
        private readonly DoctorWhoCoreDbContext _context;
        public EpisodeRepository(DoctorWhoCoreDbContext context)
        {
            _context = context;
        }
        public void GetEpisodes()
        {
            var episodes = _context.Episodes
            .FromSqlInterpolated($"SELECT * FROM dbo.updatedViewEpisodes")
            .Select(e => new
            {
                EpisodeId = e.EpisodeId,
                DoctorName = _context.Doctors.Where(d => d.DoctorId == e.DoctorId)
                .Select(d => d.DoctorName).ToList(),
                AuthorName = _context.Authors.Where(a => a.AuthorId == e.AuthorId)
                .Select(a => a.AuthorName).ToList(),
                Companions = e.EpisodeCompanions.Select(ec => ec.Companion.CompanionName),
                Enemies = e.EpisodeEnemies.Select(ee => ee.Enemy.EnemyName)
            })
            .ToList();
            foreach (var episode in episodes)
            {
                Console.Write(episode.EpisodeId + "  ");
                Console.Write(episode.DoctorName.FirstOrDefault() + "  ");
                Console.Write(episode.AuthorName.FirstOrDefault() + "  ");
                Console.Write(episode.Companions.Count() + "  ");
                Console.WriteLine(episode.Enemies.Count());
            }

        }
        public void ExecuteSummariseEpisodes()
        {
            var results = _context.EpisodeSummary
                .FromSqlRaw("EXEC dbo.SummariseEpisodesProc")
                .ToList();

            Console.WriteLine("The 3 most frequently-appearing companions: ");
            foreach (var companion in results)
            {
                if (companion.Type.Equals("Companion"))
                {
                    Console.Write(companion.Id + "  ");
                    Console.Write(companion.Name + "  ");
                    Console.WriteLine(companion.Count);
                }
            }

            Console.WriteLine("The 3 most frequently-appearing enemies: ");
            foreach (var enemy in results)
            {
                if (enemy.Type.Equals("Enemy"))
                {
                    Console.Write(enemy.Id + "  ");
                    Console.Write(enemy.Name + "  ");
                    Console.WriteLine(enemy.Count);
                }
            }
        }
        public void CreateEpisode()
        {
            var episode = new Episode
            {
                SeriesNumber = 6,
                EpisodeNumber = 6,
                EpisodeType = "Regular",
                Title = "An Unearthly Kid",
                EpisodeDate = new DateTime(1963, 12, 23),
                Notes = "First appearance of the Doctor and the TARDIS.",
                AuthorId = 7,
                DoctorId = 5
            };
            _context.Episodes.Add(episode);
            _context.SaveChanges();
        }
        public void UpdateEpisode()
        {
            var episode = _context.Episodes.Where(e => e.EpisodeId == 7).FirstOrDefault();
            episode.EpisodeDate = new DateTime(1963, 12, 26);
            episode.AuthorId = 5;
            _context.SaveChanges();
        }
        public void DeleteEpisode()
        {
            var episode = _context.Episodes.Where(e => e.EpisodeId == 7).FirstOrDefault();
            _context.Episodes.Remove(episode);
            _context.SaveChanges();
        }
    }
}
