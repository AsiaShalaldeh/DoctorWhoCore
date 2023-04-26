using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DoctorWho.DB.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "AuthorName" },
                values: new object[,]
                {
                    { 1, "John Doe" },
                    { 2, "Jane Doe" },
                    { 3, "Bob Smith" },
                    { 4, "Alice Johnson" },
                    { 5, "Tom Lee" }
                });

            migrationBuilder.InsertData(
                table: "Companions",
                columns: new[] { "CompanionId", "CompanionName", "WhoPlayed" },
                values: new object[,]
                {
                    { 1, "Rose Tyler", "Billie Piper" },
                    { 2, "Martha Jones", "Freema Agyeman" },
                    { 3, "Donna Noble", "Catherine Tate" },
                    { 4, "Amy Pond", "Karen Gillan" },
                    { 5, "Clara Oswald", "Jenna Coleman" }
                });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "DoctorId", "BirthDate", "DoctorName", "DoctorNumber", "FirstEpisodeDate", "LastEpisodeDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Smith", 1234, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1975, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane Doe", 5678, new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1990, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bob Johnson", 9012, new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(1985, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alice Lee", 3456, new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(1970, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tom Wilson", 7890, new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Enemies",
                columns: new[] { "EnemyId", "Description", "EnemyName" },
                values: new object[,]
                {
                    { 1, "Exterminate! Exterminate!", "Daleks" },
                    { 2, "Upgrade in progress.", "Cybermen" },
                    { 3, "Oh, you know who I am.", "The Master" },
                    { 4, "Don't blink!", "Weeping Angels" },
                    { 5, "You forget them as soon as you look away.", "Silence" }
                });

            migrationBuilder.InsertData(
                table: "Episodes",
                columns: new[] { "EpisodeId", "AuthorId", "DoctorId", "EpisodeDate", "EpisodeNumber", "EpisodeType", "Notes", "SeriesNumber", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(1963, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Regular", "First appearance of the Doctor and the TARDIS.", 1, "An Unearthly Child" },
                    { 2, 2, 1, new DateTime(1965, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Regular", "Historical adventure featuring the first Doctor.", 2, "The Romans" },
                    { 3, 3, 2, new DateTime(1966, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Regular", "First appearance of Ben and Polly.", 3, "The War Machines" },
                    { 4, 4, 2, new DateTime(1966, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Regular", "Historical adventure featuring the second Doctor.", 4, "The Highlanders" },
                    { 5, 5, 2, new DateTime(1967, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Regular", "First appearance of Victoria Waterfield.", 5, "Tomb of the Cybermen" }
                });

            migrationBuilder.InsertData(
                table: "EpisodeCompanion",
                columns: new[] { "EpisodeCompanionId", "CompanionId", "EpisodeId" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 2, 2, 3 },
                    { 3, 1, 5 },
                    { 4, 4, 3 },
                    { 5, 5, 2 }
                });

            migrationBuilder.InsertData(
                table: "EpisodeEnemy",
                columns: new[] { "EnemyId", "EpisodeId", "EpisodEnemyId" },
                values: new object[,]
                {
                    { 1, 5, 3 },
                    { 2, 1, 1 },
                    { 2, 3, 2 },
                    { 4, 3, 4 },
                    { 5, 2, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "DoctorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "DoctorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "DoctorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemy",
                keyColumns: new[] { "EnemyId", "EpisodeId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "EpisodeEnemy",
                keyColumns: new[] { "EnemyId", "EpisodeId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "EpisodeEnemy",
                keyColumns: new[] { "EnemyId", "EpisodeId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "EpisodeEnemy",
                keyColumns: new[] { "EnemyId", "EpisodeId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "EpisodeEnemy",
                keyColumns: new[] { "EnemyId", "EpisodeId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "DoctorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "DoctorId",
                keyValue: 2);
        }
    }
}
