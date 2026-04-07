using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business
{
    public record AimOfPlanDTO(int Id, string Description);
    public record ExerciseDTO(int Id, string Name, bool Complex, int IdMuscle);
    public record ExerciseInTrainingDTO(int Id, int Sets, int Reps, int Order, int IdExercise, int IdTraining);
    public record MuscleDTO(int Id, string Name, int IdMuscleGroup);
    public record MuscleGroupDTO(int Id, string Name);
    public record TrainingDTO(int Id, DateOnly Date, int IdTrainingPlan, int IdTrainingTypeSequence);
    public record TrainingPlanDTO(int Id, string PlanName, int TrainingFrequency, int IdUser, int IdTrainingType, int IdAimOfTraining);
    public record TrainingTypeDTO(int Id, string Name);
    public record UserDTO(int Id, string Username, double Weight);
}
