using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gym.Models.Migrations
{
    /// <inheritdoc />
    public partial class MuscleGroupMuscleManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Muscles_MuscleGroups_IdMuscleGroup",
                table: "Muscles");

            migrationBuilder.DropIndex(
                name: "IX_Muscles_IdMuscleGroup",
                table: "Muscles");

            migrationBuilder.DropColumn(
                name: "IdMuscleGroup",
                table: "Muscles");

            migrationBuilder.CreateTable(
                name: "MuscleGroupMuscles",
                columns: table => new
                {
                    IdMuscleGroup = table.Column<int>(type: "INTEGER", nullable: false),
                    IdMuscle = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuscleGroupMuscles", x => new { x.IdMuscleGroup, x.IdMuscle });
                    table.ForeignKey(
                        name: "FK_MuscleGroupMuscles_MuscleGroups_IdMuscleGroup",
                        column: x => x.IdMuscleGroup,
                        principalTable: "MuscleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MuscleGroupMuscles_Muscles_IdMuscle",
                        column: x => x.IdMuscle,
                        principalTable: "Muscles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MuscleGroupMuscles_IdMuscle",
                table: "MuscleGroupMuscles",
                column: "IdMuscle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MuscleGroupMuscles");

            migrationBuilder.AddColumn<int>(
                name: "IdMuscleGroup",
                table: "Muscles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Muscles_IdMuscleGroup",
                table: "Muscles",
                column: "IdMuscleGroup");

            migrationBuilder.AddForeignKey(
                name: "FK_Muscles_MuscleGroups_IdMuscleGroup",
                table: "Muscles",
                column: "IdMuscleGroup",
                principalTable: "MuscleGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
