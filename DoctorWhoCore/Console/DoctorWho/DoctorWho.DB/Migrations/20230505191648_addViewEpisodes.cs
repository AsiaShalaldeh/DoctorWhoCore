using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.DB.Migrations
{
    /// <inheritdoc />
    public partial class addViewEpisodes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
                migrationBuilder.Sql(
                        @"CREATE VIEW dbo.viewEpisodes AS
                        SELECT e.EpisodeId, a.AuthorName, d.DoctorName, 
                                c.Companions, en.Enemies
                        FROM Episodes AS e
                        JOIN Authors AS a ON e.AuthorId = a.AuthorId
                        JOIN Doctors AS d ON e.DoctorId = d.DoctorId
                        CROSS APPLY (
                            SELECT STRING_AGG(c.CompanionName, ', ') AS Companions
                            FROM EpisodeCompanions AS ec
                            JOIN Companions AS c ON ec.CompanionId = c.CompanionId
                            WHERE ec.EpisodeId = e.EpisodeId
                        ) AS c
                        CROSS APPLY (
                            SELECT STRING_AGG(en.EnemyName, ', ') AS Enemies
                            FROM EpisodeEnemies AS ee
                            JOIN Enemies AS en ON ee.EnemyId = en.EnemyId
                            WHERE ee.EpisodeId = e.EpisodeId
                        ) AS en;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW dbo.viewEpisodes");
        }
    }
}
