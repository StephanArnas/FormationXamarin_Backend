using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CryptoBankBackend.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    Credits = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    TransactionNumber = table.Column<string>(nullable: false),
                    RecipientEmail = table.Column<string>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operation_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedDate", "Credits", "Email", "FirstName", "LastName", "ModifiedDate", "Password" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 953, DateTimeKind.Unspecified).AddTicks(3575), new TimeSpan(0, 0, 0, 0, 0)), 2265.0, "stephan.arnas@gmail.com", "Stephan", "Arnas", null, "Aze123" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedDate", "Credits", "Email", "FirstName", "LastName", "ModifiedDate", "Password" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 953, DateTimeKind.Unspecified).AddTicks(4283), new TimeSpan(0, 0, 0, 0, 0)), 125.0, "remond.dumond@gmail.com", "Remond", "Dumond", null, "Aze123" });

            migrationBuilder.InsertData(
                table: "Operation",
                columns: new[] { "Id", "Amount", "CreatedDate", "ModifiedDate", "Name", "RecipientEmail", "TransactionNumber", "UserId" },
                values: new object[,]
                {
                    { 1, -466.54000000000002, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 957, DateTimeKind.Unspecified).AddTicks(9630), new TimeSpan(0, 0, 0, 0, 0)), null, "Argent pour OnePlus 5T", "maman@gmail.com", "9ca1cfe8-d7ba-4815-b545-78a3938b132d", 1 },
                    { 23, -4.9900000000000002, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2687), new TimeSpan(0, 0, 0, 0, 0)), null, "Location de film", "rentdvd@gmail.com", "00e71c15-271c-4446-95b4-8fa65f29d42c", 1 },
                    { 24, -3.9900000000000002, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2691), new TimeSpan(0, 0, 0, 0, 0)), null, "Location de film", "rentdvd@gmail.com", "f51b6890-1adc-4fe9-917b-8e7e63f655f6", 1 },
                    { 25, -3.9900000000000002, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2694), new TimeSpan(0, 0, 0, 0, 0)), null, "Location de film", "rentdvd@gmail.com", "9caa93b0-71e6-4f50-a6f2-fe7d6a317aac", 1 },
                    { 26, -3.9900000000000002, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2698), new TimeSpan(0, 0, 0, 0, 0)), null, "Location de film", "rentdvd@gmail.com", "12d24383-7e48-4311-a345-f813426fe968", 1 },
                    { 27, -3.9900000000000002, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2701), new TimeSpan(0, 0, 0, 0, 0)), null, "Location de film", "rentdvd@gmail.com", "717a774b-3053-4ac8-b3c7-12334d1672ad", 1 },
                    { 28, -3.9900000000000002, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2704), new TimeSpan(0, 0, 0, 0, 0)), null, "Location de film", "rentdvd@gmail.com", "3dd634ed-45be-478c-b789-abcbb4c33404", 1 },
                    { 29, -4.9900000000000002, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2707), new TimeSpan(0, 0, 0, 0, 0)), null, "Location de film", "rentdvd@gmail.com", "de205ca0-cf8b-4f89-ab49-8ffa9ac48e0d", 1 },
                    { 22, -1.45, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2682), new TimeSpan(0, 0, 0, 0, 0)), null, "Tranche de pain le retour", "jaitresfaim@gmail.com", "f5fa8253-e8ba-4830-b3c0-cb00dd9799d5", 1 },
                    { 30, -7.9900000000000002, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2710), new TimeSpan(0, 0, 0, 0, 0)), null, "Location de film", "rentdvd@gmail.com", "9ec886e4-d400-4f69-ad56-c9c8680351c4", 1 },
                    { 32, 24.120000000000001, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2718), new TimeSpan(0, 0, 0, 0, 0)), null, "Remboursement resto soirée", "encouple@gmail.com", "317a1179-f367-4851-9a0e-b82f0cf23b04", 1 },
                    { 33, -7.2999999999999998, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2721), new TimeSpan(0, 0, 0, 0, 0)), null, "Verre en ville", "copain@gmail.com", "7d4cbb86-e9eb-4f45-a708-03df0f57a5ad", 1 },
                    { 34, -6.5, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 0, 0, 0, 0)), null, "Kebab", "copain@gmail.com", "50238ff9-0fe1-4aec-98f6-ac14c7204dcc", 1 },
                    { 35, 120.0, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2729), new TimeSpan(0, 0, 0, 0, 0)), null, "Cadeau Montre", "wow@gmail.com", "d51b3e4b-06e9-4797-9442-43620b8f69cf", 1 },
                    { 36, -28.0, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2732), new TimeSpan(0, 0, 0, 0, 0)), null, "Soirée Kebab", "copain@gmail.com", "127acefe-7c79-4fa7-9f7c-038c843e1671", 1 },
                    { 37, -16.0, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2735), new TimeSpan(0, 0, 0, 0, 0)), null, "Salle de sport", "workout@gmail.com", "8d970e27-e473-46c6-8c8a-f29e61d53b37", 1 },
                    { 38, -12.5, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2738), new TimeSpan(0, 0, 0, 0, 0)), null, "Soiré ciné", "copain@gmail.com", "e0715adb-f810-4a46-820d-c79d2b342cff", 1 },
                    { 31, 24.120000000000001, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2715), new TimeSpan(0, 0, 0, 0, 0)), null, "Courses Auchant", "encouple@gmail.com", "79e70456-56cd-4581-afaf-c4b5987f7dcf", 1 },
                    { 21, -1.6200000000000001, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2678), new TimeSpan(0, 0, 0, 0, 0)), null, "Tranche de pain", "jaifaim@gmail.com", "a042efbb-2379-49d7-bcaf-0bbedb3e3b56", 1 },
                    { 20, 500.0, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2675), new TimeSpan(0, 0, 0, 0, 0)), null, "Noel pour mon cherie !", "cedelaboite@gmail.com", "29c0dfbd-4d09-4dd2-ac64-43c5138a2165", 1 },
                    { 19, 50.0, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2672), new TimeSpan(0, 0, 0, 0, 0)), null, "Repas CE", "cedelaboite@gmail.com", "2af45dcc-1b0f-495a-9968-047ad7fb89ed", 1 },
                    { 2, -466.54000000000002, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2410), new TimeSpan(0, 0, 0, 0, 0)), null, "Remboursement des courses Auchant", "copine@gmail.com", "2d184aca-2e21-4a58-a9c0-a4b809e7510c", 1 },
                    { 3, -12.01, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2542), new TimeSpan(0, 0, 0, 0, 0)), null, "Tomate et citronade", "mamy@gmail.com", "9f11515b-3a83-40a5-ad05-821c3d2fb331", 1 },
                    { 4, -7.29, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2558), new TimeSpan(0, 0, 0, 0, 0)), null, "Bière entre poto", "benjamin@gmail.com", "d112014c-994b-4e8b-82ec-b3f46a5e6024", 1 },
                    { 5, -10.5, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2563), new TimeSpan(0, 0, 0, 0, 0)), null, "Bière entre poto", "timothee@gmail.com", "bff01f1c-0dda-4329-b27f-9ac2977eb93d", 1 },
                    { 6, -5.0, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2575), new TimeSpan(0, 0, 0, 0, 0)), null, "Bière entre poto", "jon@gmail.com", "1d1a89ef-113d-46d4-9a53-f52d40f48e92", 1 },
                    { 7, -594.0, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2584), new TimeSpan(0, 0, 0, 0, 0)), null, "Voyage Argentine", "manon@gmail.com", "5ff7f234-2267-4420-af74-1de76f93e0fe", 1 },
                    { 8, -84.0, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2587), new TimeSpan(0, 0, 0, 0, 0)), null, "Nourriture Lecler courses", "aurore@gmail.com", "00d6e0d2-0a79-4d71-8066-113b109d3d2d", 1 },
                    { 9, -2.0, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2632), new TimeSpan(0, 0, 0, 0, 0)), null, "Café pause boulot", "collegue@gmail.com", "2cb51d2c-4b14-4301-8ba5-77b938a5d0b7", 1 },
                    { 10, -2.0, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2639), new TimeSpan(0, 0, 0, 0, 0)), null, "Encore un autre café pause boulot", "collegue_sympa@gmail.com", "c36ebd5c-7fa7-421b-911d-b6de183f3399", 1 },
                    { 11, -2.0, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2642), new TimeSpan(0, 0, 0, 0, 0)), null, "Encore Encore un autre café pause boulot", "collegue_sympa_2@gmail.com", "28fd96ff-915a-4852-8f27-52355aab915c", 1 },
                    { 12, -8.0, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2645), new TimeSpan(0, 0, 0, 0, 0)), null, "En route vers la promotion en offrant une biere au patron", "patron@gmail.com", "4b834e30-515c-4537-a2e0-c63add568cbc", 1 },
                    { 13, 20.0, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2649), new TimeSpan(0, 0, 0, 0, 0)), null, "Pour le resto de lundi au boulot ! Merci !", "jepaiemesdettes@gmail.com", "dd962df0-027f-49e6-82a0-d2328ad014e3", 1 },
                    { 14, -2.0, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2652), new TimeSpan(0, 0, 0, 0, 0)), null, "Café du matin", "machineacafe@gmail.com", "e311fa1e-c746-4180-9b80-23b8c7c89550", 1 },
                    { 15, -2.0, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2658), new TimeSpan(0, 0, 0, 0, 0)), null, "Café de l'après midi", "machineacafe@gmail.com", "d51cff7f-20cb-435c-b065-24983866f392", 1 },
                    { 16, -2.0, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2662), new TimeSpan(0, 0, 0, 0, 0)), null, "Café du soir", "machineacafe@gmail.com", "c76a0bb2-0747-475f-9331-a60dc0b229be", 1 },
                    { 17, -2.0, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2665), new TimeSpan(0, 0, 0, 0, 0)), null, "Café de la nuit", "machineacafe@gmail.com", "5059d7c7-0fa1-4e15-a3bc-3a39857c1957", 1 },
                    { 18, 2.0, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2669), new TimeSpan(0, 0, 0, 0, 0)), null, "C'est pour le café de mardi", "collegueacafe@gmail.com", "e079b106-b15e-458a-b90e-904d7fec9666", 1 },
                    { 39, -6.5, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2743), new TimeSpan(0, 0, 0, 0, 0)), null, "Kebab", "copain@gmail.com", "f39097b0-41d5-442d-a642-fd3d019e59f5", 1 },
                    { 40, 50.5, new DateTimeOffset(new DateTime(2019, 11, 30, 14, 33, 45, 958, DateTimeKind.Unspecified).AddTicks(2746), new TimeSpan(0, 0, 0, 0, 0)), null, "Rembousement pro", "company@gmail.com", "2d5a5a45-6012-4605-a3e4-bb79a19bc6d0", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Operation_UserId",
                table: "Operation",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operation");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
