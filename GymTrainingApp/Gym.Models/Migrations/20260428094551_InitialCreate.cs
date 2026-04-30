using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gym.Models.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AimsOfPlan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AimsOfPlan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MuscleGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuscleGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Weight = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Muscles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    IdMuscleGroup = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muscles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Muscles_MuscleGroups_IdMuscleGroup",
                        column: x => x.IdMuscleGroup,
                        principalTable: "MuscleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingTypeSequences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderInCycle = table.Column<int>(type: "INTEGER", nullable: false),
                    IdTrainingType = table.Column<int>(type: "INTEGER", nullable: false),
                    IdMuscleGroup = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingTypeSequences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingTypeSequences_MuscleGroups_IdMuscleGroup",
                        column: x => x.IdMuscleGroup,
                        principalTable: "MuscleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingTypeSequences_TrainingTypes_IdTrainingType",
                        column: x => x.IdTrainingType,
                        principalTable: "TrainingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateOfCreation = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    PlanName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    TrainingFrequency = table.Column<int>(type: "INTEGER", nullable: false),
                    IdUser = table.Column<int>(type: "INTEGER", nullable: false),
                    IdTrainingType = table.Column<int>(type: "INTEGER", nullable: false),
                    IdAimOfTraining = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingPlans_AimsOfPlan_IdAimOfTraining",
                        column: x => x.IdAimOfTraining,
                        principalTable: "AimsOfPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingPlans_TrainingTypes_IdTrainingType",
                        column: x => x.IdTrainingType,
                        principalTable: "TrainingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingPlans_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Complex = table.Column<bool>(type: "INTEGER", nullable: false),
                    IdMuscle = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_Muscles_IdMuscle",
                        column: x => x.IdMuscle,
                        principalTable: "Muscles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    IdTrainingPlan = table.Column<int>(type: "INTEGER", nullable: false),
                    IdTrainingTypeSequence = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainings_TrainingPlans_IdTrainingPlan",
                        column: x => x.IdTrainingPlan,
                        principalTable: "TrainingPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trainings_TrainingTypeSequences_IdTrainingTypeSequence",
                        column: x => x.IdTrainingTypeSequence,
                        principalTable: "TrainingTypeSequences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExercisesInTraining",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Sets = table.Column<int>(type: "INTEGER", nullable: false),
                    Reps = table.Column<int>(type: "INTEGER", nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    IdExercise = table.Column<int>(type: "INTEGER", nullable: false),
                    IdTraining = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercisesInTraining", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExercisesInTraining_Exercises_IdExercise",
                        column: x => x.IdExercise,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExercisesInTraining_Trainings_IdTraining",
                        column: x => x.IdTraining,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_IdMuscle",
                table: "Exercises",
                column: "IdMuscle");

            migrationBuilder.CreateIndex(
                name: "IX_ExercisesInTraining_IdExercise",
                table: "ExercisesInTraining",
                column: "IdExercise");

            migrationBuilder.CreateIndex(
                name: "IX_ExercisesInTraining_IdTraining",
                table: "ExercisesInTraining",
                column: "IdTraining");

            migrationBuilder.CreateIndex(
                name: "IX_Muscles_IdMuscleGroup",
                table: "Muscles",
                column: "IdMuscleGroup");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlans_IdAimOfTraining",
                table: "TrainingPlans",
                column: "IdAimOfTraining");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlans_IdTrainingType",
                table: "TrainingPlans",
                column: "IdTrainingType");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlans_IdUser",
                table: "TrainingPlans",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_IdTrainingPlan",
                table: "Trainings",
                column: "IdTrainingPlan");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_IdTrainingTypeSequence",
                table: "Trainings",
                column: "IdTrainingTypeSequence");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingTypeSequences_IdMuscleGroup",
                table: "TrainingTypeSequences",
                column: "IdMuscleGroup");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingTypeSequences_IdTrainingType",
                table: "TrainingTypeSequences",
                column: "IdTrainingType");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExercisesInTraining");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "Muscles");

            migrationBuilder.DropTable(
                name: "TrainingPlans");

            migrationBuilder.DropTable(
                name: "TrainingTypeSequences");

            migrationBuilder.DropTable(
                name: "AimsOfPlan");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "MuscleGroups");

            migrationBuilder.DropTable(
                name: "TrainingTypes");
        }
    }
}
