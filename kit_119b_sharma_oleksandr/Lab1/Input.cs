using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetLab1
{
    class Input
    {
        private static string _errorMessage = "Invalid input. Check and try again";

        public static string EnterName(string fieldName)
        {
            Console.WriteLine("Enter " + fieldName + ":");
            string name = Console.ReadLine();
            while (!Validator.ValidateName(name))
            {
                Console.WriteLine(_errorMessage);
                name = Console.ReadLine();
            }
            return name;
        }

        public static string EnterUniInfo(string fieldName)
        {
            Console.WriteLine("Enter " + fieldName + ":");
            string sentence = Console.ReadLine();
            while (!Validator.ValidateSentence(sentence))
            {
                Console.WriteLine(_errorMessage);
                sentence = Console.ReadLine();
            }
            return sentence;
        }

        public static string EnterString(string fieldName)
        {
            Console.WriteLine("Enter " + fieldName + ":");
            string str = Console.ReadLine();
            return str;
        }

        public static int EnterPercents(string fieldName)
        {
            Console.WriteLine("Enter " + fieldName + ":");
            while (true)
            {
                try
                {
                    int value = Convert.ToInt32(Console.ReadLine());
                    if (Validator.ValidateIntByRange(0, 100, value))
                    {
                        return value;
                    }
                    continue;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static int EnterInt(string fieldName)
        {
            Console.WriteLine("Enter " + fieldName + ":");
            while (true)
            {
                try
                {
                    int value = Convert.ToInt32(Console.ReadLine());
                    return value;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static DateTime EnterDate(String fieldName)
        {
            Console.WriteLine("Enter " + fieldName + ":");
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter year:");
                    int year = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter month:");
                    int month = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter day:");
                    int day = Convert.ToInt32(Console.ReadLine());
                    return new DateTime(year, month, day);
                }
                catch (Exception e)
                {
                    Console.WriteLine("An exception occured while date input:" + e.Message);
                }
            }
        }

    }
}
