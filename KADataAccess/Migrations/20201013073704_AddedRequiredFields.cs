using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace KADataAccess.Migrations
{
    public partial class AddedRequiredFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AreaCode",
                table: "Contact",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Contact",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Contact",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FlatNumber",
                table: "Contact",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HouseNumber",
                table: "Contact",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sex",
                table: "Contact",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Contact",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreaCode",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "FlatNumber",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "HouseNumber",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Contact");
        }
    }
}
