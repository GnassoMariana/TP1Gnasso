using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP1Gnasso.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Brands (Name, Country, Active) VALUES ('Nike', 'USA', 1)");
            migrationBuilder.Sql("INSERT INTO Brands (Name, Country, Active) VALUES ('Adidas', 'Germany', 1)");
            migrationBuilder.Sql("INSERT INTO Brands (Name, Country, Active) VALUES ('Puma', 'Germany', 1)");
            migrationBuilder.Sql("INSERT INTO Brands (Name, Country, Active) VALUES ('New Balance', 'USA', 1)");


            migrationBuilder.Sql("INSERT INTO Sports (Name, Active) VALUES ('Running', 1)");
            migrationBuilder.Sql("INSERT INTO Sports (Name, Active) VALUES ('Basketball', 1)");
            migrationBuilder.Sql("INSERT INTO Sports (Name, Active) VALUES ('Football', 1)");
            migrationBuilder.Sql("INSERT INTO Sports (Name, Active) VALUES ('Tennis', 1)");


            migrationBuilder.Sql("INSERT INTO Sizes (Number, Active) VALUES (38, 1)");
            migrationBuilder.Sql("INSERT INTO Sizes (Number, Active) VALUES (39, 1)");
            migrationBuilder.Sql("INSERT INTO Sizes (Number, Active) VALUES (40, 1)");
            migrationBuilder.Sql("INSERT INTO Sizes (Number, Active) VALUES (41, 1)");
            migrationBuilder.Sql("INSERT INTO Sizes (Number, Active) VALUES (42, 1)");

            migrationBuilder.Sql("INSERT INTO Genres (GenreName, Active) VALUES ('Running', 1)");
            migrationBuilder.Sql("INSERT INTO Genres (GenreName, Active) VALUES ('Training', 1)");
            migrationBuilder.Sql("INSERT INTO Genres (GenreName, Active) VALUES ('Casual', 1)");
            migrationBuilder.Sql("INSERT INTO Genres (GenreName, Active) VALUES ('Performance', 1)");

            migrationBuilder.Sql(@"INSERT INTO SportShoes (Model, Price, ReleaseDate, Active, BrandId, SizeId, SportId)
                                    VALUES ('Air Zoom Pegasus', 120000, '2025-01-15', 1, 1, 3, 1)");
            migrationBuilder.Sql(@"INSERT INTO SportShoes (Model, Price, ReleaseDate, Active, BrandId, SizeId, SportId)
                                    VALUES ('Ultraboost 5', 135000, '2025-03-10', 1, 2, 4, 1)");
            migrationBuilder.Sql(@"INSERT INTO SportShoes (Model, Price, ReleaseDate, Active, BrandId, SizeId, SportId)
                                    VALUES ('Future Rider', 98000, '2025-02-20', 1, 3, 3, 2)");
            migrationBuilder.Sql(@"INSERT INTO SportShoes (Model, Price, ReleaseDate, Active, BrandId, SizeId, SportId)
                                    VALUES ('Fresh Foam X 1080', 145000, '2025-04-12', 1, 4, 5, 1)");
            migrationBuilder.Sql(@"INSERT INTO SportShoes (Model, Price, ReleaseDate, Active, BrandId, SizeId, SportId)
                                    VALUES ('Predator League', 160000, '2025-03-05', 1, 2, 4, 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM SportShoes");
            migrationBuilder.Sql("DELETE FROM Sizes");
            migrationBuilder.Sql("DELETE FROM Genres");
            migrationBuilder.Sql("DELETE FROM Sports");
            migrationBuilder.Sql("DELETE FROM Brands");
        }
    }
}
