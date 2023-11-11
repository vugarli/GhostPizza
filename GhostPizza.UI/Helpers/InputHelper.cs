

using GhostPizza.Core.Models;
using GhostPizza.UI.ExceptionRelated;
using System.Runtime.CompilerServices;

namespace GhostPizza.UI.Helpers
{
    internal static class InputHelper
    {


        public static string PromptAndGetNonEmptyString(string prompt)
        {
            string input = null;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input) || input == string.Empty)
                    ConsoleHelpers.PrintError("Empty input is not allowed!");

            } while (string.IsNullOrWhiteSpace(input) || input == string.Empty);

            return input;
        }

        public static string PromptAndTryGetNonEmptyString(string prompt)
        {
            string input = null;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input) || input == string.Empty)
                    throw ExceptionHelper.InputFormatInvalidException("Empty input is not allowed!");

            } while (string.IsNullOrWhiteSpace(input) || input == string.Empty);

            return input;
        }

        public static (string mobileNumber,string address) PromptAndGetOrderInfoFromConsole()
        {
            Console.Write("Phone number: ");
            ConsoleHelpers.InlineWarning("+994 051 123 45 67");
            Console.SetCursorPosition(14,Console.CursorTop);
            var mobileNumber = Console.ReadLine();
            Validators.OrderValidators.ValidatePhoneNumber(mobileNumber);
            var address = PromptAndTryGetNonEmptyString("Address: ");
            return (mobileNumber, address);
        }

        public static int PromptAndTryGetPositiveInt(string prompt = "")
        {
            int input = 0;
            do
            {
                input = Convert.ToInt32(PromptAndTryGetNonEmptyString(prompt));
                if (input < 0)
                    throw ExceptionHelper.InputFormatInvalidException("Positive input is required!");
            } while (input < 0);

            return input;
        }

        public static int PromptAndGetPositiveRangedInt(string prompt, int maxRange)
        {
            int input = 0;
            do
            {
                input = PromptAndTryGetPositiveInt(prompt);

                if (input > maxRange)
                    ConsoleHelpers.PrintError($"Positive input with {maxRange} max value is required!");

            } while (input > maxRange);

            return input;
        }

        public static int PromptAndGetPositiveNzInt(string prompt)
        {
            int input = 0;
            do
            {
                input = Convert.ToInt32(PromptAndGetNonEmptyString(prompt));

                if (input <= 0)
                    ConsoleHelpers.PrintError("Positive non zero input is required!");

            } while (input <= 0);

            return input;
        }

        public static decimal PromptAndGetPositiveDecimal(string prompt)
        {
            decimal input = 0;
            do
            {
                input = Convert.ToDecimal(PromptAndGetNonEmptyString(prompt));

                if (input <= 0m)
                    ConsoleHelpers.PrintError("Positive non zero input is required!");

            } while (input < 0m);

            return input;
        }

        /// <summary>
        /// Prints interactive ui with commands
        /// </summary>
        /// <typeparam name="T">Command Enum type</typeparam>
        /// <param name="commands">Command Enum Array</param>
        /// <param name="printBuffer">Prints Buffer</param>
        /// <param name="header">Prompt header</param>
        /// <returns>Command index From Commands Array</returns>
        public static T DisplayAndGetCommandBySelection<T>
            (T[] commands, string header = "") where T : Enum
        {
            int currentCmdIndex = 0;
            do
            {
                Console.Clear();
                ConsoleHelpers.PrintBuffer();

                if (!string.IsNullOrEmpty(header))
                    ConsoleHelpers.PrintWarning(header + ": ");

                for (int i = 0; i < commands.Length; i++)
                {
                    if (i == currentCmdIndex)
                        ConsoleHelpers.InlineSelectionCursor();
                    else
                        Console.Write("  ");
                    Console.WriteLine(commands[i]);
                }
                var keyPress = Console.ReadKey().Key;

                if (keyPress == ConsoleKey.UpArrow)
                {
                    currentCmdIndex = currentCmdIndex - 1 < 0 ? 0 : currentCmdIndex - 1;
                }

                if (keyPress == ConsoleKey.DownArrow)
                {
                    currentCmdIndex = currentCmdIndex + 1 > commands.Length - 1 ? commands.Length - 1 : currentCmdIndex + 1;
                }

                if (keyPress == ConsoleKey.Enter)
                    return commands[currentCmdIndex];

            } while (true);
        }


        public static int DisplayAndGetElementBySelection<T>
    (List<T> commands, string header = "")
        {
            int currentCmdIndex = 0;
            do
            {
                Console.Clear();
                ConsoleHelpers.PrintBuffer();

                if (!string.IsNullOrEmpty(header))
                    ConsoleHelpers.PrintWarning(header + ": ");

                for (int i = 0; i < commands.Count; i++)
                {
                    if (i == currentCmdIndex)
                        ConsoleHelpers.InlineSelectionCursor();
                    else
                        Console.Write("  ");
                    Console.WriteLine(commands[i]);
                }
                var keyPress = Console.ReadKey().Key;

                if (keyPress == ConsoleKey.UpArrow)
                {
                    currentCmdIndex = currentCmdIndex - 1 < 0 ? 0 : currentCmdIndex - 1;
                }

                if (keyPress == ConsoleKey.DownArrow)
                {
                    currentCmdIndex = currentCmdIndex + 1 > commands.Count - 1 ? commands.Count- 1 : currentCmdIndex + 1;
                }

                if (keyPress == ConsoleKey.Enter)
                    return currentCmdIndex;

            } while (true);
        }


        public static void DisplayProductsAndGetBasketFromConsole
            (Basket basket, List<SaleProduct> saleProducts ,string dialogPrompt, string header = "")
        {
            int currentElementIndex = 0;
            do
            {
                Console.Clear();
                var currentTotal = saleProducts
                    .FindAll(p=>p.IsAddedToBasket)
                    .Sum(p => p.Pizza.Price * p.AmountInBasket);

                ConsoleHelpers.PrintBuffer();
                Console.WriteLine("Current total: " + currentTotal);
                ConsoleHelpers.PrintWarning("Press B to exit menu with current basket!\n");
                ConsoleHelpers.PrintWarning(saleProducts[currentElementIndex].IsAddedToBasket ? "Press X to remove item":"Press enter to add item to basket");

                int colIndx=0;
                int rowIndx=0;
                if (!string.IsNullOrEmpty(header))
                    ConsoleHelpers.PrintWarning(header + ": ");

                for (int i = 0; i < saleProducts.Count; i++)
                {
                    if (i == currentElementIndex)
                    {
                        colIndx = Console.CursorLeft;
                        rowIndx = Console.CursorTop;
                        ConsoleHelpers.InlineSelectionCursor();
                    }
                    else
                        Console.Write("  ");

                    var itemStatusMessage = (saleProducts[i].AmountInBasket != 0 ? $" {saleProducts[i].AmountInBasket}x Added to basket" : "");
                    Console.WriteLine(saleProducts[i].Pizza.Name+" "+saleProducts[i].Pizza.Price+"$ "+ itemStatusMessage );
                }
                

                var keyPress = Console.ReadKey().Key;

                if (keyPress == ConsoleKey.UpArrow)
                {
                    currentElementIndex = currentElementIndex - 1 < 0 ? 0 : currentElementIndex - 1;
                }

                if (keyPress == ConsoleKey.DownArrow)
                {
                    currentElementIndex = currentElementIndex + 1 > saleProducts.Count - 1 ? saleProducts.Count - 1 : currentElementIndex + 1;
                }

                if (keyPress == ConsoleKey.B)
                {
                    basket.Products = (saleProducts.FindAll(p=>p.IsAddedToBasket).Select(p=>new BasketElement(p.Pizza,p.AmountInBasket)).ToList());
                    return;
                }

                if(!saleProducts[currentElementIndex].IsAddedToBasket)
                {
                    if (keyPress == ConsoleKey.Enter)
                    {
                        colIndx += saleProducts[currentElementIndex].Pizza.Name.Length + 10;
                        Console.SetCursorPosition(colIndx,rowIndx);
                        ConsoleHelpers.InlineWarning(dialogPrompt);
                        Console.SetCursorPosition(colIndx+dialogPrompt.Length+3,rowIndx);
                        int amount = PromptAndTryGetPositiveInt();
                        colIndx = 0;
                        saleProducts[currentElementIndex].AmountInBasket = amount;
                        saleProducts[currentElementIndex].IsAddedToBasket = true;    
                    }
                }

                if (keyPress == ConsoleKey.X)
                {
                    saleProducts[currentElementIndex].AmountInBasket = 0;
                    saleProducts[currentElementIndex].IsAddedToBasket = false;
                }

            } while (true);
        }

    }
}
