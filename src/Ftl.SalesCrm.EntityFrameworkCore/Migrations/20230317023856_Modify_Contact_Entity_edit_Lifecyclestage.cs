using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ftl.SalesCrm.Migrations
{
    /// <inheritdoc />
    public partial class ModifyContactEntityeditLifecyclestage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lifecyclestage",
                table: "AppContacts");

            migrationBuilder.AddColumn<Guid>(
                name: "LifecyclestageId",
                table: "AppContacts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AppContacts_LifecyclestageId",
                table: "AppContacts",
                column: "LifecyclestageId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppContacts_AppLifecyclestages_LifecyclestageId",
                table: "AppContacts",
                column: "LifecyclestageId",
                principalTable: "AppLifecyclestages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppContacts_AppLifecyclestages_LifecyclestageId",
                table: "AppContacts");

            migrationBuilder.DropIndex(
                name: "IX_AppContacts_LifecyclestageId",
                table: "AppContacts");

            migrationBuilder.DropColumn(
                name: "LifecyclestageId",
                table: "AppContacts");

            migrationBuilder.AddColumn<string>(
                name: "Lifecyclestage",
                table: "AppContacts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
