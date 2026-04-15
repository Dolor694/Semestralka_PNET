using Gym.Business;
using Gym.Business.Interfaces;
using Gym.UI.ConsoleUI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.UI.ConsoleUI.Pages
{
    public class AddExercisePage : Logout, IPage
    {
        private readonly IExerciseInTrainingService _exerciseInTrainingService;
        private readonly IExerciseService _exerciseService;
        private readonly IMuscleGroupService _muscleGroupService;

        public AddExercisePage(AppService appService)
        {
            _exerciseInTrainingService = appService.ExerciseInTrainingService;
            _exerciseService = appService.ExerciseService;
            _muscleGroupService = appService.MuscleGroupService;
        }

        public void ShowPage()
        {
            Console.Clear();
            while (CurrentPage.PageId == 8)
            {
                Console.WriteLine("Add Exercise to Training");
                Console.WriteLine(new string('=', 40));

                // Show available muscle groups
                List<MuscleGroupDTO> muscleGroups = _muscleGroupService.GetAllMuscleGroups();

                if (muscleGroups.Count == 0)
                {
                    Console.WriteLine("No muscle groups available.");
                    CurrentPage.PageId = 6;
                    return;
                }

                Console.WriteLine("Select a muscle group:");
                for (int i = 0; i < muscleGroups.Count; i++)
                {
                    Console.WriteLine($"  {i + 1} - {muscleGroups[i].Name}");
                }
                Console.WriteLine("  B - Back to Training");
                Console.WriteLine(new string('=', 40));

                string? groupInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(groupInput))
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }

                if (char.ToUpperInvariant(groupInput[0]) == 'B')
                {
                    CurrentPage.PageId = 6;
                    return;
                }

                if (!int.TryParse(groupInput, out int groupNumber) || groupNumber < 1 || groupNumber > muscleGroups.Count)
                {
                    Console.WriteLine("Invalid muscle group number.");
                    continue;
                }

                SelectExerciseFromGroup(muscleGroups[groupNumber - 1].Id);
            }
        }

        private void SelectExerciseFromGroup(int idMuscleGroup)
        {
            List<ExerciseDTO> exercises = _exerciseService.GetExercisesByMuscleGroup(idMuscleGroup);

            if (exercises.Count == 0)
            {
                Console.WriteLine("No exercises available for this muscle group.");
                return;
            }

            Console.WriteLine("Select an exercise:");
            Console.WriteLine(new string('-', 40));
            for (int i = 0; i < exercises.Count; i++)
            {
                string type = exercises[i].Complex ? "Compound" : "Isolation";
                Console.WriteLine($"  {i + 1} - {exercises[i].Name} ({type})");
            }
            Console.WriteLine(new string('-', 40));

            string? exerciseInput = Console.ReadLine();

            if (!int.TryParse(exerciseInput, out int exerciseNumber) || exerciseNumber < 1 || exerciseNumber > exercises.Count)
            {
                Console.WriteLine("Invalid exercise number.");
                return;
            }

            ExerciseDTO selectedExercise = exercises[exerciseNumber - 1];

            // Get sets
            Console.Write("Number of sets (1-10): ");
            string? setsInput = Console.ReadLine();
            if (!int.TryParse(setsInput, out int sets) || sets < 1 || sets > 10)
            {
                Console.WriteLine("Invalid sets value (1-10).");
                return;
            }

            // Get reps
            Console.Write("Number of reps (1-30): ");
            string? repsInput = Console.ReadLine();
            if (!int.TryParse(repsInput, out int reps) || reps < 1 || reps > 30)
            {
                Console.WriteLine("Invalid reps value (1-30).");
                return;
            }

            try
            {
                // Determine the next order number
                List<ExerciseInTrainingDTO> existing = _exerciseInTrainingService
                    .GetExercisesByTrainingId(SelectedTraining.Id);
                int nextOrder = existing.Count > 0 ? existing.Max(e => e.Order) + 1 : 1;

                _exerciseInTrainingService.CreateExerciseInTraining(
                    sets, reps, nextOrder, selectedExercise.Id, SelectedTraining.Id);

                Console.WriteLine($"'{selectedExercise.Name}' added successfully!");

                // Return to manage training page
                CurrentPage.PageId = 6;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding exercise: {ex.Message}");
            }
        }
    }
}