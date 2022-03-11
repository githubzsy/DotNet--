using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ORM.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EQUIPMENT",
                columns: table => new
                {
                    ID = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    EQUIPMENT_GROUP_ID = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EQUIPMENT_NAME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EQUIPMENT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "POST",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TITLE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Content = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    BlogId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POST", x => x.PostId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EQUIPMENT");

            migrationBuilder.DropTable(
                name: "POST");
        }
    }
}
