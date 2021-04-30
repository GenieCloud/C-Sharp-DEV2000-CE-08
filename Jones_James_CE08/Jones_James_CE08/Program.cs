using System;
using System.Collections.Generic;

namespace Jones_James_CE08
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * James M. Jones
             * 04/24/2021
             * DEV2000-O 02: Introduction to Development II
             * 3.4 Code Exercise 08: Menus
             */

            //Problem #1: Dramatic Discounts

            //Greet the user and explain they will have 3 options.
            Console.WriteLine("\r\nHello! You can choose to run either of my 2 programs or exit the program.");

            //Next, I want to create a loop for the menu options to continue as long as the user wants to do so.
            //I will need a menu variable that is a boolean and has a value of 'true'.
            bool keepMenuGoing = true;

            while (keepMenuGoing)
            {
                //Use a while loop to contain our menu options. I decided to use a for loop to loop through two string arrays and display the menu options.
                //This uses fewer lines of code and is easier to read. I can wrap this in a conditional statement as well.
                //It would also be easier to add more options to this menu in the future using this approach.
                string[] menuOptionNumbers = {"1", "2", "3" };

                string[] menuOptions = { "Dramatic Discounts", "Check Please", "Exit Program" };
                //If the arrays lengths are equal I can loop through their values with a single for loop.
                if (menuOptionNumbers.Length == menuOptions.Length)
                {
                    //use a for loop to loop through the array and display the menu option for each number in that array.
                    for (int i = 0; i < menuOptions.Length; i++)
                    {
                        //Output the menu option number and program titles.
                        Console.WriteLine("\r\n({0}) {1}", menuOptionNumbers[i], menuOptions[i]);
                    }
                }

                //Prompt the user to choose an option from the menu.
                Console.WriteLine("\r\nPlease type in the number of the command you want to run:");

                //listen for the user's input and capture the response.
                string menuChoice = Console.ReadLine();

                //Validate that the user can only select numbers: 1, 2 and 3.
                while (menuChoice != "1" && menuChoice != "2" && menuChoice != "3" )
                {
                    //Tell the user the error.
                    Console.WriteLine("\r\nPlease only type in a valid choice. 1, 2 or 3.");

                    //Restate the question.
                    Console.WriteLine("\r\nPlease type in only the number of what you would like to do?");

                    //Re-prompt the user.
                    menuChoice = Console.ReadLine();
                }

                //Use a conditional block to run the selected code.
                if (menuChoice == "1")
                {
                    //Function Call for Dramatic Discounts(MenuOption1).
                    MenuOption1();
                }
                else if (menuChoice == "2")
                {
                    //Function Call for Check Please(MenuOption2).
                    MenuOption2();
                }
                else if (menuChoice == "3")
                {
                    //Exit the program.
                    //Exit the program.
                    Console.WriteLine("\r\nThank you for testing out my program!");
                    Console.WriteLine("Have a great day!");

                    //Change the bool variable to stop the loop.
                    keepMenuGoing = false;
                }

                //Clean up the terminal/console
                Console.WriteLine("\r\nPress ENTER to continue.");
                Console.ReadLine();
                Console.Clear();
            }
        }

        //Create a function for MenuOption1.
        //This function will hold the code for Dramatic Discounts. Use returnType of void since we are creating a menu option and it will not return a specific value.
        public static void MenuOption1()
        {
            //Create an array variable for the discount values.
            decimal[] discounts = { 5m, 10m, 15m, 20m, 25m, 30m };

            Console.WriteLine("\r\nHello, today I will give prices based some common discount percentages.\r\nWhat is the price of the item? ");
            //Listen for the user's input
            string priceString = Console.ReadLine();

            //Convert the input to a decimal value and validate the response to only allow a decimal value.
            decimal price;

            //Validation loop
            while (!decimal.TryParse(priceString, out price) || price < 0)
            {
                //Tell the error
                Console.WriteLine("\r\nPlease only enter a positive decimal value.");
                //Re-state the question.
                Console.WriteLine("\r\nWhat is price of the item?");
                //Re-prompt the user.
                priceString = Console.ReadLine();
            }
            //This for loop cycles through the discount[] indexes.
            for (int i = 0; i < discounts.Length; i++)
            {   //I call my custom function DiscountCalc(); and the original price input and the discounts[] index to that custom DiscountCalc function.
                decimal discountPrice = DiscountCalc(price, discounts[i]);
                //Last, I want to print the final results to the console to display the original price input, the discount that will be applied and the new discounted price.
                Console.Write("\r\n{0} with a {1}% discount is {2}",price.ToString("c"),discounts[i], discountPrice.ToString("c"));
            }
        }

        //Create a function for MenuOption2.
        //This function will hold the code for Check Please. Use returnType of void since we are creating a menu option.
        public static void MenuOption2()
        {
            //Greet the user and explain the program.
            Console.WriteLine("\r\nHello and welcome to the Check Please program!\r\n\r\nHere are the tables that have not paid their checks.");

            //First, create a dictionary to hold table Keys and multiple price values.
            //This will be hard-coded.
            Dictionary<string, List<decimal>> checkPlease = new Dictionary<string, List<decimal>>()
            {
                {"table1", new List<decimal>() },
                {"table2", new List<decimal>() },
                {"table3", new List<decimal>() },
            };

            //For table1, I want to add two prices to the list for that table. These should be decimal values.
            checkPlease["table1"].Add(5.50m);
            checkPlease["table1"].Add(10.50m);
            checkPlease["table1"].Add(36.99m);

            //For table2, I want to add four prices to the list for that table. These should be decimal values also.
            checkPlease["table2"].Add(76.67m);
            checkPlease["table2"].Add(3.99m);

            //For table3, I want to add six prices to the list for that table. These should be decimal
            checkPlease["table3"].Add(54.32m);
            checkPlease["table3"].Add(76.54m);
            checkPlease["table3"].Add(87.65m);
            checkPlease["table3"].Add(98.76m);

            //I want to use a foreach loop to loop through the keys in our dictionary and display the keys for the user to select a table.
            foreach (KeyValuePair<string, List<decimal>> table in checkPlease)
            {
                Console.WriteLine("\r\n" + table.Key);
            }

            //Prompt the user to select a table.
            //We will validate our dictionay keys to makes sure the chosen key exists inside of the dictionary.
            Console.WriteLine("\r\nPlease select one of the tables above by typing in the name.");

            //Listen for the user's input
            string selectTable = Console.ReadLine();

            //Create a variable to store the value.
            List<decimal> tableSelected = new List<decimal>();

            //use a while loop to try and get the value of the selected table.
            while (!checkPlease.TryGetValue(selectTable, out tableSelected))
            {
                //Tell the user the error
                Console.WriteLine("\r\nPlease only chose a table from the avaiable list.");
                //Re-state the question/instructions.
                Console.WriteLine("\r\nPlease select one of the tables above by typing in the name.");
                //Reprompt the user
                selectTable = Console.ReadLine();
            }
            //Now, I need to create a custom function called TotalForTable() to output the total for the table prices.

            //Function call TotalForTable() and output the total price for the selected table.
            decimal totalPrice = TotalForTable(tableSelected);

            //Outputs the total for the selected table.
            Console.WriteLine("\r\nThe total check for {0} is {1}.", selectTable, totalPrice.ToString("c"));

            //Prompt the user and ask how many ways they would like to split the total for the check.
            Console.WriteLine("\r\nHow many guests will be splitting this check?");

            //Listen for the user's response and validate that it can only be a positive integer.
            string numGuestsSplitString = Console.ReadLine();

            //Convert to an integer value
            int numGuestSplit;

            //Validate the input using a while loop.
            while (!int.TryParse(numGuestsSplitString, out numGuestSplit) || numGuestSplit <= 0)
            {
                //Tell the user the error.
                Console.WriteLine("\r\nPlease only type in positive whole number values.");

                //Re-state the question.
                Console.WriteLine("\r\nHow many guests will be splitting will be splitting this check?");

                //Re-prompt the user.
                numGuestsSplitString = Console.ReadLine();
            }

            decimal splitTotalPrice = totalPrice / numGuestSplit;

            Console.WriteLine("\r\nThe total bill for {0} is {1}.\r\n\r\nSplit evenly {2} ways each person will pay {3}.",selectTable, totalPrice.ToString("c"), numGuestSplit, splitTotalPrice.ToString("c"));
        }

        //I want to create another function called DiscountCalc to apply the discounts to the price input.
        //This is the custom function to be used for MenuOption1();
        public static decimal DiscountCalc(decimal price, decimal discount)
        {
            //This equation calculates the discount amount
            decimal discountPrice = price - (price * discount / 100);
            //This return variable stores the discounted price for use in the MenuOption1 function.
            return discountPrice;
        }

        //This is the custom function to be used for MenuOption2();
        public static decimal TotalForTable(List<decimal> prices)
        {   //The totalPrice variable will start at 0.
            decimal totalPrice = 0;
            //Next, I want to create a for loop to 
            for(int i = 0; i < prices.Count; i++)
            {
                totalPrice += prices[i];
            }

            //Return the value
            return totalPrice;
        }
    }
}
