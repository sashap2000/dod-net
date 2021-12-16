using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Sharma03
{
    class Validator
    {
        private static string _namePattern = @"^[A-ЯЁ][а-яё]+$";
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

