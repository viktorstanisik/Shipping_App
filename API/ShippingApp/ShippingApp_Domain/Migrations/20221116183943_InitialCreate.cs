using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingAppDomain.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarrierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageWidth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageHeight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageDepth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageWeight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageOfferPrice = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOffers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserOffers");
        }
    }
}
