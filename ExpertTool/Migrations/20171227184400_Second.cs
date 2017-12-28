using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ExpertTool.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortInfo",
                table: "Experts");

            migrationBuilder.DropColumn(
                name: "ShortInfo",
                table: "Admins");

            migrationBuilder.AddColumn<string>(
                name: "ShortInfo",
                table: "People",
                maxLength: 1000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortInfo",
                table: "People");

            migrationBuilder.AddColumn<string>(
                name: "ShortInfo",
                table: "Experts",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortInfo",
                table: "Admins",
                maxLength: 1000,
                nullable: true);
        }
    }
}
