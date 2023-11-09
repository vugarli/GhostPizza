

using GhostPizza.UI.ExceptionRelated;

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

        public static int PromptAndTryGetPositiveInt(string prompt)
        {
            int input = 0;
            do
            {
                input = Convert.ToInt32(PromptAndGetNonEmptyString(prompt));
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
            (T[] commands, Action printBuffer, string header = "") where T : Enum
        {
            int currentCmdIndex = 0;
            do
            {
                Console.Clear();
                printBuffer.Invoke();

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


        public static void DisplayProductsAndGetBasketFromConsole
            (InputProduct[] elements, Action printBuffer, string dialogPrompt, string header = "")
        {
            int currentElementIndex = 0;
            do
            {
                Console.Clear();
                var currentTotal = elements.Where(p => p.IsAddedToBasket).Select(p => p.Price * p.Amount).Sum();
                printBuffer.Invoke();
                Console.WriteLine("Current total: " + currentTotal);
                ConsoleHelpers.PrintWarning("Press B to exit menu with current basket!\n");
                ConsoleHelpers.PrintWarning(elements[currentElementIndex].IsAddedToBasket ? "Press X to remove item":"Press enter to add item to basket");

                int colIndx=0;
                int rowIndx=0;
                if (!string.IsNullOrEmpty(header))
                    ConsoleHelpers.PrintWarning(header + ": ");

                for (int i = 0; i < elements.Length; i++)
                {
                    if (i == currentElementIndex)
                    {
                        colIndx = Console.CursorLeft;
                        rowIndx = Console.CursorTop;
                        ConsoleHelpers.InlineSelectionCursor();
                    }
                    else
                        Console.Write("  ");

                    var itemStatusMessage = (elements[i].Amount != 0 ? $" {elements[i].Amount}x Added to basket" : "");
                    Console.WriteLine(elements[i] + itemStatusMessage );
                }
                

                var keyPress = Console.ReadKey().Key;

                if (keyPress == ConsoleKey.UpArrow)
                {
                    currentElementIndex = currentElementIndex - 1 < 0 ? 0 : currentElementIndex - 1;
                }

                if (keyPress == ConsoleKey.DownArrow)
                {
                    currentElementIndex = currentElementIndex + 1 > elements.Length - 1 ? elements.Length - 1 : currentElementIndex + 1;
                }

                if (keyPress == ConsoleKey.B)
                    return;

                if(!elements[currentElementIndex].IsAddedToBasket)
                {
                    if (keyPress == ConsoleKey.Enter)
                    {
                        colIndx += elements[currentElementIndex].ToString().Length + 6;
                        Console.SetCursorPosition(colIndx,rowIndx);
                        ConsoleHelpers.InlineWarning(dialogPrompt);
                        Console.SetCursorPosition(colIndx+dialogPrompt.Length+5,rowIndx);
                        int amount = PromptAndTryGetPositiveInt("");
                        colIndx = 0;
                        elements[currentElementIndex].Amount = amount;
                        elements[currentElementIndex].IsAddedToBasket = true;    
                    }
                }

                if (keyPress == ConsoleKey.X)
                {
                    elements[currentElementIndex].Amount = 0;
                    elements[currentElementIndex].IsAddedToBasket = false;
                }

            } while (true);
        }

    }
}
