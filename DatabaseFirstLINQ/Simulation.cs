using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseFirstLINQ
{
    public class Simulation
    {

        public static void RunSimulation()
        {
            bool Check = UserInterface.DisplayWelcome();
            if (Check)
            {
                SimulationMenu();
            }
            else
            {
                // return - just exit
            }
        }

        public static void SimulationMenu()
        {
            bool WillProceed = true;
            while (WillProceed)
            {
                int UserOption = UserInterface.SimulationMainMenu();

                if (UserOption == 1)
                {
                    // Execute Menu Option 1
                    UserInterface.OutputText("Menu Option 1 Chosen");
                }
                else if (UserOption == 2)
                {
                    // Execute Menu Option 2
                    UserInterface.OutputText("Menu Option 2 Chosen");
                }
                else if (UserOption == 3)
                {
                    // Execute Menu Option 3
                    UserInterface.OutputText("Menu Option 3 Chosen");
                }
                else if (UserOption == 4)
                {
                    // Execute Menu Option 4
                    UserInterface.OutputText("Menu Option 4 Chosen");
                }
                else if (UserOption == 5)
                {
                    UserInterface.OutputText("Menu Option 5 Chosen");
                    UserInterface.OutputText("Goodbye.");
                    // return - just exit
                }
                else
                {
                    WillProceed = false;
                }
            }
        }
    }

}
