using System;
using Assignment.Controllers;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            new InitialiseDatabaseController().Execute();

            Controller_Factory factory = new Controller_Factory();

            factory.createController(IController.INITIALISE_DATABASE).Execute();

            DisplayMenu();

            int menuChoice = GetUserChoice();

            while(menuChoice != IController.EXIT)
            {
                foreach (string line in factory.createController(menuChoice).Execute())
                {
                    Console.WriteLine(line);
                }

                DisplayMenu();
                menuChoice = GetUserChoice();
            }
        }

        private static int GetUserChoice()
        {
            int option = ConsoleReader.ReadInteger("\nOption");
            while (option < 1 || option > 8)
            {
                Console.WriteLine("\nChoice not recognised, Please enter again");
                option = ConsoleReader.ReadInteger("\nOption");
            }
            Console.WriteLine(option);
            return option;
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("\n{0}. Add item to stock", IController.ADD_ITEM_TO_STOCK);
            Console.WriteLine("{0}. Add quantity to item", IController.ADD_QUANTITY_TO_ITEM);
            Console.WriteLine("{0}. Take quantity from item", IController.TAKE_QUANTITY_FROM_ITEM);
            Console.WriteLine("{0}. View inventory report", IController.VIEW_INVENTORY_REPORT);
            Console.WriteLine("{0}. View financial report", IController.VIEW_FINANCIAL_REPORT);
            Console.WriteLine("{0}. View transaction log", IController.VIEW_TRANSACTION_LOG);
            Console.WriteLine("{0}. View personal usage report", IController.VIEW_PERSONAL_USAGE_REPORT);
            Console.WriteLine("{0}. Exit", IController.EXIT);
        }
    }
}
