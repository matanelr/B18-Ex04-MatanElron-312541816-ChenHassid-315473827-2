using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class SubMenu : MenuItem
    {
        private const string k_MenuPartition = "***************************";
        private readonly int k_BackOption;
        private List<MenuItem> m_ListOfMenuItems;

        public SubMenu(string i_Title)
        {
            this.m_ListOfMenuItems = new List<MenuItem>();
            Title = i_Title;
            k_BackOption = 0;
            addBackItem();
        }

        public List<MenuItem> ListOfMenuItems
        {
            get
            {
                return m_ListOfMenuItems;
            }

            set
            {
                m_ListOfMenuItems = value;
            }
        }

        public int BackOption
        {
            get { return k_BackOption; }
        }

        public string MenuPartition
        {
            get
            {
                return k_MenuPartition;
            }
        }

        private void addBackItem()
        {
            ExecutableItem backItem = new ExecutableItem();
            backItem.Title = "Back";
            backItem.MenuItemOptionNumber = k_BackOption;
            ListOfMenuItems.Add(backItem);
        }

        public void AddItem(MenuItem i_NewItem)
        {
            ListOfMenuItems.Add(i_NewItem);
            i_NewItem.MenuItemOptionNumber = ListOfMenuItems.Count - 1;
        }

        internal override void ExecuteMenuOption()
        {
            int inputOptionNumber = int.MinValue;

            if (ListOfMenuItems.Count == 0)
            {
                Console.WriteLine("Can't show this item. The menu items list is enpty.");
            }
            else
            {
                Console.Clear();
                while (inputOptionNumber != BackOption)
                {
                    printSubMenu();
                    inputOptionNumber = getValidInputOption();
                    MovetoNextChosenOption(inputOptionNumber);
                }
            }
        }

        private void printSubMenu()
        {
            string exitOrBackString = string.Empty;

            if (MenuItemOptionNumber == 0)
            {
                exitOrBackString = "Exit";
            }
            else
            {
                exitOrBackString = "Back";
            }

            Console.WriteLine(string.Format("{0}{1}{2}{1}", Title, Environment.NewLine, MenuPartition));

            foreach (MenuItem currentMenuItem in ListOfMenuItems)
            {
                if (currentMenuItem.MenuItemOptionNumber != 0)
                {
                    Console.WriteLine(string.Format("{0}: {1}", currentMenuItem.MenuItemOptionNumber, currentMenuItem.Title));
                }
            }

            Console.WriteLine(string.Format("0: {0} {1}", exitOrBackString, Environment.NewLine));
            Console.WriteLine(string.Format("{0}Please choose one of the options: {1}/{2} or 0 to {3}", Environment.NewLine, 1, ListOfMenuItems.Count - 1, exitOrBackString));
        }

        private int getValidInputOption()
        {
            bool isValidInput = false;
            string userInputString = string.Empty;
            int userInputNumber = 0;

            while (!isValidInput)
            {
                userInputString = Console.ReadLine();
                if (!int.TryParse(userInputString, out userInputNumber))
                {
                    Console.WriteLine("This input format is invalid. Please try again.");
                }
                else
                {
                    if (userInputNumber < 0 || userInputNumber > ListOfMenuItems.Count - 1)
                    {
                        Console.WriteLine("This number option is not in the valid range. Please try again.");
                    }
                    else
                    {
                        isValidInput = true;
                    }
                }
            }

            return userInputNumber;
        }

        private void MovetoNextChosenOption(int i_InputOptionNumber)
        {
            Console.Clear();
            if (i_InputOptionNumber != BackOption)
            {
                ListOfMenuItems[i_InputOptionNumber].ExecuteMenuOption();
            }
        }
    }
}
