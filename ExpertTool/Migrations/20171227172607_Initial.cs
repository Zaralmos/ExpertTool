using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ExpertTool.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdminId = table.Column<int>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    ShortInfo = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    Socialbyteroversion = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Experts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdminId = table.Column<int>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    ShortInfo = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experts_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdminId = table.Column<int>(nullable: false),
                    Biography = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conclusions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(nullable: true),
                    ExpertId = table.Column<int>(nullable: false),
                    MarkIdId = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conclusions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conclusions_Experts_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Experts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Conclusions_Evaluations_MarkIdId",
                        column: x => x.MarkIdId,
                        principalTable: "Evaluations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conclusions_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_AdminId",
                table: "Admins",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Conclusions_ExpertId",
                table: "Conclusions",
                column: "ExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_Conclusions_MarkIdId",
                table: "Conclusions",
                column: "MarkIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Conclusions_PersonId",
                table: "Conclusions",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Experts_AdminId",
                table: "Experts",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_People_AdminId",
                table: "People",
                column: "AdminId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conclusions");

            migrationBuilder.DropTable(
                name: "Experts");

            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Admins");
        }
    }
}
