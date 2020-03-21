// Dragon6 Tools Copyright 2020 DragonFruit Network. Licensed under the MIT License

using System;
using System.Collections.Generic;
using DragonFruit.Six.Tools.Data;
using DragonFruit.Six.Tools.Helpers;
using Newtonsoft.Json;

namespace DragonFruit.Six.Tools
{
    internal static class Program
    {
        private static readonly IEnumerable<string> Options = new[]
        {
            "Dragon6 Tools",
            string.Empty,
            "1. Get Operator Info (JSON)",
            "2. Get Region Mappings (JSON)",
            "3. Get Region Mappings (C# Dictionary Format)",
            "4. Quit",
            string.Empty
        };

        private static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.ResetColor();

                Console.WriteLine(string.Join(Environment.NewLine, Options));
                Console.Write("Option: ");

                try
                {
                    var option = Convert.ToInt32(Console.ReadLine());

                    switch (option)
                    {
                        case 1: //json operator info
                            using (new ConsoleColour(ConsoleColor.Green))
                            {
                                Console.WriteLine("----------- OPERATOR INFO ----------");
                                Console.WriteLine(JsonConvert.SerializeObject(Operator.GetOperatorData(), Formatting.Indented));
                                Console.WriteLine("--------- END OPERATOR INFO --------");
                            }

                            break;

                        case 2: //json region info
                            using (new ConsoleColour(ConsoleColor.Cyan))
                            {
                                Console.WriteLine("----------- REGION INFO ----------");
                                Console.WriteLine(JsonConvert.SerializeObject(Region.GetRegionInfo(), Formatting.Indented));
                                Console.WriteLine("--------- END REGION INFO --------");
                            }

                            break;

                        case 3: //c# dict region info
                            using (new ConsoleColour(ConsoleColor.Red))
                            {
                                Console.WriteLine("----------- REGION INFO ----------");
                                Console.WriteLine(Region.GetRegionInfo().ToCodeDisplay());
                                Console.WriteLine("--------- END REGION INFO --------");
                            }

                            break;

                        case 4: //quit
                            Environment.Exit(0);
                            return;

                        default: //invalid option
                            throw new Exception("Please display the contents of the catch block...");
                    }

                    using (new ConsoleColour(ConsoleColor.DarkMagenta))
                        Console.WriteLine("\nPress enter to continue...");

                    Console.ReadLine();
                }
                catch
                {
                    using (new ConsoleColour(ConsoleColor.DarkRed))
                    {
                        Console.WriteLine("\nPlease enter a valid option.\nPress enter to try again...");
                        Console.ReadLine();
                    }
                }
            }
        }
    }
}
