using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.DB.Migrations
{
    /// <inheritdoc />
    public partial class updateCompanionsFunc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE FUNCTION dbo.fnCompanionsNames (@EpisodeId int)
                RETURNS TABLE
                AS
                RETURN (
                    SELECT CompanionName
                    FROM Companions AS c
                    JOIN EpisodeCompanions AS ec ON c.CompanionId = ec.CompanionId
                    JOIN Episodes AS e ON ec.EpisodeId = e.EpisodeId
                    WHERE e.EpisodeId = @EpisodeId
                );");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP FUNCTION dbo.fnCompanionsNames");
        }
    }
}
