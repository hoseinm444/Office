using Microsoft.EntityFrameworkCore.Migrations;

namespace Office.DataLayer.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organzations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ParrentOfficeId = table.Column<int>(type: "int", nullable: false),
                    PersonnelMainOfficeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organzations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personnels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Family = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NationalCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    PersonnelGender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Childern",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Family = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PersonnelId = table.Column<int>(type: "int", nullable: false),
                    NationalCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    ChildGender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Childern", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Childern_Personnels_PersonnelId",
                        column: x => x.PersonnelId,
                        principalTable: "Personnels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    PersonnelId = table.Column<int>(type: "int", nullable: false),
                    OrganzationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => new { x.OrganzationId, x.PersonnelId });
                    table.ForeignKey(
                        name: "FK_Permissions_Organzations_OrganzationId",
                        column: x => x.OrganzationId,
                        principalTable: "Organzations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Permissions_Personnels_PersonnelId",
                        column: x => x.PersonnelId,
                        principalTable: "Personnels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonnelMainOffices",
                columns: table => new
                {
                    PersonnelId = table.Column<int>(type: "int", nullable: false),
                    OrganzationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonnelMainOffices", x => new { x.PersonnelId, x.OrganzationId });
                    table.ForeignKey(
                        name: "FK_PersonnelMainOffices_Organzations_OrganzationId",
                        column: x => x.OrganzationId,
                        principalTable: "Organzations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonnelMainOffices_Personnels_PersonnelId",
                        column: x => x.PersonnelId,
                        principalTable: "Personnels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Childern_PersonnelId",
                table: "Childern",
                column: "PersonnelId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_PersonnelId",
                table: "Permissions",
                column: "PersonnelId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonnelMainOffices_OrganzationId",
                table: "PersonnelMainOffices",
                column: "OrganzationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonnelMainOffices_PersonnelId",
                table: "PersonnelMainOffices",
                column: "PersonnelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personnels_NationalCode",
                table: "Personnels",
                column: "NationalCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Childern");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "PersonnelMainOffices");

            migrationBuilder.DropTable(
                name: "Organzations");

            migrationBuilder.DropTable(
                name: "Personnels");
        }
    }
}
