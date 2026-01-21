using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SimpleSurveys.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Open = table.Column<bool>(type: "boolean", nullable: false),
                    ClosedSince = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    MaxSubmissions = table.Column<int>(type: "integer", nullable: true),
                    Public = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SurveyID = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Required = table.Column<bool>(type: "boolean", nullable: false),
                    Position = table.Column<int>(type: "integer", nullable: false),
                    Discriminator = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Placeholder = table.Column<string>(type: "text", nullable: true),
                    Date_Default = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateType = table.Column<int>(type: "integer", nullable: true),
                    Default = table.Column<int>(type: "integer", nullable: true),
                    MultiSelect = table.Column<bool>(type: "boolean", nullable: true),
                    Min = table.Column<int>(type: "integer", nullable: true),
                    Max = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Steps_Surveys_SurveyID",
                        column: x => x.SurveyID,
                        principalTable: "Surveys",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SurveyResults",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SurveyID = table.Column<int>(type: "integer", nullable: false),
                    Submitted = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyResults", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SurveyResults_Surveys_SurveyID",
                        column: x => x.SurveyID,
                        principalTable: "Surveys",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CheckValue",
                columns: table => new
                {
                    ChecksID = table.Column<int>(type: "integer", nullable: false),
                    ValuesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckValue", x => new { x.ChecksID, x.ValuesID });
                    table.ForeignKey(
                        name: "FK_CheckValue_Steps_ChecksID",
                        column: x => x.ChecksID,
                        principalTable: "Steps",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheckValue_Values_ValuesID",
                        column: x => x.ValuesID,
                        principalTable: "Values",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DropDownValue",
                columns: table => new
                {
                    DropDownsID = table.Column<int>(type: "integer", nullable: false),
                    ValuesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DropDownValue", x => new { x.DropDownsID, x.ValuesID });
                    table.ForeignKey(
                        name: "FK_DropDownValue_Steps_DropDownsID",
                        column: x => x.DropDownsID,
                        principalTable: "Steps",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DropDownValue_Values_ValuesID",
                        column: x => x.ValuesID,
                        principalTable: "Values",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RadioValue",
                columns: table => new
                {
                    RadiosID = table.Column<int>(type: "integer", nullable: false),
                    ValuesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadioValue", x => new { x.RadiosID, x.ValuesID });
                    table.ForeignKey(
                        name: "FK_RadioValue_Steps_RadiosID",
                        column: x => x.RadiosID,
                        principalTable: "Steps",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RadioValue_Values_ValuesID",
                        column: x => x.ValuesID,
                        principalTable: "Values",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StepResults",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StepID = table.Column<int>(type: "integer", nullable: false),
                    SurveyResultID = table.Column<int>(type: "integer", nullable: false),
                    Discriminator = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DateTime_Value = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Int_Value = table.Column<int>(type: "integer", nullable: true),
                    ValueID = table.Column<int>(type: "integer", nullable: true),
                    String_Value = table.Column<string>(type: "text", nullable: true),
                    Bool_Value = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StepResults", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StepResults_Steps_StepID",
                        column: x => x.StepID,
                        principalTable: "Steps",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StepResults_SurveyResults_SurveyResultID",
                        column: x => x.SurveyResultID,
                        principalTable: "SurveyResults",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StepResults_Values_ValueID",
                        column: x => x.ValueID,
                        principalTable: "Values",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CheckResultValue",
                columns: table => new
                {
                    CheckResultsID = table.Column<int>(type: "integer", nullable: false),
                    ValuesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckResultValue", x => new { x.CheckResultsID, x.ValuesID });
                    table.ForeignKey(
                        name: "FK_CheckResultValue_StepResults_CheckResultsID",
                        column: x => x.CheckResultsID,
                        principalTable: "StepResults",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheckResultValue_Values_ValuesID",
                        column: x => x.ValuesID,
                        principalTable: "Values",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DropDownResultValue",
                columns: table => new
                {
                    DropDownResultsID = table.Column<int>(type: "integer", nullable: false),
                    ValuesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DropDownResultValue", x => new { x.DropDownResultsID, x.ValuesID });
                    table.ForeignKey(
                        name: "FK_DropDownResultValue_StepResults_DropDownResultsID",
                        column: x => x.DropDownResultsID,
                        principalTable: "StepResults",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DropDownResultValue_Values_ValuesID",
                        column: x => x.ValuesID,
                        principalTable: "Values",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckResultValue_ValuesID",
                table: "CheckResultValue",
                column: "ValuesID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckValue_ValuesID",
                table: "CheckValue",
                column: "ValuesID");

            migrationBuilder.CreateIndex(
                name: "IX_DropDownResultValue_ValuesID",
                table: "DropDownResultValue",
                column: "ValuesID");

            migrationBuilder.CreateIndex(
                name: "IX_DropDownValue_ValuesID",
                table: "DropDownValue",
                column: "ValuesID");

            migrationBuilder.CreateIndex(
                name: "IX_RadioValue_ValuesID",
                table: "RadioValue",
                column: "ValuesID");

            migrationBuilder.CreateIndex(
                name: "IX_StepResults_StepID",
                table: "StepResults",
                column: "StepID");

            migrationBuilder.CreateIndex(
                name: "IX_StepResults_SurveyResultID",
                table: "StepResults",
                column: "SurveyResultID");

            migrationBuilder.CreateIndex(
                name: "IX_StepResults_ValueID",
                table: "StepResults",
                column: "ValueID");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_SurveyID",
                table: "Steps",
                column: "SurveyID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResults_SurveyID",
                table: "SurveyResults",
                column: "SurveyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckResultValue");

            migrationBuilder.DropTable(
                name: "CheckValue");

            migrationBuilder.DropTable(
                name: "DropDownResultValue");

            migrationBuilder.DropTable(
                name: "DropDownValue");

            migrationBuilder.DropTable(
                name: "RadioValue");

            migrationBuilder.DropTable(
                name: "StepResults");

            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropTable(
                name: "SurveyResults");

            migrationBuilder.DropTable(
                name: "Values");

            migrationBuilder.DropTable(
                name: "Surveys");
        }
    }
}
