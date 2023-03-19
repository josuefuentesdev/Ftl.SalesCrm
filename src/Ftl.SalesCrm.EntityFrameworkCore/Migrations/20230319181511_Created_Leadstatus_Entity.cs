using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ftl.SalesCrm.Migrations
{
    /// <inheritdoc />
    public partial class CreatedLeadstatusEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Leadstatus",
                table: "AppContacts");

            migrationBuilder.AddColumn<Guid>(
                name: "LeadstatusId",
                table: "AppContacts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "AppLeadStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InternalValue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppLeadStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppContacts_LeadstatusId",
                table: "AppContacts",
                column: "LeadstatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppContacts_AppLeadStatuses_LeadstatusId",
                table: "AppContacts",
                column: "LeadstatusId",
                principalTable: "AppLeadStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppContacts_AppLeadStatuses_LeadstatusId",
                table: "AppContacts");

            migrationBuilder.DropTable(
                name: "AppLeadStatuses");

            migrationBuilder.DropIndex(
                name: "IX_AppContacts_LeadstatusId",
                table: "AppContacts");

            migrationBuilder.DropColumn(
                name: "LeadstatusId",
                table: "AppContacts");

            migrationBuilder.AddColumn<string>(
                name: "Leadstatus",
                table: "AppContacts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
