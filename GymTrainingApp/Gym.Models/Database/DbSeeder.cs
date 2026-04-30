using Gym.Models.Entities;

namespace Gym.Models.Data
{
    public static class DbSeeder
    {
        public static void Seed(GymDbContext context)
        {
            context.Database.EnsureCreated();

            // Seed only once (master data for generator + relational model)
            if (context.AimsOfPlan.Any()
                || context.TrainingTypes.Any()
                || context.TrainingTypeSequences.Any()
                || context.MuscleGroups.Any()
                || context.Muscles.Any()
                || context.MuscleGroupMuscles.Any()
                || context.Exercises.Any())
            {
                return;
            }

            SeedAimsOfPlan(context);
            SeedTrainingTypes(context);
            SeedMuscleGroups(context);
            SeedMuscles(context);
            SeedMuscleGroupMuscles(context);
            SeedTrainingTypeSequences(context);
            SeedExercises(context);

            context.SaveChanges();
        }

        private static void SeedAimsOfPlan(GymDbContext context)
        {
            // Keep IDs with AimOfPlanFactory (1,2,3)
            context.AimsOfPlan.AddRange(
                new AimOfPlan { Id = 1, Description = "Build Muscle" },
                new AimOfPlan { Id = 2, Description = "Build Strength" },
                new AimOfPlan { Id = 3, Description = "Lose Weight" }
            );
        }

        private static void SeedTrainingTypes(GymDbContext context)
        {
            context.TrainingTypes.AddRange(
                new TrainingType { Id = 1, Name = "Full Body" },
                new TrainingType { Id = 2, Name = "Upper Lower" },
                new TrainingType { Id = 3, Name = "Push Pull Legs" }
            );
        }

        private static void SeedMuscleGroups(GymDbContext context)
        {
            context.MuscleGroups.AddRange(
                new MuscleGroup { Id = 1, Name = "Full Body" },
                new MuscleGroup { Id = 2, Name = "Upper" },
                new MuscleGroup { Id = 3, Name = "Lower" },
                new MuscleGroup { Id = 4, Name = "Push" },
                new MuscleGroup { Id = 5, Name = "Pull" },
                new MuscleGroup { Id = 6, Name = "Legs" }
            );
        }

        private static void SeedMuscles(GymDbContext context)
        {
            context.Muscles.AddRange(
                new Muscle { Id = 1, Name = "Chest" },
                new Muscle { Id = 2, Name = "Upper Back" },
                new Muscle { Id = 3, Name = "Lats" },
                new Muscle { Id = 4, Name = "Shoulders" },
                new Muscle { Id = 5, Name = "Biceps" },
                new Muscle { Id = 6, Name = "Triceps" },
                new Muscle { Id = 7, Name = "Quads" },
                new Muscle { Id = 8, Name = "Hamstrings" },
                new Muscle { Id = 9, Name = "Glutes" },
                new Muscle { Id = 10, Name = "Calves" },
                new Muscle { Id = 11, Name = "Core" }
            );
        }

        private static void SeedMuscleGroupMuscles(GymDbContext context)
        {
            context.MuscleGroupMuscles.AddRange(
                // Full Body
                new MuscleGroupMuscle { IdMuscleGroup = 1, IdMuscle = 1 },
                new MuscleGroupMuscle { IdMuscleGroup = 1, IdMuscle = 2 },
                new MuscleGroupMuscle { IdMuscleGroup = 1, IdMuscle = 3 },
                new MuscleGroupMuscle { IdMuscleGroup = 1, IdMuscle = 4 },
                new MuscleGroupMuscle { IdMuscleGroup = 1, IdMuscle = 5 },
                new MuscleGroupMuscle { IdMuscleGroup = 1, IdMuscle = 6 },
                new MuscleGroupMuscle { IdMuscleGroup = 1, IdMuscle = 7 },
                new MuscleGroupMuscle { IdMuscleGroup = 1, IdMuscle = 8 },
                new MuscleGroupMuscle { IdMuscleGroup = 1, IdMuscle = 9 },
                new MuscleGroupMuscle { IdMuscleGroup = 1, IdMuscle = 10 },
                new MuscleGroupMuscle { IdMuscleGroup = 1, IdMuscle = 11 },

                // Upper
                new MuscleGroupMuscle { IdMuscleGroup = 2, IdMuscle = 1 },
                new MuscleGroupMuscle { IdMuscleGroup = 2, IdMuscle = 2 },
                new MuscleGroupMuscle { IdMuscleGroup = 2, IdMuscle = 3 },
                new MuscleGroupMuscle { IdMuscleGroup = 2, IdMuscle = 4 },
                new MuscleGroupMuscle { IdMuscleGroup = 2, IdMuscle = 5 },
                new MuscleGroupMuscle { IdMuscleGroup = 2, IdMuscle = 6 },

                // Lower
                new MuscleGroupMuscle { IdMuscleGroup = 3, IdMuscle = 7 },
                new MuscleGroupMuscle { IdMuscleGroup = 3, IdMuscle = 8 },
                new MuscleGroupMuscle { IdMuscleGroup = 3, IdMuscle = 9 },
                new MuscleGroupMuscle { IdMuscleGroup = 3, IdMuscle = 10 },
                new MuscleGroupMuscle { IdMuscleGroup = 3, IdMuscle = 11 },

                // Push
                new MuscleGroupMuscle { IdMuscleGroup = 4, IdMuscle = 1 },
                new MuscleGroupMuscle { IdMuscleGroup = 4, IdMuscle = 4 },
                new MuscleGroupMuscle { IdMuscleGroup = 4, IdMuscle = 6 },

                // Pull
                new MuscleGroupMuscle { IdMuscleGroup = 5, IdMuscle = 2 },
                new MuscleGroupMuscle { IdMuscleGroup = 5, IdMuscle = 3 },
                new MuscleGroupMuscle { IdMuscleGroup = 5, IdMuscle = 5 },

                // Legs
                new MuscleGroupMuscle { IdMuscleGroup = 6, IdMuscle = 7 },
                new MuscleGroupMuscle { IdMuscleGroup = 6, IdMuscle = 8 },
                new MuscleGroupMuscle { IdMuscleGroup = 6, IdMuscle = 9 },
                new MuscleGroupMuscle { IdMuscleGroup = 6, IdMuscle = 10 },
                new MuscleGroupMuscle { IdMuscleGroup = 6, IdMuscle = 11 }
            );
        }

        private static void SeedTrainingTypeSequences(GymDbContext context)
        {
            context.TrainingTypeSequences.AddRange(
                // Full Body
                new TrainingTypeSequence { Id = 1, IdTrainingType = 1, IdMuscleGroup = 1, OrderInCycle = 1 },

                // Upper Lower
                new TrainingTypeSequence { Id = 2, IdTrainingType = 2, IdMuscleGroup = 2, OrderInCycle = 1 },
                new TrainingTypeSequence { Id = 3, IdTrainingType = 2, IdMuscleGroup = 3, OrderInCycle = 2 },

                // Push Pull Legs
                new TrainingTypeSequence { Id = 4, IdTrainingType = 3, IdMuscleGroup = 4, OrderInCycle = 1 },
                new TrainingTypeSequence { Id = 5, IdTrainingType = 3, IdMuscleGroup = 5, OrderInCycle = 2 },
                new TrainingTypeSequence { Id = 6, IdTrainingType = 3, IdMuscleGroup = 6, OrderInCycle = 3 }
            );
        }

        private static void SeedExercises(GymDbContext context)
        {
            context.Exercises.AddRange(
                // Chest
                new Exercise { Id = 1, Name = "Bench Press", Complex = true, IdMuscle = 1 },
                new Exercise { Id = 2, Name = "Incline Dumbbell Press", Complex = false, IdMuscle = 1 },
                new Exercise { Id = 3, Name = "Cable Fly", Complex = false, IdMuscle = 1 },

                // Upper Back
                new Exercise { Id = 4, Name = "Deadlift", Complex = true, IdMuscle = 2 },
                new Exercise { Id = 5, Name = "Barbell Row", Complex = false, IdMuscle = 2 },
                new Exercise { Id = 6, Name = "Chest Supported Row", Complex = false, IdMuscle = 2 },

                // Lats
                new Exercise { Id = 7, Name = "Pull Up", Complex = false, IdMuscle = 3 },
                new Exercise { Id = 8, Name = "Lat Pulldown", Complex = false, IdMuscle = 3 },
                // Shoulders
                new Exercise { Id = 9, Name = "Overhead Press", Complex = false, IdMuscle = 4 },
                new Exercise { Id = 10, Name = "Lateral Raise", Complex = false, IdMuscle = 4 },

                // Biceps
                new Exercise { Id = 11, Name = "Barbell Curl", Complex = false, IdMuscle = 5 },
                new Exercise { Id = 12, Name = "Incline Dumbbell Curl", Complex = false, IdMuscle = 5 },
                // Triceps
                new Exercise { Id = 13, Name = "Close Grip Bench Press", Complex = false, IdMuscle = 6 },
                new Exercise { Id = 14, Name = "Cable Pushdown", Complex = false, IdMuscle = 6 },

                // Quads
                new Exercise { Id = 15, Name = "Back Squat", Complex = true, IdMuscle = 7 },
                new Exercise { Id = 16, Name = "Leg Extension", Complex = false, IdMuscle = 7 },
                // Hamstrings
                new Exercise { Id = 17, Name = "Romanian Deadlift", Complex = false, IdMuscle = 8 },
                new Exercise { Id = 18, Name = "Leg Curl", Complex = false, IdMuscle = 8 },

                // Glutes
                new Exercise { Id = 19, Name = "Hip Thrust", Complex = false, IdMuscle = 9 },
                new Exercise { Id = 20, Name = "Cable Kickback", Complex = false, IdMuscle = 9 },
                // Calves
                new Exercise { Id = 21, Name = "Standing Calf Raise", Complex = false, IdMuscle = 10 },

                // Core
                new Exercise { Id = 22, Name = "Hanging Leg Raise", Complex = false, IdMuscle = 11 },
                new Exercise { Id = 23, Name = "Cable Crunch", Complex = false, IdMuscle = 11 }
            );
        }
    }
}