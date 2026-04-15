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
    public class PlansPage : Logout, IPage
    {
        private List<MenuItem> _items;
        ITrainingPlanService _trainingPlanService;

        public PlansPage(AppService appService)
        {
            _trainingPlanService = appService.TrainingPlanService;
            _items = new List<MenuItem> {
                new MenuItem('A', "Add new plan", CreatePlan),
                new MenuItem('B', "Back to Main Menu", () => CurrentPage.PageId = 1),
                new MenuItem('L', "Logout", PerformLogout),
                new MenuItem('Q', "Quit", () => Environment.Exit(0))
            };
        }

        public void ShowPage()
        {
            Console.Clear();
            while (CurrentPage.PageId == 3)
            {
                DisplayMenu();

                var actions = _items.ToDictionary(i => char.ToUpperInvariant(i.Key), i => i);

                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid action");
                    continue;
                }

                // Check if the user entered a number to select a plan
                if (int.TryParse(input, out int planNumber))
                {
                    SelectPlan(planNumber);
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
            Console.WriteLine("Training plans");
            Console.WriteLine(new string('=', 40));

            foreach (MenuItem item in _items)
            {
                Console.WriteLine($"{item.Key} - {item.Description}");
            }

            Console.WriteLine(new string('-', 40));

            List<TrainingPlanDTO> plans = GetPlansByUser();

            if (plans.Count == 0)
            {
                Console.WriteLine("No training plans found.");
            }
            else
            {
                Console.WriteLine("Select a plan by entering its number:");
                for (int i = 0; i < plans.Count; i++)
                {
                    Console.WriteLine($"  {i + 1} - {plans[i].PlanName} (Frequency: {plans[i].TrainingFrequency}x/week)");
                }
            }

            Console.WriteLine(new string('=', 40));
        }

        private List<TrainingPlanDTO> GetPlansByUser()
        {
            return _trainingPlanService.GetPlansByUserId(LoggedInUser.Id);
        }

        private void SelectPlan(int planNumber)
        {
            List<TrainingPlanDTO> plans = GetPlansByUser();

            if (planNumber < 1 || planNumber > plans.Count)
            {
                Console.WriteLine("Invalid plan number.");
                return;
            }

            TrainingPlanDTO selectedPlan = plans[planNumber - 1];

            // Store the selected plan info for the TrainingsPage
            SelectedPlan.Id = selectedPlan.Id;
            SelectedPlan.PlanName = selectedPlan.PlanName;

            // Navigate to the trainings page
            CurrentPage.PageId = 5;
        }

        private void CreatePlan()
        {
            // Navigate to the plan creation page
            CurrentPage.PageId = 4; 
        }
    }
}
