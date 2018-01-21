using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ExpertTool.Migrations
{
    public partial class Six_Change_Bio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Career",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Publish",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Quotations",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReligiousViews",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SocialActivity",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Video",
                table: "People",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Career",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Publish",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Quotations",
                table: "People");

            migrationBuilder.DropColumn(
                name: "ReligiousViews",
                table: "People");

            migrationBuilder.DropColumn(
                name: "SocialActivity",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Video",
                table: "People");
        }
    }
}
