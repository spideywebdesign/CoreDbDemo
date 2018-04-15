using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoreDbDemo.Data.Migrations
{
    public partial class UpdateEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_StaffMembers_StaffMemberId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Systems_SystemId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Retailers");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "StaffMembers",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RetailerId",
                table: "StaffMembers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "StaffMembers",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "County",
                table: "Retailers",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address3",
                table: "Retailers",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address2",
                table: "Retailers",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address1",
                table: "Retailers",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Town",
                table: "Retailers",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "SystemId",
                table: "Requests",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StaffMemberId",
                table: "Requests",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_StaffMembers_StaffMemberId",
                table: "Requests",
                column: "StaffMemberId",
                principalTable: "StaffMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Systems_SystemId",
                table: "Requests",
                column: "SystemId",
                principalTable: "Systems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_StaffMembers_StaffMemberId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Systems_SystemId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Town",
                table: "Retailers");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "StaffMembers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "RetailerId",
                table: "StaffMembers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "StaffMembers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "County",
                table: "Retailers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address3",
                table: "Retailers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address2",
                table: "Retailers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address1",
                table: "Retailers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Retailers",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SystemId",
                table: "Requests",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "StaffMemberId",
                table: "Requests",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_StaffMembers_StaffMemberId",
                table: "Requests",
                column: "StaffMemberId",
                principalTable: "StaffMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
