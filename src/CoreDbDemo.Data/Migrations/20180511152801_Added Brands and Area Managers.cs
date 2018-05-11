using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoreDbDemo.Data.Migrations
{
    public partial class AddedBrandsandAreaManagers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AreaManagerId",
                table: "Retailers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Retailers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AreaManagers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaManagers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Retailers_AreaManagerId",
                table: "Retailers",
                column: "AreaManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Retailers_BrandId",
                table: "Retailers",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Retailers_AreaManagers_AreaManagerId",
                table: "Retailers",
                column: "AreaManagerId",
                principalTable: "AreaManagers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Retailers_Brands_BrandId",
                table: "Retailers",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Retailers_AreaManagers_AreaManagerId",
                table: "Retailers");

            migrationBuilder.DropForeignKey(
                name: "FK_Retailers_Brands_BrandId",
                table: "Retailers");

            migrationBuilder.DropTable(
                name: "AreaManagers");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Retailers_AreaManagerId",
                table: "Retailers");

            migrationBuilder.DropIndex(
                name: "IX_Retailers_BrandId",
                table: "Retailers");

            migrationBuilder.DropColumn(
                name: "AreaManagerId",
                table: "Retailers");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Retailers");
        }
    }
}
