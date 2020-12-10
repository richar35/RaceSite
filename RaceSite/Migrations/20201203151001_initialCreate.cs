using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RaceSite.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Race",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaceDate = table.Column<DateTime>(nullable: false),
                    RaceName = table.Column<string>(maxLength: 80, nullable: false),
                    City = table.Column<string>(maxLength: 30, nullable: true),
                    State = table.Column<string>(maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Race", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Shoe",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Use = table.Column<string>(nullable: false),
                    Support = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoe", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Registrant",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 30, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: true),
                    City = table.Column<string>(maxLength: 30, nullable: true),
                    State = table.Column<string>(maxLength: 2, nullable: true),
                    Zip = table.Column<string>(maxLength: 10, nullable: true),
                    Email = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    RaceId = table.Column<int>(nullable: false),
                    ShoeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrant", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Registrant_Race_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Race",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Registrant_Shoe_ShoeId",
                        column: x => x.ShoeId,
                        principalTable: "Shoe",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrantID = table.Column<int>(nullable: false),
                    RaceID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Participants_Race_RaceID",
                        column: x => x.RaceID,
                        principalTable: "Race",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participants_Registrant_RegistrantID",
                        column: x => x.RegistrantID,
                        principalTable: "Registrant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Race",
                columns: new[] { "ID", "City", "RaceDate", "RaceName", "State" },
                values: new object[,]
                {
                    { 1, "Traverse City", new DateTime(2021, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bayshore Marathon Half Marathon & 10K", "MI" },
                    { 2, "Grand Rapids", new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gazelle Girl Half Marathon 10K & 5K", "MI" },
                    { 3, "Indianapolis", new DateTime(2021, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turkey Legs Trifecta & Half Marathon", "IN" },
                    { 4, "Cocoa", new DateTime(2021, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Space Coast Marathon", "FL" },
                    { 5, "Jackson", new DateTime(2021, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grand Teton Half Marathon", "WY" }
                });

            migrationBuilder.InsertData(
                table: "Shoe",
                columns: new[] { "ID", "Brand", "Name", "Support", "Use" },
                values: new object[,]
                {
                    { 1, "Brooks", "Ghost 13", "Neutral", "Road Running" },
                    { 2, "Hoka", "Tennine", "Stability", "Trail Running" },
                    { 3, "Saucany", "Triumph 17 LE", "Neutral", "Road Running" },
                    { 4, "Brooks", "Glycerin", "Neutral", "Road Running" }
                });

            migrationBuilder.InsertData(
                table: "Registrant",
                columns: new[] { "ID", "Address", "Age", "City", "Email", "FirstName", "LastName", "PhoneNumber", "RaceId", "ShoeId", "State", "Zip" },
                values: new object[,]
                {
                    { 1, "100 Willow St.", 34, "Traverse City", "runnerguy12@gmail.com", "Adam", "Anderson", "(231)123-2222", 1, 2, "MI", "49696" },
                    { 2, "345 Park Ave.", 47, "Clare", "maryh@gmail.com", "Mary", "Hall", "(231)123-2345", 1, 2, "MI", "49696" },
                    { 3, "5687 Pine St.", 63, "Inaianapolis", "bobtheman12@gmail.com", "Bob", "Wilson", "(231)123-3456", 1, 2, "IN", "46298" },
                    { 4, "43 Bark Rd.", 26, "Belleville", "runnersam56@gmail.com", "Sam", "Richards", "(231)123-4567", 1, 2, "AR", "72824" },
                    { 5, "785 Washer Ln.", 51, "Cocoa Beach", "claire543@gmail.com", "Claire", "Rice", "(231)123-5678", 1, 2, "FL", "32932" },
                    { 6, "41 Stark Rd.", 19, "Jackson", "alexb77@gmail.com", "Alex", "Berkley", "(231)123-6789", 1, 2, "WY", "83002" },
                    { 7, "634 Ridge Hwy", 37, "Kalkaska", "emmarunnergirl@gmail.com", "Emma", "Rogers", "(231)123-7891", 1, 2, "MI", "49646" },
                    { 8, "790 Valley Rd", 49, "Bude", "lanea1@gmail.com", "April", "Lane", "(231)123-8912", 1, 2, "MS", "39630" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participants_RaceID",
                table: "Participants",
                column: "RaceID");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_RegistrantID",
                table: "Participants",
                column: "RegistrantID");

            migrationBuilder.CreateIndex(
                name: "IX_Registrant_RaceId",
                table: "Registrant",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrant_ShoeId",
                table: "Registrant",
                column: "ShoeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "Registrant");

            migrationBuilder.DropTable(
                name: "Race");

            migrationBuilder.DropTable(
                name: "Shoe");
        }
    }
}
