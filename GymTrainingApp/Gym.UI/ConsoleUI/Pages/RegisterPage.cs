using Gym.Business;
using Gym.Business.Interfaces;
using Gym.Business.Services;
using Gym.UI.ConsoleUI.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.UI.ConsoleUI.Pages
{
    public class RegisterPage : IPage
    {
        private List<MenuItem> _items;
        private IUserService _userService;

        public RegisterPage(AppService appService) 
        {
            _userService = appService.UserService;
            _items = new List<MenuItem> {
                new MenuItem ('R', "Register", Register),
                new MenuItem ('L', "Login", Login),
                new MenuItem ('Q', "Quit", () => Environment.Exit(0))
            };
        }

        public void ShowPage()
        {
            while (CurrentPage.PageId == 0)
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
                    Console.WriteLine("Neplatna akce");
                }
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine("Welcome to the Gym Training App, please Log in or Register");
            Console.WriteLine(new string('=', 40));

            foreach (MenuItem item in _items)
            {
                Console.WriteLine($"{item.Key} - {item.Description}");
            }
            Console.WriteLine(new string('=', 40));
        }

        private void Register()
        {
            Console.WriteLine("Enter your username: ");
            string? username = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(username))
            {
                Console.WriteLine("Username cannot be empty.");
                return;
            }

            Console.WriteLine("Enter weight: ");
            string? weightInput = Console.ReadLine();
            if (!double.TryParse(weightInput, out double weight) || weight <= 0)
            {
                Console.WriteLine("Invalid weight.");
                return;
            }

            Console.WriteLine("Enter your password: ");
            string? password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Password cannot be empty.");
                return;
            }

            Console.WriteLine("Repeat password: ");
            string? repeatPassword = Console.ReadLine();
            if (password != repeatPassword)
            {
                Console.WriteLine("Passwords do not match.");
                return;
            }

            try
            {
                _userService.CreateUser(username, password, weight);
                Console.WriteLine("Registration successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void Login()
        {
            Console.WriteLine("Enter your username: ");
            string? username = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(username))
            {
                Console.WriteLine("Username cannot be empty.");
                return;
            }

            Console.WriteLine("Enter your password: ");
            string? password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Password cannot be empty.");
                return;
            }

            try
            {
                UserDTO? user = _userService.LoginUser(username, password);

                if (user == null)
                {
                    Console.WriteLine("Invalid username or password.");
                    return;
                }

                Console.WriteLine($"Login successful. Welcome, {user.Username}!");

                // Set the logged-in user information
                LoggedInUser.Id = user.Id;
                LoggedInUser.Username = user.Username;
                LoggedInUser.Weight = user.Weight;

                // Navigate to the next page
                CurrentPage.PageId = 1;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
