using System;
using Task_1_1.Infrastructure;

namespace Task_1_1.Errors
{
    class ErrorGenerator : IErrorGenerator
    {
        private static readonly Random random = new Random();

        public void ThrowRandomExceptionWithProbabilityOneThird()
        {
            int randomNumber = random.Next(3);
            if (randomNumber == 0)
                throw new RandomException("A randomly error has occurred.");
        }
    }
}