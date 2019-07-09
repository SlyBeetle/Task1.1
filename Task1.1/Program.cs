using NLog;
using System;
using System.Threading.Tasks;
using Task_1_1.Consts;
using Task_1_1.Errors;
using Task_1_1.Infrastructure;
using Task_1_1.Input;

namespace Task_1_1
{
    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        static async Task Main(string[] args)
        {
            Task allTasks = null;

            try
            {
                IInputSaver[] inputSavers = new IInputSaver[TaskConsts.STRING_QUANTITY]
                {
                    new FirstInputSaver(),
                    new SecondInputSaver(),
                    new ThirdInputSaver()
                };
                Task[] tasks = new Task[TaskConsts.STRING_QUANTITY];
                IInput input = new ConsoleInput();
                IErrorGenerator errorGenerator = new ErrorGenerator();
                for (int i = 0; i < TaskConsts.STRING_QUANTITY; i++)
                    tasks[i] = inputSavers[i].InputAndWriteStringAsync(input, errorGenerator);
                allTasks = Task.WhenAll(tasks);
                await allTasks;
                Console.WriteLine("Success");
            }
            catch (RandomException exception)
            {
                logger.Error(exception);
                Console.WriteLine("Failure");
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}