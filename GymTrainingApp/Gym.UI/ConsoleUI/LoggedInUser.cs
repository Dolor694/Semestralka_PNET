using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.UI.ConsoleUI
{
    public static class LoggedInUser
    {
        public static string Username { get; set; } = string.Empty;
        public static double Weight { get; set; } = 0.0;
        public static int Id { get; set; } = -1;
    }
}
