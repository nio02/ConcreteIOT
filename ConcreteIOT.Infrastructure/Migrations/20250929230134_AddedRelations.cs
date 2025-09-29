using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConcreteIOT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "UserProject",
                type: "character varying(7)",
                maxLength: 7,
                nullable: false,
                defaultValue: "OWNER",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "UserProject",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserProject",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ConcreteMixId",
                table: "Elements",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "Elements",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DeviceId",
                table: "DataSets",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ElementId",
                table: "DataSets",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "ConcreteMixes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Serial = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProject_ProjectId",
                table: "UserProject",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProject_UserId_ProjectId",
                table: "UserProject",
                columns: new[] { "UserId", "ProjectId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Elements_ConcreteMixId",
                table: "Elements",
                column: "ConcreteMixId");

            migrationBuilder.CreateIndex(
                name: "IX_Elements_ProjectId",
                table: "Elements",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DataSets_DeviceId",
                table: "DataSets",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_DataSets_ElementId",
                table: "DataSets",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcreteMixes_ProjectId",
                table: "ConcreteMixes",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConcreteMixes_Projects_ProjectId",
                table: "ConcreteMixes",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DataSets_Devices_DeviceId",
                table: "DataSets",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DataSets_Elements_ElementId",
                table: "DataSets",
                column: "ElementId",
                principalTable: "Elements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Elements_ConcreteMixes_ConcreteMixId",
                table: "Elements",
                column: "ConcreteMixId",
                principalTable: "ConcreteMixes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Elements_Projects_ProjectId",
                table: "Elements",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProject_Projects_ProjectId",
                table: "UserProject",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProject_Users_UserId",
                table: "UserProject",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConcreteMixes_Projects_ProjectId",
                table: "ConcreteMixes");

            migrationBuilder.DropForeignKey(
                name: "FK_DataSets_Devices_DeviceId",
                table: "DataSets");

            migrationBuilder.DropForeignKey(
                name: "FK_DataSets_Elements_ElementId",
                table: "DataSets");

            migrationBuilder.DropForeignKey(
                name: "FK_Elements_ConcreteMixes_ConcreteMixId",
                table: "Elements");

            migrationBuilder.DropForeignKey(
                name: "FK_Elements_Projects_ProjectId",
                table: "Elements");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProject_Projects_ProjectId",
                table: "UserProject");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProject_Users_UserId",
                table: "UserProject");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_UserProject_ProjectId",
                table: "UserProject");

            migrationBuilder.DropIndex(
                name: "IX_UserProject_UserId_ProjectId",
                table: "UserProject");

            migrationBuilder.DropIndex(
                name: "IX_Elements_ConcreteMixId",
                table: "Elements");

            migrationBuilder.DropIndex(
                name: "IX_Elements_ProjectId",
                table: "Elements");

            migrationBuilder.DropIndex(
                name: "IX_DataSets_DeviceId",
                table: "DataSets");

            migrationBuilder.DropIndex(
                name: "IX_DataSets_ElementId",
                table: "DataSets");

            migrationBuilder.DropIndex(
                name: "IX_ConcreteMixes_ProjectId",
                table: "ConcreteMixes");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "UserProject");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserProject");

            migrationBuilder.DropColumn(
                name: "ConcreteMixId",
                table: "Elements");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Elements");

            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "DataSets");

            migrationBuilder.DropColumn(
                name: "ElementId",
                table: "DataSets");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "ConcreteMixes");

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "UserProject",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(7)",
                oldMaxLength: 7,
                oldDefaultValue: "OWNER");
        }
    }
}
