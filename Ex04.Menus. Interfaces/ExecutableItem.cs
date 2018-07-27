using System;

namespace Ex04.Menus.Interfaces
{
    public class ExecutableItem : MenuItem
    {
        private IExecutable m_Executable;

        public ExecutableItem()
        {
            m_Executable = null;
        }

        public IExecutable Executable
        {
            get
            {
                return m_Executable;
            }

            set
            {
                m_Executable = value;
            }
        }

        public ExecutableItem(string i_Title, IExecutable i_Executable)
        {
            Title = i_Title;
            m_Executable = i_Executable;
        }

        internal override void ExecuteMenuOption()
        {
            if (Executable == null)
            {
                Console.WriteLine("The Executable item is not initialized.");
            }
            else
            {
                Executable.Execute();
                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}
