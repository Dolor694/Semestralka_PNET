using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.UI.ConsoleUI.Interfaces;
using Gym.UI.ConsoleUI.Pages;

namespace Gym.UI.ConsoleUI.PageFactory
{
    public class PageFactory
    {

        public IPage CreatePage(int pageId, AppService appService)
        {
            switch (pageId)
            {
                case 0:
                    return new RegisterPage(appService);
                case 1:
                    return new MainPage();
                case 2:
                    return new ProfileManagerPage(appService);
                case 3:
                    return new PlansPage(appService);
                case 4:
                    return new CreatePlanPage(appService);
                case 5:
                    return new TrainingsPage(appService);
                case 6:
                    return new ManageTrainingPage(appService);
                case 7:
                    return new EditExercisePage(appService);
                case 8:
                    return new AddExercisePage(appService);
                default:
                    return new RegisterPage(appService);
            }
        }
    }
}
