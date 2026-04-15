using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.UI.ConsoleUI.Interfaces
{
    public abstract class Logout
    {
        public static void PerformLogout()
        {
            // Clear the logged in user information
            LoggedInUser.Id = -1;
            LoggedInUser.Username = string.Empty;
            LoggedInUser.Weight = 0.0;
            Console.WriteLine("You have been logged out successfully.");

            // Reset to the register/login page
            CurrentPage.PageId = 0; 
        }
    }
}
