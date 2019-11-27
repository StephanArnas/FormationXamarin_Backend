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
                values: new object[] { 1, new DateTimeOffset(new DateTime(2019, 11, 27, 23, 47, 23, 261, DateTimeKind.Unspecified).AddTicks(4590), new TimeSpan(0, 0, 0, 0, 0)), 2265.0, "stephan.arnas@gmail.com", "Stephan", "Arnas", null, "Aze123" });

            migrationBuilder.InsertData(
                table: "Operation",
                columns: new[] { "Id", "Amount", "CreatedDate", "ModifiedDate", "Name", "RecipientEmail", "TransactionNumber", "UserId" },
                values: new object[,]
                {
                    { 1, -466.54000000000002, new DateTimeOffset(new DateTime(2019, 11, 27, 23, 47, 23, 263, DateTimeKind.Unspecified).AddTicks(3162), new TimeSpan(0, 0, 0, 0, 0)), null, "Argent pour OnePlus 5T", "maman@gmail.com", "013f5f8a-ac32-40c9-add2-cf072a860daf", 1 },
                    { 2, -466.54000000000002, new DateTimeOffset(new DateTime(2019, 11, 27, 23, 47, 23, 263, DateTimeKind.Unspecified).AddTicks(5478), new TimeSpan(0, 0, 0, 0, 0)), null, "Remboursement des courses Auchant", "copine@gmail.com", "de8c8198-4163-45f3-8f2c-bcbc78cb75e7", 1 },
                    { 3, -12.01, new DateTimeOffset(new DateTime(2019, 11, 27, 23, 47, 23, 263, DateTimeKind.Unspecified).AddTicks(5532), new TimeSpan(0, 0, 0, 0, 0)), null, "Tomate et citronade", "mamy@gmail.com", "d9da389c-7fbd-4a13-aaab-fe703915f39d", 1 },
                    { 4, -7.29, new DateTimeOffset(new DateTime(2019, 11, 27, 23, 47, 23, 263, DateTimeKind.Unspecified).AddTicks(5536), new TimeSpan(0, 0, 0, 0, 0)), null, "Bière entre poto", "benjamin@gmail.com", "033d925c-0772-492c-a4c3-202624e00ee1", 1 },
                    { 5, -10.5, new DateTimeOffset(new DateTime(2019, 11, 27, 23, 47, 23, 263, DateTimeKind.Unspecified).AddTicks(5540), new TimeSpan(0, 0, 0, 0, 0)), null, "Bière entre poto", "timothee@gmail.com", "f45d8db4-a9a0-4693-996e-094d25526182", 1 },
                    { 6, -5.0, new DateTimeOffset(new DateTime(2019, 11, 27, 23, 47, 23, 263, DateTimeKind.Unspecified).AddTicks(5546), new TimeSpan(0, 0, 0, 0, 0)), null, "Bière entre poto", "jon@gmail.com", "d8510f66-3253-40d3-b665-fe317cb84771", 1 },
                    { 7, -594.0, new DateTimeOffset(new DateTime(2019, 11, 27, 23, 47, 23, 263, DateTimeKind.Unspecified).AddTicks(5558), new TimeSpan(0, 0, 0, 0, 0)), null, "Voyage Argentine", "manon@gmail.com", "c325c285-24ee-4a6b-9bf5-8a2a554ef7bd", 1 },
                    { 8, -84.0, new DateTimeOffset(new DateTime(2019, 11, 27, 23, 47, 23, 263, DateTimeKind.Unspecified).AddTicks(5562), new TimeSpan(0, 0, 0, 0, 0)), null, "Nourriture Lecler courses", "aurore@gmail.com", "94b66912-df42-4f7e-8ccc-8ceb59ab7158", 1 },
                    { 9, -2.0, new DateTimeOffset(new DateTime(2019, 11, 27, 23, 47, 23, 263, DateTimeKind.Unspecified).AddTicks(5565), new TimeSpan(0, 0, 0, 0, 0)), null, "Café pause boulot", "collegue@gmail.com", "017206d6-41ed-42fd-8d8d-911036b357a7", 1 },
                    { 10, -2.0, new DateTimeOffset(new DateTime(2019, 11, 27, 23, 47, 23, 263, DateTimeKind.Unspecified).AddTicks(5570), new TimeSpan(0, 0, 0, 0, 0)), null, "Encore un autre café pause boulot", "collegue_sympa@gmail.com", "ad2f9a30-a9a4-46ca-9002-c900fa9b1969", 1 },
                    { 11, -2.0, new DateTimeOffset(new DateTime(2019, 11, 27, 23, 47, 23, 263, DateTimeKind.Unspecified).AddTicks(5573), new TimeSpan(0, 0, 0, 0, 0)), null, "Encore Encore un autre café pause boulot", "collegue_sympa_2@gmail.com", "2d7c1866-bd26-4063-aa80-28e95a6cdc11", 1 },
                    { 12, -8.0, new DateTimeOffset(new DateTime(2019, 11, 27, 23, 47, 23, 263, DateTimeKind.Unspecified).AddTicks(5577), new TimeSpan(0, 0, 0, 0, 0)), null, "En route vers la promotion en offrant une biere au patron", "patron@gmail.com", "af063b8f-f721-48e5-b3b4-c72bf70a19c1", 1 }
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
