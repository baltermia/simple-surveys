using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleSurveys.Shared.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Open = table.Column<bool>(type: "bit", nullable: false),
                    ClosedSince = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Public = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Required = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Date_Placeholder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date_Default = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    DropDown_Default = table.Column<int>(type: "int", nullable: true),
                    DropDown_Placeholder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MultiSelect = table.Column<bool>(type: "bit", nullable: true),
                    Placeholder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Default = table.Column<int>(type: "int", nullable: true),
                    Min = table.Column<int>(type: "int", nullable: true),
                    Max = table.Column<int>(type: "int", nullable: true)
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
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyID = table.Column<int>(type: "int", nullable: false),
                    Submitted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Step_Values",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StepID = table.Column<int>(type: "int", nullable: false),
                    ValueID = table.Column<int>(type: "int", nullable: false),
                    CheckID = table.Column<int>(type: "int", nullable: true),
                    DropDownID = table.Column<int>(type: "int", nullable: true),
                    RadioID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Step_Values", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Step_Values_Steps_CheckID",
                        column: x => x.CheckID,
                        principalTable: "Steps",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Step_Values_Steps_DropDownID",
                        column: x => x.DropDownID,
                        principalTable: "Steps",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Step_Values_Steps_RadioID",
                        column: x => x.RadioID,
                        principalTable: "Steps",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Step_Values_Steps_StepID",
                        column: x => x.StepID,
                        principalTable: "Steps",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Step_Values_Values_ValueID",
                        column: x => x.ValueID,
                        principalTable: "Values",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StepResults",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StepID = table.Column<int>(type: "int", nullable: false),
                    SurveyResultID = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumberResult_Value = table.Column<int>(type: "int", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<int>(type: "int", nullable: true),
                    TextResult_Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Result = table.Column<bool>(type: "bit", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "StepResult_Values",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StepResultID = table.Column<int>(type: "int", nullable: false),
                    ValueID = table.Column<int>(type: "int", nullable: false),
                    CheckResultID = table.Column<int>(type: "int", nullable: true),
                    DropDownResultID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StepResult_Values", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StepResult_Values_StepResults_CheckResultID",
                        column: x => x.CheckResultID,
                        principalTable: "StepResults",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StepResult_Values_StepResults_DropDownResultID",
                        column: x => x.DropDownResultID,
                        principalTable: "StepResults",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StepResult_Values_StepResults_StepResultID",
                        column: x => x.StepResultID,
                        principalTable: "StepResults",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StepResult_Values_Values_ValueID",
                        column: x => x.ValueID,
                        principalTable: "Values",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Step_Values_CheckID",
                table: "Step_Values",
                column: "CheckID");

            migrationBuilder.CreateIndex(
                name: "IX_Step_Values_DropDownID",
                table: "Step_Values",
                column: "DropDownID");

            migrationBuilder.CreateIndex(
                name: "IX_Step_Values_RadioID",
                table: "Step_Values",
                column: "RadioID");

            migrationBuilder.CreateIndex(
                name: "IX_Step_Values_StepID",
                table: "Step_Values",
                column: "StepID");

            migrationBuilder.CreateIndex(
                name: "IX_Step_Values_ValueID",
                table: "Step_Values",
                column: "ValueID");

            migrationBuilder.CreateIndex(
                name: "IX_StepResult_Values_CheckResultID",
                table: "StepResult_Values",
                column: "CheckResultID");

            migrationBuilder.CreateIndex(
                name: "IX_StepResult_Values_DropDownResultID",
                table: "StepResult_Values",
                column: "DropDownResultID");

            migrationBuilder.CreateIndex(
                name: "IX_StepResult_Values_StepResultID",
                table: "StepResult_Values",
                column: "StepResultID");

            migrationBuilder.CreateIndex(
                name: "IX_StepResult_Values_ValueID",
                table: "StepResult_Values",
                column: "ValueID");

            migrationBuilder.CreateIndex(
                name: "IX_StepResults_StepID",
                table: "StepResults",
                column: "StepID");

            migrationBuilder.CreateIndex(
                name: "IX_StepResults_SurveyResultID",
                table: "StepResults",
                column: "SurveyResultID");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_SurveyID",
                table: "Steps",
                column: "SurveyID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResults_SurveyID",
                table: "SurveyResults",
                column: "SurveyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Step_Values");

            migrationBuilder.DropTable(
                name: "StepResult_Values");

            migrationBuilder.DropTable(
                name: "StepResults");

            migrationBuilder.DropTable(
                name: "Values");

            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropTable(
                name: "SurveyResults");

            migrationBuilder.DropTable(
                name: "Surveys");
        }
    }
}
