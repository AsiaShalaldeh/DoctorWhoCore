using DoctorWho.DB;
using DoctorWho.DB.Repositories;

DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
EnemyRepository enemy = new EnemyRepository(_context);
CompanionRepository companion = new CompanionRepository(_context);
EpisodeRepository episode = new EpisodeRepository(_context);

//companion.GetCompanionsNames(3);

//enemy.GetEnemiesNames(3);

//episode.GetEpisodes();

episode.ExecuteSummariseEpisodes();















