using Gym.Business;
using Gym.Business.Interfaces;
using Gym.Models.Entities;
using Gym.UI.ConsoleUI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.UI.ConsoleUI.Pages
{
    public class TrainingsPage : Logout, IPage
    {
        private List<MenuItem> _items;
        ITrainingService _trainingService;

        public TrainingsPage(AppService appService)
        {
            _trainingService = appService.TrainingService;
            _items = new List<MenuItem> {
                new MenuItem('G', "Generate new training", GenerateTraining),
                new MenuItem('B', "Back to Plans", () => CurrentPage.PageId = 3),
                new MenuItem('L', "Logout", PerformLogout),
                new MenuItem('Q', "Quit", () => Environment.Exit(0))
            };
        }

        public void ShowPage()
        {
            Console.Clear();
            while (CurrentPage.PageId == 5)
            {
                DisplayMenu();

                var actions = _items.ToDictionary(i => char.ToUpperInvariant(i.Key), i => i);

                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid action");
                    continue;
                }

                // Check if the user entered a number to select a training
                if (int.TryParse(input, out int trainingNumber))
                {
                    SelectTraining(trainingNumber);
                    continue;
                }

                // Otherwise treat it as a menu key
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
            Console.WriteLine($"Trainings for plan: {SelectedPlan.PlanName}");
            Console.WriteLine(new string('=', 40));

            foreach (MenuItem item in _items)
            {
                Console.WriteLine($"{item.Key} - {item.Description}");
            }

            Console.WriteLine(new string('-', 40));

            List<TrainingDTO> trainings = GetTrainingsByPlan();

            if (trainings.Count == 0)
            {
                Console.WriteLine("No trainings found. Generate a new one!");
            }
            else
            {
                Console.WriteLine("Select a training by entering its number:");
                for (int i = 0; i < trainings.Count; i++)
                {
                    Console.WriteLine($"  {i + 1} - Training #{trainings[i].Id} ({trainings[i].Date})");
                }
            }

            Console.WriteLine(new string('=', 40));
        }

        private List<TrainingDTO> GetTrainingsByPlan()
        {
            return _trainingService.GetTrainingsByPlan(SelectedPlan.Id).ToList();
        }

        private void SelectTraining(int trainingNumber)
        {
            List<TrainingDTO> trainings = GetTrainingsByPlan();

            if (trainingNumber < 1 || trainingNumber > trainings.Count)
            {
                Console.WriteLine("Invalid training number.");
                return;
            }

            NavigateToManageTraining(trainings[trainingNumber - 1].Id);
        }

        private void GenerateTraining()
        {
            try
            {
                Training newTraining = _trainingService.CreateTraining(SelectedPlan.Id);
                Console.WriteLine("New training generated successfully!");

                // Navigate directly to manage the newly generated training
                NavigateToManageTraining(newTraining.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error generating training: {ex.Message}");
            }
        }

        private void NavigateToManageTraining(int idTraining)
        {
            SelectedTraining.Id = idTraining;
            CurrentPage.PageId = 6;
        }
    }
}
