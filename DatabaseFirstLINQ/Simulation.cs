using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DatabaseFirstLINQ.Models;
using System.Collections.Generic;

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
            Shopping customer = new Shopping();

           if (customer != null)
            {
                bool WillProceed = true;
                while (WillProceed)
                {
                    int UserOption = UserInterface.SimulationMainMenu();

                    if (UserOption == 1)
                    {
                        // Execute Menu Option 1
                        UserInterface.OutputText("Menu Option 1 Chosen");
                        customer.ViewAllProducts();

                    }
                    else if (UserOption == 2)
                    {
                        // Execute Menu Option 2
                        UserInterface.OutputText("Menu Option 2 Chosen");
                        customer.AddProductsToCart();
                    }
                    else if (UserOption == 3)
                    {
                        // Execute Menu Option 3
                        UserInterface.OutputText("Menu Option 3 Chosen");
                        customer.ViewShoppingCart();
                    }
                    else if (UserOption == 4)
                    {
                        // Execute Menu Option 4
                        UserInterface.OutputText("Menu Option 4 Chosen");
                        customer.RemoveProducts();
                    }
                    else if (UserOption == 5)
                    {
                        UserInterface.OutputText("Menu Option 5 Chosen");
                        UserInterface.OutputText("Goodbye.");
                        break;
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

}
