using DoctorWho.DB;
using Microsoft.EntityFrameworkCore;

DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();

string GetCompanionsNames(int episodeId)
{
    var companionsNames = _context.Companions.FromSqlInterpolated(
        $"SELECT CompanionName from dbo.fnCompanionsNames({episodeId})")
        .Select(c => c.CompanionName)
        .ToList();

    string names = "";
    Console.WriteLine("Companions Names: ");
    foreach (var companionsName in companionsNames)
        names += companionsName + ", ";
    return names;
}

//GetCompanionsNames(3);

string GetEnemiesNames(int episodeId)
{
    var enemiesNames = _context.Enemies.FromSqlInterpolated(
        $"SELECT EnemyName from dbo.fnEnemies({episodeId})")
        .Select(e => e.EnemyName)
        .ToList();

    string names = "";
    Console.WriteLine("Enemies Names: ");
    foreach (var enemyName in enemiesNames)
        names += enemyName + ", ";
    return names;
}

//GetEnemiesNames(3);

void GetEpisodes()
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
//GetEpisodes();

void ExecuteSummariseEpisodes()
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

ExecuteSummariseEpisodes();