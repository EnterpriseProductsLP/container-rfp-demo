﻿using System;

namespace Common.Utilities
{
    public static class ConsoleUtilities
    {
        public static void WriteLineWithColor(ConsoleColor consoleColor, object value)
        {
            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(value.ToString());
            Console.ForegroundColor = originalColor;
        }
    }
}