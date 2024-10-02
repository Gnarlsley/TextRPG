namespace Utilities
{
    class Utility
    {
       public static string ReadInputWithHistory(List<string> history, ref int historyIndex)
        {
            string input = string.Empty;
            ConsoleKeyInfo keyInfo;

            historyIndex = -1;

            while (true)
            {
                keyInfo = Console.ReadKey(intercept: true);

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    return input;
                }
                else if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (input.Length > 0)
                    {
                        input = input[0..^1];
                        Console.Write("\b \b");
                    }
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    //Search up history
                    if (history.Count > 0 && historyIndex < history.Count - 1)
                    {
                        historyIndex++;
                        input = history[history.Count - 1 - historyIndex];
                        Console.Write($"\r{new string(' ', Console.WindowWidth)}\r");
                        Console.Write(input);
                    }
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    //Search down history
                    if (historyIndex > 0)
                    {
                        historyIndex--;
                        input = history[history.Count -1 - historyIndex];
                        Console.Write($"\r{new string(' ', Console.WindowWidth)}\r");
                        Console.Write(input);
                    }
                    else if (historyIndex == 0)
                    {
                        historyIndex = -1;
                        input = string.Empty;
                        Console.Write($"\r{new string(' ', Console.WindowWidth)}\r");
                    }
                }
                else
                {
                    input += keyInfo.KeyChar;
                    Console.Write(keyInfo.KeyChar);
                }
            }
        }
    }
}