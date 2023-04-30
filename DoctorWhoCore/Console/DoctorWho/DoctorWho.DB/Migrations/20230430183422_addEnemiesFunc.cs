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
                    RETURNS varchar(25) AS
                    BEGIN
                       DECLARE @Enemies varchar(25)
                       SELECT @Enemies = COALESCE(@Enemies + ', ', '') + EnemyName
                       FROM Enemies AS en, EpisodeEnemy AS ee, Episodes AS e
                       WHERE e.EpisodeId = @EpisodeId AND 
                       en.EnemyId = ee.EnemyId AND
                       ee.EpisodeId = e.EpisodeId
                       RETURN @Enemies
                    END;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP FUNCTION dbo.fnEnemies");
        }
    }
}
