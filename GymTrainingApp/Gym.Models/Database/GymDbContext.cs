using Gym.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gym.Models.Data
{
    public class GymDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<MuscleGroup> MuscleGroups { get; set; }
        public DbSet<Muscle> Muscles { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<AimOfPlan> AimsOfPlan { get; set; }
        public DbSet<TrainingType> TrainingTypes { get; set; }
        public DbSet<TrainingTypeSequence> TrainingTypeSequences { get; set; }
        public DbSet<TrainingPlan> TrainingPlans { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<ExerciseInTraining> ExercisesInTraining { get; set; }

        public GymDbContext(DbContextOptions<GymDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Unique username
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            // User -> TrainingPlan
            modelBuilder.Entity<TrainingPlan>()
                .HasOne(tp => tp.User)
                .WithMany(u => u.TrainingPlans)
                .HasForeignKey(tp => tp.IdUser);

            // TrainingType -> TrainingPlan
            modelBuilder.Entity<TrainingPlan>()
                .HasOne(tp => tp.TrainingType)
                .WithMany(tt => tt.TrainingPlans)
                .HasForeignKey(tp => tp.IdTrainingType);

            // AimOfPlan -> TrainingPlan
            modelBuilder.Entity<TrainingPlan>()
                .HasOne(tp => tp.AimOfTraining)
                .WithMany(a => a.TrainingPlans)
                .HasForeignKey(tp => tp.IdAimOfTraining);

            // TrainingPlan -> Training
            modelBuilder.Entity<Training>()
                .HasOne(t => t.TrainingPlan)
                .WithMany(tp => tp.Trainings)
                .HasForeignKey(t => t.IdTrainingPlan);

            // TrainingTypeSequence -> Training
            modelBuilder.Entity<Training>()
                .HasOne(t => t.TrainingTypeSequence)
                .WithMany(tts => tts.Trainings)
                .HasForeignKey(t => t.IdTrainingTypeSequence);

            // MuscleGroup -> Muscle
            modelBuilder.Entity<Muscle>()
                .HasOne(m => m.MuscleGroup)
                .WithMany(mg => mg.Muscles)
                .HasForeignKey(m => m.IdMuscleGroup);

            // Muscle -> Exercise
            modelBuilder.Entity<Exercise>()
                .HasOne(e => e.Muscle)
                .WithMany(m => m.Exercises)
                .HasForeignKey(e => e.IdMuscle);

            // TrainingType -> TrainingTypeSequence
            modelBuilder.Entity<TrainingTypeSequence>()
                .HasOne(tts => tts.TrainingType)
                .WithMany(tt => tt.TrainingTypeSequences)
                .HasForeignKey(tts => tts.IdTrainingType);

            // MuscleGroup -> TrainingTypeSequence
            modelBuilder.Entity<TrainingTypeSequence>()
                .HasOne(tts => tts.MuscleGroup)
                .WithMany(mg => mg.TrainingTypeSequences)
                .HasForeignKey(tts => tts.IdMuscleGroup);

            // Exercise -> ExerciseInTraining
            modelBuilder.Entity<ExerciseInTraining>()
                .HasOne(eit => eit.Exercise)
                .WithMany(e => e.ExercisesInTraining)
                .HasForeignKey(eit => eit.IdExercise);

            // Training -> ExerciseInTraining
            modelBuilder.Entity<ExerciseInTraining>()
                .HasOne(eit => eit.Training)
                .WithMany(t => t.ExercisesInTraining)
                .HasForeignKey(eit => eit.IdTraining);
        }
    }
}