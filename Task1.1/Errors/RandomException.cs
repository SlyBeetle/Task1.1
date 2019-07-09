using System;

namespace Task_1_1.Errors
{
    class RandomException : Exception
    {
        public RandomException(string message)
            : base(message)
        { }
    }
}
