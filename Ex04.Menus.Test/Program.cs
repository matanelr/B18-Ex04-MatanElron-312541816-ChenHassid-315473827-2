using Ex04.Menus.Interfaces;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            Interfaces.MainMenu interfaceMenu = buildMainMenuInterface();
            Delegates.MainMenu delegateMenu = buildMainMenuDelegates();
            interfaceMenu.Show();
            delegateMenu.Show();
        }

        // Building the main menu using interfaces
        private static Interfaces.MainMenu buildMainMenuInterface()
        {
            // Create Executable Items 
            IExecutable showTimeExecute = new MenuDelegatesAndInterfaces.ShowTime();
            IExecutable showDateExcute = new MenuDelegatesAndInterfaces.ShowDate();
            IExecutable countCapitalsExcute = new MenuDelegatesAndInterfaces.CountCapitals();
            IExecutable showVersionExcute = new MenuDelegatesAndInterfaces.ShowVersion();

            Interfaces.ExecutableItem executableItemShowTime = new Interfaces.ExecutableItem("Show Time", showTimeExecute);
            Interfaces.ExecutableItem executableItemShowDate = new Interfaces.ExecutableItem("Show Date", showDateExcute);
            Interfaces.ExecutableItem executableItemCountCapitals = new Interfaces.ExecutableItem("Count Capitals", countCapitalsExcute);
            Interfaces.ExecutableItem executableItemShowVersion = new Interfaces.ExecutableItem("Show Version", showVersionExcute);

            // Creates the sub menus: "Show Date/Time" and "Version and Capitals"
            Interfaces.SubMenu showDateAndTimeMenu = new Interfaces.SubMenu("Show Date/Time");
            showDateAndTimeMenu.AddItem(executableItemShowTime);
            showDateAndTimeMenu.AddItem(executableItemShowDate);
            Interfaces.SubMenu VersionAndCapitalsMenu = new Interfaces.SubMenu("Version and Capitals");
            VersionAndCapitalsMenu.AddItem(executableItemCountCapitals);
            VersionAndCapitalsMenu.AddItem(executableItemShowVersion);

            // Creates the Main Menu with both of the sub menus
            Interfaces.MainMenu mainMenuInterface = new Interfaces.MainMenu("Main Menu Using Interface");
            mainMenuInterface.AddItemToMainMenu(showDateAndTimeMenu);
            mainMenuInterface.AddItemToMainMenu(VersionAndCapitalsMenu);
            return mainMenuInterface;
        }

        // building the main menu using delegates
        private static Delegates.MainMenu buildMainMenuDelegates()
        {
            ExecutableHandler showTimeExecute = new MenuDelegatesAndInterfaces.ShowTime().Execute;
            ExecutableHandler showDateExcute = new MenuDelegatesAndInterfaces.ShowDate().Execute;
            ExecutableHandler countCapitalsExcute = new MenuDelegatesAndInterfaces.CountCapitals().Execute;
            ExecutableHandler showVersionExcute = new MenuDelegatesAndInterfaces.ShowVersion().Execute;

            Delegates.ExecutableItem executableItemShowTime = new Delegates.ExecutableItem("Show Time", showTimeExecute);
            Delegates.ExecutableItem executableItemShowDate = new Delegates.ExecutableItem("Show Date", showDateExcute);
            Delegates.ExecutableItem executableItemCountCapitals = new Delegates.ExecutableItem("Count Capitals Letters", countCapitalsExcute);
            Delegates.ExecutableItem executableItemShowVersion = new Delegates.ExecutableItem("Show Version", showVersionExcute);

            // Creates the sub menus: "Show Date/Time" and "Version and Capitals"
            Delegates.SubMenu showDateAndTimeMenu = new Delegates.SubMenu("Show Date/Time");
            showDateAndTimeMenu.AddItem(executableItemShowTime);
            showDateAndTimeMenu.AddItem(executableItemShowDate);
            Delegates.SubMenu VersionAndCapitalsMenu = new Delegates.SubMenu("Version and Capitals");
            VersionAndCapitalsMenu.AddItem(executableItemCountCapitals);
            VersionAndCapitalsMenu.AddItem(executableItemShowVersion);

            // Creates the Main Menu with both of the sub menus
            Delegates.MainMenu mainMenuDelegate = new Delegates.MainMenu("Main Menu Using Delegate");
            mainMenuDelegate.AddItemToMainMenu(showDateAndTimeMenu);
            mainMenuDelegate.AddItemToMainMenu(VersionAndCapitalsMenu);
            return mainMenuDelegate;
        }
    }
}
