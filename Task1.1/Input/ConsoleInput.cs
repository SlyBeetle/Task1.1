using System;
using Task_1_1.Infrastructure;

namespace Task_1_1.Input
{
    class ConsoleInput : IInput
    {
        public string GetString(byte stringNumber)
        {
            Console.WriteLine($"Input string {stringNumber}:");
            return Console.ReadLine();
        }
    }
}