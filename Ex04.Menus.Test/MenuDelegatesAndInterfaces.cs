using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class MenuDelegatesAndInterfaces
    {
        public class ShowTime : IExecutable
        {
            public void Execute()
            {
                showTimeOrDate("{0:HH:mm:ss tt}");
            }
        }

        public class ShowDate : IExecutable
        {
            public void Execute()
            {
                showTimeOrDate("{0:dd.MM.yyyy}");
            }
        }

        private static void showTimeOrDate(string i_DateOrTimeFormat)
        {
            DateTime currentDateTime = DateTime.Now;
            Console.WriteLine(i_DateOrTimeFormat, currentDateTime);
        }

        public class ShowVersion : IExecutable
        {
            public void Execute()
            {
                Console.WriteLine("Version: 18.2.4.0");
            }
        }

        public class CountCapitals : IExecutable
        {
            public void Execute()
            {
                int countCapitalLetters = 0;
                string userInputString = string.Empty;

                Console.WriteLine("Please enter a sentence");
                userInputString = Console.ReadLine();

                for (int i = 0; i < userInputString.Length; i++)
                {
                    if (char.IsUpper(userInputString[i]))
                    {
                        countCapitalLetters++;
                    }
                }

                Console.WriteLine(string.Format("There are {0} capital letters in your sentence", countCapitalLetters));
            }
        }
    }
}
