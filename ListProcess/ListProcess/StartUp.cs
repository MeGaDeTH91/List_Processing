namespace ListProcess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private const string InvalidCommandParamters = "Error: invalid command parameters";
        private const string InvalidCommand = "Error: invalid command";
        private const string InvalidIndex = "Error: Invalid index {0}";

        public static void Main()
        {
            List<string> initial = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            Console.WriteLine(string.Join(" ", initial));

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] commArgs = input
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string command = commArgs[0];

                if (command == "END")
                {
                    Console.WriteLine(InvalidCommand);
                    continue;
                }

                switch (command.ToLower())
                {
                    case "append":
                        if (commArgs.Length == 2)
                        {
                            string stringToAppend = commArgs[1];

                            initial.Add(stringToAppend);
                            Console.WriteLine(string.Join(" ", initial));
                        }
                        else
                        {
                            Console.WriteLine(InvalidCommandParamters);
                        }

                        break;
                    case "prepend":
                        if (commArgs.Length == 2)
                        {
                            string stringToPrepend = commArgs[1];

                            initial.Insert(0, stringToPrepend);
                            Console.WriteLine(string.Join(" ", initial));
                        }
                        else
                        {
                            Console.WriteLine(InvalidCommandParamters);
                        }

                        break;
                    case "roll":
                        if (commArgs.Length == 2)
                        {
                            if (commArgs[1] == "left")
                            {
                                string temp = initial.First();
                                initial.RemoveAt(0);
                                initial.Add(temp);
                                Console.WriteLine(string.Join(" ", initial));
                            }
                            else if (commArgs[1] == "right")
                            {
                                string temp = initial.Last();
                                initial.RemoveAt(initial.Count - 1);
                                initial.Insert(0, temp);
                                Console.WriteLine(string.Join(" ", initial));
                            }
                            else
                            {
                                Console.WriteLine(InvalidCommandParamters);
                            }
                        }
                        else
                        {
                            Console.WriteLine(InvalidCommandParamters);
                        }

                        break;
                    case "end":
                        if (commArgs.Length > 1)
                        {
                            Console.WriteLine(InvalidCommandParamters);
                        }

                        break;

                    case "reverse":
                        if (commArgs.Length == 1)
                        {
                            initial.Reverse();
                            Console.WriteLine($"{string.Join(" ", initial)}");
                        }
                        else
                        {
                            Console.WriteLine(InvalidCommandParamters);
                        }

                        break;
                    case "sort":
                        if (commArgs.Length == 1)
                        {
                            initial.Sort();
                            Console.WriteLine($"{string.Join(" ", initial)}");
                        }
                        else
                        {
                            Console.WriteLine(InvalidCommandParamters);
                        }

                        break;
                    case "count":
                        if (commArgs.Length == 2)
                        {
                            string countString = commArgs[1];

                            int count = initial.Where(x => x == countString).Count();
                            Console.WriteLine(count);
                        }
                        else
                        {
                            Console.WriteLine(InvalidCommandParamters);
                        }

                        break;
                    case "delete":
                        if (commArgs.Count() != 2)
                        {
                            Console.WriteLine(InvalidCommandParamters);
                        }
                        else
                        {
                            var isNumber = int.TryParse(commArgs[1], out int index);
                            if (!isNumber)
                            {
                                Console.WriteLine(InvalidCommandParamters);
                            }
                            else if (index >= initial.Count || index < 0)
                            {
                                Console.WriteLine(InvalidIndex, index);
                                break;
                            }
                            else
                            {
                                initial.RemoveAt(index);
                                Console.WriteLine(string.Join(" ", initial));
                            }
                        }

                        break;
                    case "insert":
                        if (commArgs.Count() != 3)
                        {
                            Console.WriteLine(InvalidCommandParamters);
                        }
                        else
                        {
                            var isNumber = int.TryParse(commArgs[1], out int index);
                            if (!isNumber)
                            {
                                Console.WriteLine(InvalidCommandParamters);
                                break;
                            }

                            var value = commArgs[2];
                            if (index >= initial.Count || index < 0)
                            {
                                Console.WriteLine(InvalidIndex, index);
                            }
                            else
                            {
                                initial.Insert(index, value);
                                Console.WriteLine(string.Join(" ", initial));
                            }
                        }

                        break;
                    default:
                        Console.WriteLine(InvalidCommand);
                        break;
                }
            }

            Console.WriteLine("Finished");
        }
    }
}
