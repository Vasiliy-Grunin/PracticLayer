using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Expansion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeAdd",
                table: "Peoples",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeChange",
                table: "Peoples",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Peoples",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Peoples",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeAdd",
                table: "Genries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeChange",
                table: "Genries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Genries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Genries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeAdd",
                table: "Books",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeChange",
                table: "Books",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeAdd",
                table: "Authors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeChange",
                table: "Authors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Authors",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTimeAdd",
                table: "Peoples");

            migrationBuilder.DropColumn(
                name: "DateTimeChange",
                table: "Peoples");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Peoples");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Peoples");

            migrationBuilder.DropColumn(
                name: "DateTimeAdd",
                table: "Genries");

            migrationBuilder.DropColumn(
                name: "DateTimeChange",
                table: "Genries");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Genries");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Genries");

            migrationBuilder.DropColumn(
                name: "DateTimeAdd",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "DateTimeChange",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "DateTimeAdd",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "DateTimeChange",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Authors");
        }
    }
}
