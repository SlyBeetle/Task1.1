using System;
using System.IO;
using System.Threading.Tasks;
using Task_1_1.Infrastructure;

namespace Task_1_1.Input
{
    public abstract class InputSaver : IInputSaver
    {
        protected static byte stringNumber = 0;
        protected abstract string FileName { get; }

        public async Task InputAndWriteStringAsync(IInput input, IErrorGenerator errorGenerator)
        {
            stringNumber++;
            string inputString = input.GetString(stringNumber);
            errorGenerator.ThrowRandomExceptionWithProbabilityOneThird();
            using (StreamWriter streamWriter = new StreamWriter(Environment.CurrentDirectory + "\\" + FileName))
            {
                await streamWriter.WriteAsync(inputString);
            }
        }
    }
}