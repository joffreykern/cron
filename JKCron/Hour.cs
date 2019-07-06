﻿using System.Linq;

namespace JKCron
{
    public class Hour
    {
        public static string Parse(string input)
        {
            if (input == "*")
            {
                return string.Join(' ', Enumerable.Range(0, 24));
            }

            return input;
        }
    }
}