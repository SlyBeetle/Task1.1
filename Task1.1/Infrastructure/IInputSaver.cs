using System.Threading.Tasks;

namespace Task_1_1.Infrastructure
{
    public interface IInputSaver
    {
        Task InputAndWriteStringAsync(IInput input, IErrorGenerator errorGenerator);
    }
}