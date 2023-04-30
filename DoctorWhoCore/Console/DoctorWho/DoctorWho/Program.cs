using DoctorWho.DB;
using Microsoft.EntityFrameworkCore;

DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();

void GetCompanionsNames()
{
    //int episodeId = 2;
    //var companionsNames = _context.Companions.FromSqlRaw(
    //    "SELECT dbo.fnCompanions({0})", episodeId)
    //    .Select(c => c.CompanionName)
    //    .ToList();

    //foreach (var companionsName in companionsNames)
    //    Console.WriteLine("Name " + companionsName);
}

//GetCompanionsNames();
void GetSummariseEpisodes()
{
    //var summariseEpisodes = _context.Episodes.
    //    FromSqlRaw("dbo.spSummariseEpisodes").ToList();

}
//GetSummariseEpisodes();