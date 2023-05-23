using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.DB.Migrations
{
    /// <inheritdoc />
    public partial class summaryEpisodeFunc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
              @"CREATE PROCEDURE dbo.SummariseEpisodesProc 
                    AS BEGIN
	                    SELECT TOP 3 Id, Name, Count, Type
                        FROM (
                            SELECT TOP 3 c.CompanionId AS Id, c.CompanionName AS Name, COUNT(ec.CompanionId) AS Count, 'Companion' AS Type
                            FROM Companions AS c
                            INNER JOIN EpisodeCompanions AS ec ON c.CompanionId = ec.CompanionId
                            GROUP BY c.CompanionId, c.CompanionName
                            ORDER BY Count DESC
                        ) AS companions
                        UNION ALL
                        SELECT TOP 3 Id, Name, Count, Type
                        FROM (
                            SELECT TOP 3 e.EnemyId AS Id, e.EnemyName AS Name, COUNT(ee.EnemyId) AS Count, 'Enemy' AS Type
                            FROM Enemies AS e
                            INNER JOIN EpisodeEnemies AS ee ON e.EnemyId = ee.EnemyId
                            GROUP BY e.EnemyId, e.EnemyName
                            ORDER BY Count DESC
                        ) AS enemies;
                    END;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE dbo.SummariseEpisodesProc");
        }
    }
}
