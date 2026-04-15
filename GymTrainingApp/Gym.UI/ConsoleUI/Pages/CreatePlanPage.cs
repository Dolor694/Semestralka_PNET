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
    public class CreatePlanPage : Logout, IPage
    {
        private readonly ITrainingPlanService _trainingPlanService;
        private readonly ITrainingTypeService _trainingTypeService;
        private readonly IAimOfPlanService _aimOfPlanService;

        public CreatePlanPage(AppService appService)
        {
            _trainingPlanService = appService.TrainingPlanService;
            _trainingTypeService = appService.TrainingTypeService;
            _aimOfPlanService = appService.AimOfPlanService;
        }

        public void ShowPage()
        {
            Console.Clear();
            Console.WriteLine("Create New Training Plan");
            Console.WriteLine(new string('=', 40));

            // Plan name
            Console.Write("Plan name: ");
            string? planName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(planName))
            {
                Console.WriteLine("Plan name cannot be empty.");
                CurrentPage.PageId = 3;
                return;
            }

            // Training frequency
            Console.Write("Training frequency (1-7 days per week): ");
            string? frequencyInput = Console.ReadLine();
            if (!int.TryParse(frequencyInput, out int trainingFrequency) || trainingFrequency < 1 || trainingFrequency > 7)
            {
                Console.WriteLine("Invalid frequency (1-7).");
                CurrentPage.PageId = 3;
                return;
            }

            // Training type selection
            List<TrainingTypeDTO> trainingTypes = _trainingTypeService.GetAllTrainingTypes();
            if (trainingTypes.Count == 0)
            {
                Console.WriteLine("No training types available.");
                CurrentPage.PageId = 3;
                return;
            }

            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Select training type:");
            for (int i = 0; i < trainingTypes.Count; i++)
            {
                Console.WriteLine($"  {i + 1} - {trainingTypes[i].Name}");
            }

            string? typeInput = Console.ReadLine();
            if (!int.TryParse(typeInput, out int typeNumber) || typeNumber < 1 || typeNumber > trainingTypes.Count)
            {
                Console.WriteLine("Invalid training type selection.");
                CurrentPage.PageId = 3;
                return;
            }
            int idTrainingType = trainingTypes[typeNumber - 1].Id;

            // Aim of training selection
            List<AimOfPlanDTO> aims = _aimOfPlanService.GetAllAimsOfPlan();
            if (aims.Count == 0)
            {
                Console.WriteLine("No aims of training available.");
                CurrentPage.PageId = 3;
                return;
            }

            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Select aim of training:");
            for (int i = 0; i < aims.Count; i++)
            {
                Console.WriteLine($"  {i + 1} - {aims[i].Description}");
            }

            string? aimInput = Console.ReadLine();
            if (!int.TryParse(aimInput, out int aimNumber) || aimNumber < 1 || aimNumber > aims.Count)
            {
                Console.WriteLine("Invalid aim selection.");
                CurrentPage.PageId = 3;
                return;
            }
            int idAimOfTraining = aims[aimNumber - 1].Id;

            // Create the plan
            try
            {
                _trainingPlanService.CreateTrainingPlan(
                    planName, trainingFrequency, LoggedInUser.Id, idTrainingType, idAimOfTraining);

                Console.WriteLine(new string('=', 40));
                Console.WriteLine($"Plan '{planName}' created successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating plan: {ex.Message}");
            }

            // Navigate back to plans page
            CurrentPage.PageId = 3;
        }
    }
}
