using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movies.Migrations
{
    /// <inheritdoc />
    public partial class _2ndInitialization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PersonMovieMaps_MovieID",
                table: "PersonMovieMaps",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonMovieMaps_PersonID",
                table: "PersonMovieMaps",
                column: "PersonID");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonMovieMaps_moviesViewModels_MovieID",
                table: "PersonMovieMaps",
                column: "MovieID",
                principalTable: "moviesViewModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonMovieMaps_personsViewModels_PersonID",
                table: "PersonMovieMaps",
                column: "PersonID",
                principalTable: "personsViewModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonMovieMaps_moviesViewModels_MovieID",
                table: "PersonMovieMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonMovieMaps_personsViewModels_PersonID",
                table: "PersonMovieMaps");

            migrationBuilder.DropIndex(
                name: "IX_PersonMovieMaps_MovieID",
                table: "PersonMovieMaps");

            migrationBuilder.DropIndex(
                name: "IX_PersonMovieMaps_PersonID",
                table: "PersonMovieMaps");
        }
    }
}
