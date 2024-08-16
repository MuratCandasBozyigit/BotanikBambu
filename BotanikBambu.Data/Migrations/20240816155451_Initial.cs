using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BotanikBambu.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Truckers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TruckerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TruckerSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TruckPlate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HexCode = table.Column<int>(type: "int", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Truckers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bambus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    ProfilePhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bambus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bambus_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    Gsm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    ApplicationForm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoverPicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BambuId = table.Column<int>(type: "int", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Bambus_BambuId",
                        column: x => x.BambuId,
                        principalTable: "Bambus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Receipt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<double>(type: "float", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "DateDeleted", "DateUpdated", "IsActive", "IsDeleted", "ModifierId", "Name", "OwnerId" },
                values: new object[,]
                {
                    { 1, null, null, true, false, null, "Adana", null },
                    { 2, null, null, true, false, null, "Adıyaman", null },
                    { 3, null, null, true, false, null, "Afyonkarahisar", null },
                    { 4, null, null, true, false, null, "Ağrı", null },
                    { 5, null, null, true, false, null, "Amasya", null },
                    { 6, null, null, true, false, null, "Ankara", null },
                    { 7, null, null, true, false, null, "Antalya", null },
                    { 8, null, null, true, false, null, "Artvin", null },
                    { 9, null, null, true, false, null, "Aydın", null },
                    { 10, null, null, true, false, null, "Balıkesir", null },
                    { 11, null, null, true, false, null, "Bilecik", null },
                    { 12, null, null, true, false, null, "Bingöl", null },
                    { 13, null, null, true, false, null, "Bitlis", null },
                    { 14, null, null, true, false, null, "Bolu", null },
                    { 15, null, null, true, false, null, "Burdur", null },
                    { 16, null, null, true, false, null, "Bursa", null },
                    { 17, null, null, true, false, null, "Çanakkale", null },
                    { 18, null, null, true, false, null, "Çankırı", null },
                    { 19, null, null, true, false, null, "Çorum", null },
                    { 20, null, null, true, false, null, "Denizli", null },
                    { 21, null, null, true, false, null, "Diyarbakır", null },
                    { 22, null, null, true, false, null, "Edirne", null },
                    { 23, null, null, true, false, null, "Elazığ", null },
                    { 24, null, null, true, false, null, "Erzincan", null },
                    { 25, null, null, true, false, null, "Erzurum", null },
                    { 26, null, null, true, false, null, "Eskişehir", null },
                    { 27, null, null, true, false, null, "Gaziantep", null },
                    { 28, null, null, true, false, null, "Giresun", null },
                    { 29, null, null, true, false, null, "Gümüşhane", null },
                    { 30, null, null, true, false, null, "Hakkâri", null },
                    { 31, null, null, true, false, null, "Hatay", null },
                    { 32, null, null, true, false, null, "Isparta", null },
                    { 33, null, null, true, false, null, "Mersin", null },
                    { 34, null, null, true, false, null, "İstanbul", null },
                    { 35, null, null, true, false, null, "İzmir", null },
                    { 36, null, null, true, false, null, "Kars", null },
                    { 37, null, null, true, false, null, "Kastamonu", null },
                    { 38, null, null, true, false, null, "Kayseri", null },
                    { 39, null, null, true, false, null, "Kırklareli", null },
                    { 40, null, null, true, false, null, "Kırşehir", null },
                    { 41, null, null, true, false, null, "Kocaeli", null },
                    { 42, null, null, true, false, null, "Konya", null },
                    { 43, null, null, true, false, null, "Kütahya", null },
                    { 44, null, null, true, false, null, "Malatya", null },
                    { 45, null, null, true, false, null, "Manisa", null },
                    { 46, null, null, true, false, null, "Kahramanmaraş", null },
                    { 47, null, null, true, false, null, "Mardin", null },
                    { 48, null, null, true, false, null, "Muğla", null },
                    { 49, null, null, true, false, null, "Muş", null },
                    { 50, null, null, true, false, null, "Nevşehir", null },
                    { 51, null, null, true, false, null, "Niğde", null },
                    { 52, null, null, true, false, null, "Ordu", null },
                    { 53, null, null, true, false, null, "Rize", null },
                    { 54, null, null, true, false, null, "Sakarya", null },
                    { 55, null, null, true, false, null, "Samsun", null },
                    { 56, null, null, true, false, null, "Siirt", null },
                    { 57, null, null, true, false, null, "Sinop", null },
                    { 58, null, null, true, false, null, "Sivas", null },
                    { 59, null, null, true, false, null, "Tekirdağ", null },
                    { 60, null, null, true, false, null, "Tokat", null },
                    { 61, null, null, true, false, null, "Trabzon", null },
                    { 62, null, null, true, false, null, "Tunceli", null },
                    { 63, null, null, true, false, null, "Şanlıurfa", null },
                    { 64, null, null, true, false, null, "Uşak", null },
                    { 65, null, null, true, false, null, "Van", null },
                    { 66, null, null, true, false, null, "Yozgat", null },
                    { 67, null, null, true, false, null, "Zonguldak", null },
                    { 68, null, null, true, false, null, "Aksaray", null },
                    { 69, null, null, true, false, null, "Bayburt", null },
                    { 70, null, null, true, false, null, "Karaman", null },
                    { 71, null, null, true, false, null, "Kırıkkale", null },
                    { 72, null, null, true, false, null, "Batman", null },
                    { 73, null, null, true, false, null, "Şırnak", null },
                    { 74, null, null, true, false, null, "Bartın", null },
                    { 75, null, null, true, false, null, "Ardahan", null },
                    { 76, null, null, true, false, null, "Iğdır", null },
                    { 77, null, null, true, false, null, "Yalova", null },
                    { 78, null, null, true, false, null, "Karabük", null },
                    { 79, null, null, true, false, null, "Kilis", null },
                    { 80, null, null, true, false, null, "Osmaniye", null },
                    { 81, null, null, true, false, null, "Düzce", null }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "DateDeleted", "DateUpdated", "IsActive", "IsDeleted", "ModifierId", "Name", "OwnerId" },
                values: new object[,]
                {
                    { 1, null, null, true, false, null, "Kadın", null },
                    { 2, null, null, true, false, null, "Erkek", null },
                    { 3, null, null, true, false, null, "Diğer", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bambus_ColorId",
                table: "Bambus",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_BambuId",
                table: "Carts",
                column: "BambuId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_CartId",
                table: "Photos",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CityId",
                table: "Users",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GenderId",
                table: "Users",
                column: "GenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Truckers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Bambus");

            migrationBuilder.DropTable(
                name: "Colors");
        }
    }
}
