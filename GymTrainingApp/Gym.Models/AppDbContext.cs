using Gym.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TrainingPlan> TrainingPlans { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseInTraining> ExercisesInTraining { get; set; }
        public DbSet<MuscleGroup> MuscleGroups { get; set; }
        public DbSet<Muscle> Muscles { get; set; }
        public DbSet<TrainingType> TrainingTypes { get; set; }
        public DbSet<TrainingTypeSequence> TrainingTypeSequences { get; set; }
        public DbSet<AimOfPlan> AimsOfTraining { get; set; }

        
    }
}
