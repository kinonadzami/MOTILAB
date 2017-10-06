using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace moti_lab1_core2.Migrations
{
    public partial class DBFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Vectors_Anum",
                table: "Vectors",
                column: "Anum");

            migrationBuilder.CreateIndex(
                name: "IX_Vectors_MNum",
                table: "Vectors",
                column: "MNum");

            migrationBuilder.CreateIndex(
                name: "IX_Results_ANum",
                table: "Results",
                column: "ANum");

            migrationBuilder.CreateIndex(
                name: "IX_Results_LNum",
                table: "Results",
                column: "LNum");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_CNum",
                table: "Marks",
                column: "CNum");

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Criterions_CNum",
                table: "Marks",
                column: "CNum",
                principalTable: "Criterions",
                principalColumn: "CNum",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Alternatives_ANum",
                table: "Results",
                column: "ANum",
                principalTable: "Alternatives",
                principalColumn: "ANum",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_LPRs_LNum",
                table: "Results",
                column: "LNum",
                principalTable: "LPRs",
                principalColumn: "LNum",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vectors_Alternatives_Anum",
                table: "Vectors",
                column: "Anum",
                principalTable: "Alternatives",
                principalColumn: "ANum",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vectors_Marks_MNum",
                table: "Vectors",
                column: "MNum",
                principalTable: "Marks",
                principalColumn: "MNum",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Criterions_CNum",
                table: "Marks");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Alternatives_ANum",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_LPRs_LNum",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Vectors_Alternatives_Anum",
                table: "Vectors");

            migrationBuilder.DropForeignKey(
                name: "FK_Vectors_Marks_MNum",
                table: "Vectors");

            migrationBuilder.DropIndex(
                name: "IX_Vectors_Anum",
                table: "Vectors");

            migrationBuilder.DropIndex(
                name: "IX_Vectors_MNum",
                table: "Vectors");

            migrationBuilder.DropIndex(
                name: "IX_Results_ANum",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Results_LNum",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Marks_CNum",
                table: "Marks");
        }
    }
}
