using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.DB.Migrations
{
    /// <inheritdoc />
    public partial class summaryFunc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
              @"CREATE PROCEDURE dbo.SummariseEpisodes 
                    AS BEGIN
	                    SELECT TOP 3 c.CompanionId As Id, c.CompanionName AS Name, COUNT(ec.CompanionId) AS Count, 'Comapnion' AS Type
	                    FROM Companions AS c, EpisodeCompanions AS ec
	                    WHERE c.CompanionId = ec.CompanionId
	                    GROUP BY c.CompanionId, c.CompanionName
	                    ORDER BY Count DESC

	                    SELECT TOP 3 e.EnemyId AS Id, e.EnemyName AS Name, COUNT(ee.EnemyId) AS Count, 'Enemy' AS Type
	                    FROM Enemies AS e, EpisodeEnemies AS ee
	                    WHERE e.EnemyId = ee.EnemyId
	                    GROUP BY e.EnemyId, e.EnemyName
	                    ORDER BY Count DESC;
                    END;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE dbo.SummariseEpisodes");
        }
    }
}
