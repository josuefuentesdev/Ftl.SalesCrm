using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ftl.SalesCrm.Migrations
{
    /// <inheritdoc />
    public partial class EditedContactEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Leadstatus",
                table: "AppContacts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OwnerAssigneddate",
                table: "AppContacts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerUserId",
                table: "AppContacts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "AppContacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AppContacts_OwnerUserId",
                table: "AppContacts",
                column: "OwnerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppContacts_AbpUsers_OwnerUserId",
                table: "AppContacts",
                column: "OwnerUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppContacts_AbpUsers_OwnerUserId",
                table: "AppContacts");

            migrationBuilder.DropIndex(
                name: "IX_AppContacts_OwnerUserId",
                table: "AppContacts");

            migrationBuilder.DropColumn(
                name: "Leadstatus",
                table: "AppContacts");

            migrationBuilder.DropColumn(
                name: "OwnerAssigneddate",
                table: "AppContacts");

            migrationBuilder.DropColumn(
                name: "OwnerUserId",
                table: "AppContacts");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "AppContacts");
        }
    }
}
