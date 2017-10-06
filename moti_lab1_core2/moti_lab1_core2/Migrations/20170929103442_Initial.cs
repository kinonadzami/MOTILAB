using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace moti_lab1_core2.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alternatives",
                columns: table => new
                {
                    ANum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alternatives", x => x.ANum);
                });

            migrationBuilder.CreateTable(
                name: "Criterions",
                columns: table => new
                {
                    CNum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CRange = table.Column<int>(type: "int", nullable: false),
                    CType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CWeight = table.Column<int>(type: "int", nullable: false),
                    Edizmer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScaleType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criterions", x => x.CNum);
                });

            migrationBuilder.CreateTable(
                name: "LPRs",
                columns: table => new
                {
                    LNum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LRange = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LPRs", x => x.LNum);
                });

            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table => new
                {
                    MNum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CNum = table.Column<int>(type: "int", nullable: false),
                    MNAme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MRange = table.Column<int>(type: "int", nullable: false),
                    NormMark = table.Column<int>(type: "int", nullable: false),
                    NumMark = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marks", x => x.MNum);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    RNum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ANum = table.Column<int>(type: "int", nullable: false),
                    AWeight = table.Column<int>(type: "int", nullable: false),
                    LNum = table.Column<int>(type: "int", nullable: false),
                    Range = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.RNum);
                });

            migrationBuilder.CreateTable(
                name: "Vectors",
                columns: table => new
                {
                    VNum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Anum = table.Column<int>(type: "int", nullable: false),
                    MNum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vectors", x => x.VNum);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alternatives");

            migrationBuilder.DropTable(
                name: "Criterions");

            migrationBuilder.DropTable(
                name: "LPRs");

            migrationBuilder.DropTable(
                name: "Marks");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Vectors");
        }
    }
}
