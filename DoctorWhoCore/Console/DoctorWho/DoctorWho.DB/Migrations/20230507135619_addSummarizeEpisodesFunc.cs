﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.DB.Migrations
{
    /// <inheritdoc />
    public partial class addSummarizeEpisodesFunc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
               @"CREATE PROCEDURE dbo.spSummariseEpisodes 
                    AS BEGIN
	                    SELECT TOP 3 c.CompanionId, c.CompanionName, COUNT(ec.CompanionId) AS num_companions
	                    FROM Companions AS c, EpisodeCompanions AS ec
	                    WHERE c.CompanionId = ec.CompanionId
	                    GROUP BY c.CompanionId, c.CompanionName
	                    ORDER BY COUNT(ec.CompanionId) DESC;

	                    SELECT TOP 3 e.EnemyId, e.EnemyName, COUNT(ee.EnemyId) AS num_enemies
	                    FROM Enemies AS e, EpisodeEnemies AS ee
	                    WHERE e.EnemyId = ee.EnemyId
	                    GROUP BY e.EnemyId, e.EnemyName
	                    ORDER BY COUNT(ee.EnemyId) DESC;
                    END;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE dbo.spSummariseEpisodes");
        }
    }
}
