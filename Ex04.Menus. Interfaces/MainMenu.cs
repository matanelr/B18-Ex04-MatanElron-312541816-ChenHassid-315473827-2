using System;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private const string k_MenuPartition = "***************************";
        private const int k_ExitOption = 0;
        private SubMenu m_SubMenuItem;

        public MainMenu(string i_Titel)
        {
            m_SubMenuItem = new SubMenu(i_Titel);
            m_SubMenuItem.ListOfMenuItems[k_ExitOption].Title = "Exit";
        }

        public string MenuPartition
        {
            get
            {
                return k_MenuPartition;
            }
        }

        public int ExitOption
        {
            get
            {
                return k_ExitOption;
            }
        }

        public SubMenu SubMenuItem
        {
            get
            {
                return m_SubMenuItem;
            }
        }

        public void AddItemToMainMenu(MenuItem i_MenuItem)
        {
            SubMenuItem.AddItem(i_MenuItem);
        }

        public void Show()
        {
            Console.Clear();
            SubMenuItem.ExecuteMenuOption();
        }
    }
}
