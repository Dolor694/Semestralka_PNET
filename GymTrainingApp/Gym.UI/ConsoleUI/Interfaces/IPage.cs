using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.UI.ConsoleUI.Interfaces
{
    public interface IPage
    {

        /*
         * Displays the page and handles user input until the user navigates away from the page. 
         */
        public void ShowPage();
    }
}
