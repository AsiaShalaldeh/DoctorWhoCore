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

// ExecuteSummariseEpisodes();

void CreateCompanion()
{
    var companion = new Companion { CompanionName = "Jonas", WhoPlayed = "Adam" };
    _context.Companions.Add(companion);
    _context.SaveChanges();
}

// CreateCompanion();

void UpdateCompanion()
{
    var companion = _context.Companions.Where(c => c.CompanionId == 6).FirstOrDefault();
    companion.CompanionName = "Jonass";
    companion.WhoPlayed = "Tom Criuse";
    _context.SaveChanges();
}
//UpdateCompanion();
void DeleteCompanion()
{
    var companion = _context.Companions.Where(c => c.CompanionId == 1).FirstOrDefault();
    _context.Companions.Remove(companion);
    _context.SaveChanges();
}
//DeleteCompanion();

void CreateEnemy()
{
    var enemy = new Enemy { EnemyName = "The King", Description = "Exterminate! Exterminate!" };
    _context.Enemies.Add(enemy);
    _context.SaveChanges();
}
//CreateEnemy();

void UpdateEnemy()
{
    var enemy = _context.Enemies.Where(e => e.EnemyId == 1).FirstOrDefault();
    enemy.EnemyName = "The Queen";
    enemy.Description = "I am the Queen now";
    _context.SaveChanges();
}
//UpdateEnemy();

void DeleteEnemy()
{
    var enemy = _context.Enemies.Where(e => e.EnemyId == 6).FirstOrDefault();
    _context.Enemies.Remove(enemy);
    _context.SaveChanges();
}
//DeleteEnemy();

void CreateDoctor()
{
    var doctor = new Doctor { DoctorNumber = 5378, DoctorName = "Will Smith", 
        BirthDate = new DateTime(1975, 5, 10), FirstEpisodeDate = new DateTime(2020, 2, 1),
        LastEpisodeDate = new DateTime(2020, 2, 15) };
    _context.Doctors.Add(doctor);
    _context.SaveChanges();
}
//CreateDoctor();

void UpdateDoctor()
{
    var doctor = _context.Doctors.Where(d => d.DoctorId == 6).FirstOrDefault();
    doctor.DoctorNumber = 3844;
    _context.SaveChanges();
}
//UpdateDoctor();

void DeleteDoctor()
{
    var doctor = _context.Doctors.Where(d => d.DoctorId == 6).FirstOrDefault();
    _context.Doctors.Remove(doctor);
    _context.SaveChanges();
}
//DeleteDoctor();

void CreateAuthor()
{
    var author = new Author { AuthorName = "Leonardo Dicaprio" };
    _context.Authors.Add(author);
    _context.SaveChanges();
}
//CreateAuthor();

void UpdateAuthor()
{
    var author = _context.Authors.Where(a => a.AuthorId == 6).FirstOrDefault();
    author.AuthorName = "Leo Dicaprio";
    _context.SaveChanges();
}
//UpdateAuthor();

void DeleteAuthor()
{
    var author = _context.Authors.Where(a => a.AuthorId == 6).FirstOrDefault();
    _context.Authors.Remove(author);
    _context.SaveChanges();
}
//DeleteAuthor();

void CreateEpisode()
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
//CreateEpisode();

void UpdateEpisode()
{
    var episode = _context.Episodes.Where(e => e.EpisodeId == 7).FirstOrDefault();
    episode.EpisodeDate = new DateTime(1963, 12, 26);
    episode.AuthorId = 5;
    _context.SaveChanges();
}
//UpdateEpisode();

void DeleteEpisode()
{
    var episode = _context.Episodes.Where(e => e.EpisodeId == 7).FirstOrDefault();
    _context.Episodes.Remove(episode);
    _context.SaveChanges();
}
//DeleteEpisode();