using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.DB.Migrations
{
    /// <inheritdoc />
    public partial class addCompanionsFunc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE FUNCTION dbo.fnCompanions (@EpisodeId int)
                    RETURNS varchar(255) AS
                    BEGIN
                       DECLARE @Companions varchar(255)
                       SELECT @Companions = COALESCE(@Companions + ', ', '') + CompanionName
                       FROM Companions AS c, EpisodeCompanion AS ec, Episodes AS e
                       WHERE e.EpisodeId = @EpisodeId AND 
                       c.CompanionId = ec.CompanionId AND
                       ec.EpisodeId = e.EpisodeId
                       RETURN @Companions
                    END;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP FUNCTION dbo.fnCompanions");
        }
    }
}
