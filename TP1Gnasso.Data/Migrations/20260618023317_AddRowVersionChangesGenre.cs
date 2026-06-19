using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP1Gnasso.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRowVersionChangesGenre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Genres");
            migrationBuilder.Sql("DBCC CHECKIDENT ('Genres', RESEED, 0)");

            migrationBuilder.Sql("INSERT INTO Genres (GenreName, Active) VALUES ('Hombre', 1)");
            migrationBuilder.Sql("INSERT INTO Genres (GenreName, Active) VALUES ('Mujer', 1)");
            migrationBuilder.Sql("INSERT INTO Genres (GenreName, Active) VALUES ('Unisex', 1)");

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "SportShoes",
                type: "int",
                nullable: false,
                defaultValue: 3);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SportShoes",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Sports",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Sizes",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Brands",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.CreateIndex(
                name: "IX_SportShoes_GenreId",
                table: "SportShoes",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_SportShoes_Model_SizeId",
                table: "SportShoes",
                columns: new[] { "Model", "SizeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sports_Name",
                table: "Sports",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_Number",
                table: "Sizes",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX:Brands_Name",
                table: "Brands",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SportShoes_Genres_GenreId",
                table: "SportShoes",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SportShoes_Genres_GenreId",
                table: "SportShoes");

            migrationBuilder.DropIndex(
                name: "IX_SportShoes_GenreId",
                table: "SportShoes");

            migrationBuilder.DropIndex(
                name: "IX_SportShoes_Model_SizeId",
                table: "SportShoes");

            migrationBuilder.DropIndex(
                name: "IX_Sports_Name",
                table: "Sports");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_Number",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX:Brands_Name",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "SportShoes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SportShoes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Brands");
        }
    }
}
