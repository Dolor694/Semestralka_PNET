using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.UI.ConsoleUI
{
    internal record MenuItem(char Key, string Description, Action Action);
}
