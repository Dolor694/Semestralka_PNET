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
    public class EditExercisePage : Logout, IPage
    {
        private readonly IExerciseInTrainingService _exerciseInTrainingService;
        private readonly IExerciseService _exerciseService;

        public EditExercisePage(AppService appService)
        {
            _exerciseInTrainingService = appService.ExerciseInTrainingService;
            _exerciseService = appService.ExerciseService;
        }

        public void ShowPage()
        {
            Console.Clear();
            while (CurrentPage.PageId == 7)
            {
                List<ExerciseInTrainingDTO> exercises = _exerciseInTrainingService
                    .GetExercisesByTrainingId(SelectedTraining.Id);

                if (exercises.Count == 0)
                {
                    Console.WriteLine("No exercises to edit.");
                    CurrentPage.PageId = 6;
                    return;
                }

                Console.WriteLine("Select exercise to edit:");
                Console.WriteLine(new string('=', 40));
                for (int i = 0; i < exercises.Count; i++)
                {
                    ExerciseDTO? exercise = _exerciseService.GetExerciseById(exercises[i].IdExercise);
                    string name = exercise?.Name ?? "Unknown";
                    Console.WriteLine($"  {i + 1} - {name} (Sets: {exercises[i].Sets}, Reps: {exercises[i].Reps})");
                }
                Console.WriteLine("  B - Back to Training");
                Console.WriteLine(new string('=', 40));

                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }

                if (char.ToUpperInvariant(input[0]) == 'B')
                {
                    CurrentPage.PageId = 6;
                    return;
                }

                if (!int.TryParse(input, out int exerciseNumber) || exerciseNumber < 1 || exerciseNumber > exercises.Count)
                {
                    Console.WriteLine("Invalid exercise number.");
                    continue;
                }

                EditSelectedExercise(exercises[exerciseNumber - 1]);
            }
        }

        private void EditSelectedExercise(ExerciseInTrainingDTO exercise)
        {
            ExerciseDTO? exerciseInfo = _exerciseService.GetExerciseById(exercise.IdExercise);
            string name = exerciseInfo?.Name ?? "Unknown";

            Console.WriteLine($"Editing: {name} (Sets: {exercise.Sets}, Reps: {exercise.Reps})");

            Console.Write("New sets (leave empty to keep current): ");
            string? setsInput = Console.ReadLine();
            int? newSets = null;
            if (!string.IsNullOrWhiteSpace(setsInput))
            {
                if (!int.TryParse(setsInput, out int parsedSets) || parsedSets < 1 || parsedSets > 10)
                {
                    Console.WriteLine("Invalid sets value (1-10).");
                    return;
                }
                newSets = parsedSets;
            }

            Console.Write("New reps (leave empty to keep current): ");
            string? repsInput = Console.ReadLine();
            int? newReps = null;
            if (!string.IsNullOrWhiteSpace(repsInput))
            {
                if (!int.TryParse(repsInput, out int parsedReps) || parsedReps < 1 || parsedReps > 30)
                {
                    Console.WriteLine("Invalid reps value (1-30).");
                    return;
                }
                newReps = parsedReps;
            }

            try
            {
                _exerciseInTrainingService.UpdateExerciseInTraining(exercise.Id, newSets, newReps, null);
                Console.WriteLine("Exercise updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating exercise: {ex.Message}");
            }
        }
    }
}