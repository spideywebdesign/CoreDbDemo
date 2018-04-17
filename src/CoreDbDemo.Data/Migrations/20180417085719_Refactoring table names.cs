using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoreDbDemo.Data.Migrations
{
    public partial class Refactoringtablenames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Systems_SystemId",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "SystemId",
                table: "Requests",
                newName: "ExternalSystemId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_SystemId",
                table: "Requests",
                newName: "IX_Requests_ExternalSystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Systems_ExternalSystemId",
                table: "Requests",
                column: "ExternalSystemId",
                principalTable: "Systems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Systems_ExternalSystemId",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "ExternalSystemId",
                table: "Requests",
                newName: "SystemId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_ExternalSystemId",
                table: "Requests",
                newName: "IX_Requests_SystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Systems_SystemId",
                table: "Requests",
                column: "SystemId",
                principalTable: "Systems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
