using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoreDbDemo.Data.Migrations
{
    public partial class Refactoringtablenamesagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Systems_ExternalSystemId",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Systems",
                table: "Systems");

            migrationBuilder.RenameTable(
                name: "Systems",
                newName: "ExternalSystems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExternalSystems",
                table: "ExternalSystems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_ExternalSystems_ExternalSystemId",
                table: "Requests",
                column: "ExternalSystemId",
                principalTable: "ExternalSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_ExternalSystems_ExternalSystemId",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExternalSystems",
                table: "ExternalSystems");

            migrationBuilder.RenameTable(
                name: "ExternalSystems",
                newName: "Systems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Systems",
                table: "Systems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Systems_ExternalSystemId",
                table: "Requests",
                column: "ExternalSystemId",
                principalTable: "Systems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
