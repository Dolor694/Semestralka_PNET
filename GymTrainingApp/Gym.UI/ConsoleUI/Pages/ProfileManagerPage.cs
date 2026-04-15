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
    public class ProfileManagerPage : Logout, IPage
    {
        private List<MenuItem> _items;
        IUserService _userService;
        public ProfileManagerPage(AppService appService)
        {
            _userService = appService.UserService;
            _items = new List<MenuItem> {
                new MenuItem('U', "Change Username", EditUsername),
                new MenuItem('W', "Change Weight", EditWeight),
                new MenuItem('P', "Change Password", ChangePassword),
                new MenuItem('B', "Back to Main Menu", () => CurrentPage.PageId = 1),
                new MenuItem('L', "Logout", PerformLogout),
                new MenuItem('Q', "Quit", () => Environment.Exit(0))
            };
        }

        public void ShowPage()
        {
            Console.Clear();
            while (CurrentPage.PageId == 2)
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
            Console.WriteLine("Profile Manager");
            Console.WriteLine(new string('=', 40));

            foreach (MenuItem item in _items)
            {
                Console.WriteLine($"{item.Key} - {item.Description}");
            }
            Console.WriteLine(new string('=', 40));
        }

        private void EditUsername()
        {
            Console.Write("Enter new username: ");
            string newUsername = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(newUsername))
            {
                Console.WriteLine("Username cannot be empty.");
                return;
            }

            try
            {
                _userService.UpdateUser(LoggedInUser.Id, newUsername, null, null);

                // Update the logged in user info
                LoggedInUser.Username = newUsername; 
                Console.WriteLine("Username updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating username: {ex.Message}");
            }
        }

        private void EditWeight()
        {
            Console.Write("Enter new weight: ");
            string newWeight = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(newWeight))
            {
                Console.WriteLine("Weight cannot be empty.");
                return;
            }

            try
            {
                double weightValue = double.Parse(newWeight);

                _userService.UpdateUser(LoggedInUser.Id, null, null, weightValue);

                // Update the logged in user info
                LoggedInUser.Weight = weightValue;
                Console.WriteLine("Weight updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating weight: {ex.Message}");
            }
        }

        private void ChangePassword()
        {
            Console.Write("Enter new password: ");
            string newPassword = Console.ReadLine() ?? string.Empty;

            Console.Write("Confirm new password: ");
            string confirmPassword = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                Console.WriteLine("Password cannot be empty.");
                return;
            }

            if (newPassword != confirmPassword)
            {
                Console.WriteLine("Passwords do not match.");
                return;
            }

            try
            {
                _userService.UpdateUser(LoggedInUser.Id, null, newPassword, null);

                Console.WriteLine("Password updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating password: {ex.Message}");
            }
        }
    }
}
