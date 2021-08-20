using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CollatzConjecture
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Collatz Conjecture";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(GetDescription());
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();

            while (true)
            {
                Console.Write("Enter number: ");
                string input = Console.ReadLine().Trim();

                if (input.ToUpper() == "EXIT")
                    break;

                try
                {
                    BigInteger num = BigInteger.Parse(input);
                    uint generations = 0;

                    if (num <= 0)
                        throw new OverflowException();

                    do
                    {
                        if (num.IsEven)
                            num = num / 2;
                        else
                            num = num * 3 + 1;

                        generations++;

                        Console.ForegroundColor = num.IsEven ? ConsoleColor.Green : ConsoleColor.Red;
                        Console.WriteLine(num);
                        //Console.ResetColor();
                    }
                    while (num > 1);

                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine($"'{generations}' generations passed.");
                    Console.WriteLine();
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Too big or small value.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine();
            }
        }

        static string GetDescription()
        {
            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("ReadMe.txt"));

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
