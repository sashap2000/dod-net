using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DotNetLab1
{
    class Validator
    {
        private static string _namePattern = @"^(?<firstchar>(?=[A-Za-z]))((?<alphachars>[A-Za-z])|(?<specialchars>[A-Za-z]['-](?=[A-Za-z]))|(?<spaces> (?=[A-Za-z])))*$";
        private static string _sentencePattern = @"\b[^\d\W]+\b";

        public static bool ValidateName(string name)
        {
            return Regex.IsMatch(name.Trim(), _namePattern, RegexOptions.IgnoreCase);
        }

        public static bool ValidateSentence(string sentence)
        {
            return Regex.IsMatch(sentence.Trim(), _sentencePattern, RegexOptions.IgnoreCase);
        }

        public static bool ValidateIntByRange(int min, int max, int value)
        {
            return value >= min && value <= max;
        }                                                                                                              


    }
}

