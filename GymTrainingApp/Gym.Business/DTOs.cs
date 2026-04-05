using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business
{
    public record AimOfPlanDTO(int Id, string Description);
    public record ExerciseDTO(int Id, string Name, bool Complex, MuscleDTO Muscle);
    public record ExerciseInTrainingDTO(int Sets, int Reps, int Order, ExerciseDTO Exercise);
    public record MuscleDTO(int Id, string Name, MuscleGroupDTO MuscleGroup);
    public record MuscleGroupDTO(int Id, string Name);
    public record TrainingDTO(int Id, DateOnly Date, TrainingPlanDTO TrainingPlan);
    public record TrainingPlanDTO(int Id, string Name, AimOfPlanDTO AimOfTraining);
    public record TrainingTypeDTO(int Id, string Name);
    public record UserDTO(int Id, string Username, double Weight);
    public record UserWithPasswordDTO(int Id, string Username, double Weight, string Password);
}
