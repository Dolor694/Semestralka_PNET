using Gym.UI.ConsoleUI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Gym.UI.ConsoleUI.Pages
{
    public class MainPage : Logout, IPage
    {
        private List<MenuItem> _items;

        public MainPage()
        {
            _items = new List<MenuItem>
            {
                new MenuItem('P', "Manage profile", Profile),
                new MenuItem('A', "Show all training plans", ShowAllTrainingPlans),
                new MenuItem('L', "Logout", PerformLogout),
                new MenuItem('Q', "Quit", () => Environment.Exit(0))
            };
        }

        public void ShowPage()
        {
            Console.Clear();
            while (CurrentPage.PageId == 1)
            {
                DisplayMenu();

                var actions = _items.ToDictionary(i => char.ToUpperInvariant(i.Key), i => i);

                var key = char.ToUpperInvariant(Console.ReadKey().KeyChar);

                // Move to the next line after key press
                Console.WriteLine(); 

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
            Console.WriteLine("Main Menu");
            Console.WriteLine(new string('=', 40));

            foreach (MenuItem item in _items)
            {
                Console.WriteLine($"{item.Key} - {item.Description}");
            }
            Console.WriteLine(new string('=', 40));
        }

        private void Profile()
        {
            // Navigate to profile page
            CurrentPage.PageId = 2;
        }

        private void ShowAllTrainingPlans()
        {
            // Navigate to training plans page
            CurrentPage.PageId = 3;
        }
    }
}
