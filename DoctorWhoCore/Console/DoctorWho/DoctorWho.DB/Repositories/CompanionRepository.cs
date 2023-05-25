using Microsoft.EntityFrameworkCore;

namespace DoctorWho.DB.Repositories
{
    public class CompanionRepository
    {
        private readonly DoctorWhoCoreDbContext _context;
        public CompanionRepository(DoctorWhoCoreDbContext context)
        {
            _context = context;
        }
        public void GetCompanionById()
        {
            var companion = _context.Companions.Where(c => c.CompanionId == 3).FirstOrDefault();
            Console.WriteLine("Companion Id: " + companion.CompanionId);
            Console.WriteLine("Companion Name: " + companion.CompanionName);
            Console.WriteLine("Who Played: " + companion.WhoPlayed);
        }
        public void GetCompanionsNames(int episodeId)
        {
            var companionsNames = _context.Companions.FromSqlInterpolated(
                $"SELECT CompanionName from dbo.fnCompanionsNames({episodeId})")
                .Select(c => c.CompanionName)
                .ToList();

            Console.WriteLine("Companions Names: ");
            foreach (var companionsName in companionsNames)
                Console.WriteLine("Name: " + companionsName);
        }
        public void CreateCompanion()
        {
            var companion = new Companion { CompanionName = "Jonas", WhoPlayed = "Adam" };
            _context.Companions.Add(companion);
            _context.SaveChanges();
        }

        public void UpdateCompanion()
        {
            var companion = _context.Companions.Where(c => c.CompanionId == 6).FirstOrDefault();
            companion.CompanionName = "Jonass";
            companion.WhoPlayed = "Tom Criuse";
            _context.SaveChanges();
        }
        public void DeleteCompanion()
        {
            var companion = _context.Companions.Where(c => c.CompanionId == 1).FirstOrDefault();
            _context.Companions.Remove(companion);
            _context.SaveChanges();
        }
        public void AddCompanionToEpisode()
        {
            var episode = _context.Episodes.Where(ep => ep.EpisodeId == 4).FirstOrDefault();
            var companion = _context.Companions.Where(c => c.CompanionId == 3).FirstOrDefault();

            var episodeCompanion = new EpisodeCompanion
            {
                Episode = episode,
                Companion = companion
            };
            _context.EpisodeCompanions.Add(episodeCompanion);
            _context.SaveChanges();
        }
    }
}
