using Microsoft.EntityFrameworkCore;

namespace DoctorWho.DB.Repositories
{
    public class EnemyRepository
    {
        private readonly DoctorWhoCoreDbContext _context;
        public EnemyRepository(DoctorWhoCoreDbContext context)
        {
            _context = context;
        }
        public void GetEnemyById()
        {
            var enemy = _context.Enemies.Where(e => e.EnemyId == 3).FirstOrDefault();
            Console.WriteLine("Enemy Id: " + enemy.EnemyId);
            Console.WriteLine("Enemy Name: " + enemy.EnemyName);
            Console.WriteLine("Enemy Description: " + enemy.Description);
        }
        public void GetEnemiesNames(int episodeId)
        {
            var enemiesNames = _context.Enemies.FromSqlInterpolated(
                $"SELECT EnemyName from dbo.fnEnemies({episodeId})")
                .Select(e => e.EnemyName)
                .ToList();

            Console.WriteLine("Enemies Names: ");
            foreach (var enemyName in enemiesNames)
                Console.WriteLine("Name: " + enemyName);
        }
        public void CreateEnemy()
        {
            var enemy = new Enemy { EnemyName = "The King", Description = "Exterminate! Exterminate!" };
            _context.Enemies.Add(enemy);
            _context.SaveChanges();
        }
        public void UpdateEnemy()
        {
            var enemy = _context.Enemies.Where(e => e.EnemyId == 1).FirstOrDefault();
            enemy.EnemyName = "The Queen";
            enemy.Description = "I am the Queen now";
            _context.SaveChanges();
        }
        public void DeleteEnemy()
        {
            var enemy = _context.Enemies.Where(e => e.EnemyId == 6).FirstOrDefault();
            _context.Enemies.Remove(enemy);
            _context.SaveChanges();
        }
        public void AddEnemyToEpisode()
        {
            var enemy = _context.Enemies.Where(e => e.EnemyId == 3).FirstOrDefault();
            var episode = _context.Episodes.Where(ep => ep.EpisodeId == 5).FirstOrDefault();

            var episodeEnemy = new EpisodeEnemy
            {
                Enemy = enemy,
                Episode = episode
            };
            _context.EpisodeEnemies.Add(episodeEnemy);
            _context.SaveChanges();
        }
    }
}
