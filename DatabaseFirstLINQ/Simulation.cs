using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseFirstLINQ
{
    public class Simulation
    {

        public void RunSimulation()
        {
            bool Check = UserInterface.DisplayWelcome();
            if (Check)
            {
                SimulationMenu()
            }
            else
            {
                // return - just exit
            }
        }

        public void SimulationMenu()
        {
            bool WillProceed = true;
            while (WillProceed)
            {
                int UserOption = UserInterface.SimulationMainMenu()

                if (UserOption == 1)
                {
                    // Execute Menu Option 1
                }
                else if (UserOption == 2)
                {
                    // Execute Menu Option 2
                }
                else if (UserOption == 3)
                {
                    // Execute Menu Option 3
                }
                else if (UserOption == 4)
                {
                    // Execute Menu Option 4
                }
                else if (UserOption == 5)
                {
                    //UserInterface.OutputText('Goodbye.')
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
