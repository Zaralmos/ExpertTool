using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ExpertTool.Migrations
{
    public partial class Fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conclusions_Evaluations_EvaluationId",
                table: "Conclusions");

            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropIndex(
                name: "IX_Conclusions_EvaluationId",
                table: "Conclusions");

            migrationBuilder.DropColumn(
                name: "EvaluationId",
                table: "Conclusions");

            migrationBuilder.AddColumn<byte>(
                name: "Depression",
                table: "Conclusions",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Hypochondriasis",
                table: "Conclusions",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Hypomania",
                table: "Conclusions",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Hysteria",
                table: "Conclusions",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "MaculinityFeminity",
                table: "Conclusions",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Paranoia",
                table: "Conclusions",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Psychasthenia",
                table: "Conclusions",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "PsychopathicDeviate",
                table: "Conclusions",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Schizophrenia",
                table: "Conclusions",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "SocialInteroversion",
                table: "Conclusions",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Depression",
                table: "Conclusions");

            migrationBuilder.DropColumn(
                name: "Hypochondriasis",
                table: "Conclusions");

            migrationBuilder.DropColumn(
                name: "Hypomania",
                table: "Conclusions");

            migrationBuilder.DropColumn(
                name: "Hysteria",
                table: "Conclusions");

            migrationBuilder.DropColumn(
                name: "MaculinityFeminity",
                table: "Conclusions");

            migrationBuilder.DropColumn(
                name: "Paranoia",
                table: "Conclusions");

            migrationBuilder.DropColumn(
                name: "Psychasthenia",
                table: "Conclusions");

            migrationBuilder.DropColumn(
                name: "PsychopathicDeviate",
                table: "Conclusions");

            migrationBuilder.DropColumn(
                name: "Schizophrenia",
                table: "Conclusions");

            migrationBuilder.DropColumn(
                name: "SocialInteroversion",
                table: "Conclusions");

            migrationBuilder.AddColumn<int>(
                name: "EvaluationId",
                table: "Conclusions",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Depression = table.Column<byte>(nullable: false),
                    Hypochondriasis = table.Column<byte>(nullable: false),
                    Hypomania = table.Column<byte>(nullable: false),
                    Hysteria = table.Column<byte>(nullable: false),
                    MaculinityFeminity = table.Column<byte>(nullable: false),
                    Paranoia = table.Column<byte>(nullable: false),
                    Psychasthenia = table.Column<byte>(nullable: false),
                    PsychopathicDeviate = table.Column<byte>(nullable: false),
                    Schizophrenia = table.Column<byte>(nullable: false),
                    SocialInteroversion = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conclusions_EvaluationId",
                table: "Conclusions",
                column: "EvaluationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conclusions_Evaluations_EvaluationId",
                table: "Conclusions",
                column: "EvaluationId",
                principalTable: "Evaluations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
