/*
 * Gym - A simple application for managing gym trainings and plans for users and allows to automaticaly generate training plans.
 * 
 * @author: Lukáš Proisl
 * @date: 2026-04
 */


/*
 * Main entry point for the Gym application.
 */
using Gym.UI.ConsoleUI;
using Gym.UI.ConsoleUI.PageFactory;
using Gym.UI.ConsoleUI.Interfaces;

public class Program
{
    public static void Main(string[] args)
    {
        // Default/empty values for the logged in user at the start of the application
        LoggedInUser.Id = -1;
        LoggedInUser.Username = string.Empty; 
        LoggedInUser.Weight = 0.0;

        // Set the initial page to the register/login page
        CurrentPage.PageId = 0;

        AppService appService = new AppService();
        PageFactory pageFactory = new PageFactory();

        IPage currentPage = pageFactory.CreatePage(CurrentPage.PageId, appService);
        
        while (true)
        {
            currentPage.ShowPage();
            currentPage = pageFactory.CreatePage(CurrentPage.PageId, appService);
        }
    }
}