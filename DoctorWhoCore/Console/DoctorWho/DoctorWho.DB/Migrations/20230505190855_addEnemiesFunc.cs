using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.DB.Migrations
{
    /// <inheritdoc />
    public partial class addEnemiesFunc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
               @"CREATE FUNCTION dbo.fnEnemies (@EpisodeId int)
                RETURNS TABLE
                AS
                RETURN (
                    SELECT EnemyName
                    FROM Enemies AS en
                    JOIN EpisodeEnemies AS ee ON en.EnemyId = ee.EnemyId
                    JOIN Episodes AS e ON ee.EpisodeId = e.EpisodeId
                    WHERE e.EpisodeId = @EpisodeId
                );
                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP FUNCTION dbo.fnEnemies");
        }
    }
}
