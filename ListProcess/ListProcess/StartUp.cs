using System;
using System.Collections.Generic;
using System.Linq;

namespace ListProcess
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> initial = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] commArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = commArgs[0];

                switch (command.ToLower())
                {
                    case "append":
                        if (commArgs.Length==2)
                        {
                            string stringToAppend = commArgs[1];

                            initial.Add(stringToAppend);
                            Console.WriteLine(string.Join(" ",initial));
                        }
                        else
                        {
                            Console.WriteLine("Error: invalid command parameters");
                        }
                        break;

                    case "prepend":
                        if (commArgs.Length == 2)
                        {
                            string stringToPrepend = commArgs[1];

                            initial.Insert(0, stringToPrepend);
                            Console.WriteLine(string.Join(" ",initial));
                        }
                        else
                        {
                            Console.WriteLine("Error: invalid command parameters");
                        }
                        break;

                    case "roll":
                        if (commArgs.Length==2)
                        {
                            if (commArgs[1]=="left")
                            {
                                string temp = initial.First();
                                initial.RemoveAt(0);
                                initial.Add(temp);
                                Console.WriteLine(string.Join(" ",initial));
                            }
                            else if (commArgs[1]=="right")
                            {
                                string temp = initial.Last();
                                initial.RemoveAt(initial.Count-1);
                                initial.Insert(0,temp) ;
                                Console.WriteLine(string.Join(" ", initial));
                            }
                            else
                            {
                                Console.WriteLine("Error: invalid command");
                            }
                        }

                        else
                        {
                            Console.WriteLine("Error: invalid command parameters");
                        }

                        break;

                    case "end":
                        if(commArgs.Length > 1)
                        {
                            Console.WriteLine("Error: invalid command parameters");
                        }
                        break;

                    case "reverse":
                        if(commArgs.Length == 1)
                        {
                            initial.Reverse();
                            Console.WriteLine($"{string.Join(" ", initial)}");
                        }
                        else
                        {
                            Console.WriteLine("Error: invalid command parameters");
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
                            Console.WriteLine("Error: invalid command parameters");
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
                            Console.WriteLine("Error: invalid command parameters");
                        }
                        break;

                    default:
                        Console.WriteLine("Error: invalid command");
                        break;
                }
            }

            Console.WriteLine("Finished");
        }
    }
}
