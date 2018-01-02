using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ExpertTool.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conclusions_Evaluations_MarkIdId",
                table: "Conclusions");

            migrationBuilder.RenameColumn(
                name: "Socialbyteroversion",
                table: "Evaluations",
                newName: "SocialInteroversion");

            migrationBuilder.RenameColumn(
                name: "MarkIdId",
                table: "Conclusions",
                newName: "EvaluationId");

            migrationBuilder.RenameIndex(
                name: "IX_Conclusions_MarkIdId",
                table: "Conclusions",
                newName: "IX_Conclusions_EvaluationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conclusions_Evaluations_EvaluationId",
                table: "Conclusions",
                column: "EvaluationId",
                principalTable: "Evaluations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conclusions_Evaluations_EvaluationId",
                table: "Conclusions");

            migrationBuilder.RenameColumn(
                name: "SocialInteroversion",
                table: "Evaluations",
                newName: "Socialbyteroversion");

            migrationBuilder.RenameColumn(
                name: "EvaluationId",
                table: "Conclusions",
                newName: "MarkIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Conclusions_EvaluationId",
                table: "Conclusions",
                newName: "IX_Conclusions_MarkIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conclusions_Evaluations_MarkIdId",
                table: "Conclusions",
                column: "MarkIdId",
                principalTable: "Evaluations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
