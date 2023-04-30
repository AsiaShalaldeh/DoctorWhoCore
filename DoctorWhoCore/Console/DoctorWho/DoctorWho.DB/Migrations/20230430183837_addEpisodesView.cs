using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.DB.Migrations
{
    /// <inheritdoc />
    public partial class addEpisodesView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE VIEW dbo.viewEpisodes AS
                    SELECT e.EpisodeId, a.AuthorName, d.DoctorName, 
	                       dbo.fnCompanions(e.EpisodeId) AS Companions,
	                       dbo.fnEnemies(e.EpisodeId) AS Enemies
                    FROM Episodes AS e, Authors AS a, Doctor AS d
                    WHERE e.AuthorId = a.AuthorId AND
	                      d.DoctorId = e.DoctorId;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW dbo.viewEpisodes");
        }
    }
}
