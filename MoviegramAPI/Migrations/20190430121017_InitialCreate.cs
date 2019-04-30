using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviegramAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Details = table.Column<string>(nullable: true),
                    Thumbnail = table.Column<byte[]>(nullable: true),
                    FullImage = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "MovieViewTime",
                columns: table => new
                {
                    MovieViewTimeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateTime = table.Column<DateTime>(nullable: false),
                    MovieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieViewTime", x => x.MovieViewTimeId);
                    table.ForeignKey(
                        name: "FK_MovieViewTime_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "MovieId", "Details", "FullImage", "Thumbnail" },
                values: new object[] { 1, "Movie 1 details - this movie only has 1 viewing time", null, null });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "MovieId", "Details", "FullImage", "Thumbnail" },
                values: new object[] { 2, "Movie 2 details - this movie has 2 viewing times", null, null });

            migrationBuilder.InsertData(
                table: "MovieViewTime",
                columns: new[] { "MovieViewTimeId", "DateTime", "MovieId" },
                values: new object[] { 1, new DateTime(2000, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "MovieViewTime",
                columns: new[] { "MovieViewTimeId", "DateTime", "MovieId" },
                values: new object[] { 2, new DateTime(2000, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.InsertData(
                table: "MovieViewTime",
                columns: new[] { "MovieViewTimeId", "DateTime", "MovieId" },
                values: new object[] { 3, new DateTime(2000, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.CreateIndex(
                name: "IX_MovieViewTime_MovieId",
                table: "MovieViewTime",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieViewTime");

            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}
