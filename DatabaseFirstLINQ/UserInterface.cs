using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseFirstLINQ
{
    public class UserInterface
    {

        public static int SimulationMainMenu()
        {
            bool ValidateUserSelectionStatus = false;
            int ValidateUserSelectionOption = 0;

            while (!ValidateUserSelectionStatus)
            {
                Console.WriteLine("\n\t\t-Shopping Cart Processing-");
                Console.WriteLine("\tPress -1- to List all products");
                Console.WriteLine("\tPress -2- to Add a product to your cart");
                Console.WriteLine("\tPress -3- to View your shopping cart");
                Console.WriteLine("\tPress -4- to Remove a product from your cart");
                Console.WriteLine("\tPress -5- to Exit");

                int UserInput = Console.Read();

                ValidateUserSelectionStatus = ValidateMainMenu(UserInput);
                if (ValidateUserSelectionStatus) { ValidateUserSelectionOption = UserInput};
            }

            return ValidateUserSelectionOption;

        }

        public bool ValidateMainMenu(int UserInput)
        {
            if (UserInput > 0 && UserInput < 6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool DisplayWelcome()
        {
            Console.Write("\nWelcome to the Shopping Cart manager. \n");

            bool UserResponse = BoolPrompt("Would you like to order products today? (y/n): ")
            if (UserResponse)
                { return true; }
            else
            {
                Console.WriteLine("Please sign off and conserve your precious technological resources.");
                return false;
            }
        }

        public void OutputText(string text)
        {
            Console.WriteLine(text);
        }

        public bool BoolPrompt(string text)
        {
            Console.WriteLine(text);
            string UserInput = Console.ReadLine().ToLower();

            switch (UserInput)
            {
                case "y":
                    {
                        return true;
                    }
                case "yes":
                    {
                        return true;
                    }
                default:
                    {
                        return false;
                    }
            }
        }
    }
}
