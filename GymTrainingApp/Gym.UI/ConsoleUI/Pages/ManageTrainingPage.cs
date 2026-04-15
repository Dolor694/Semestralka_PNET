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
    public class ManageTrainingPage : Logout, IPage
    {
        private List<MenuItem> _items;
        private readonly IExerciseInTrainingService _exerciseInTrainingService;
        private readonly IExerciseService _exerciseService;

        public ManageTrainingPage(AppService appService)
        {
            _exerciseInTrainingService = appService.ExerciseInTrainingService;
            _exerciseService = appService.ExerciseService;
            _items = new List<MenuItem> {
                new MenuItem('E', "Edit an exercise", () => CurrentPage.PageId = 7),
                new MenuItem('R', "Remove an exercise", RemoveExercise),
                new MenuItem('A', "Add an exercise", () => CurrentPage.PageId = 8),
                new MenuItem('B', "Back to Trainings", () => CurrentPage.PageId = 5),
                new MenuItem('L', "Logout", PerformLogout),
                new MenuItem('Q', "Quit", () => Environment.Exit(0))
            };
        }

        public void ShowPage()
        {
            Console.Clear();
            while (CurrentPage.PageId == 6)
            {
                DisplayMenu();

                var actions = _items.ToDictionary(i => char.ToUpperInvariant(i.Key), i => i);

                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid action");
                    continue;
                }

                char key = char.ToUpperInvariant(input[0]);
                if (actions.TryGetValue(key, out var action))
                {
                    action.Action();
                }
                else
                {
                    Console.WriteLine("Invalid action");
                }
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine($"Training #{SelectedTraining.Id}");
            Console.WriteLine(new string('=', 40));

            foreach (MenuItem item in _items)
            {
                Console.WriteLine($"{item.Key} - {item.Description}");
            }

            Console.WriteLine(new string('-', 40));

            List<ExerciseInTrainingDTO> exercises = GetExercisesInTraining();

            if (exercises.Count == 0)
            {
                Console.WriteLine("No exercises in this training.");
            }
            else
            {
                Console.WriteLine($"{"#",-4}{"Exercise",-20}{"Sets",-8}{"Reps",-8}{"Order",-8}");
                Console.WriteLine(new string('-', 48));
                for (int i = 0; i < exercises.Count; i++)
                {
                    ExerciseDTO? exercise = _exerciseService.GetExerciseById(exercises[i].IdExercise);
                    string name = exercise?.Name ?? "Unknown";
                    Console.WriteLine($"{i + 1,-4}{name,-20}{exercises[i].Sets,-8}{exercises[i].Reps,-8}{exercises[i].Order,-8}");
                }
            }

            Console.WriteLine(new string('=', 40));
        }

        private List<ExerciseInTrainingDTO> GetExercisesInTraining()
        {
            return _exerciseInTrainingService.GetExercisesByTrainingId(SelectedTraining.Id);
        }

        private void RemoveExercise()
        {
            List<ExerciseInTrainingDTO> exercises = GetExercisesInTraining();

            if (exercises.Count <= 1)
            {
                Console.WriteLine("Training must have at least one exercise.");
                return;
            }

            Console.Write("Enter exercise number to remove: ");
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int exerciseNumber) || exerciseNumber < 1 || exerciseNumber > exercises.Count)
            {
                Console.WriteLine("Invalid exercise number.");
                return;
            }

            try
            {
                _exerciseInTrainingService.DeleteExerciseInTraining(exercises[exerciseNumber - 1].Id);
                Console.WriteLine("Exercise removed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing exercise: {ex.Message}");
            }
        }
    }
}
