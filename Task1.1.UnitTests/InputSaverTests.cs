using NUnit.Framework;
using Moq;
using Task_1_1.Infrastructure;
using Task_1_1.Consts;
using Task_1_1.Input;
using System.Threading.Tasks;

[TestFixture]
public class InputSaverTests
{
    private Mock<IErrorGenerator> _moqErrorGenerator;
    private Mock<IInput> _moqInput;

    [SetUp]
    public void Setup()
    {
        _moqErrorGenerator = new Mock<IErrorGenerator>();
        _moqInput = new Mock<IInput>();
    }

    [Test]
    public async Task VerifyThrowRandomExceptionWithProbabilityOneThirdAsyncAndGetString()
    {
        IInputSaver[] inputSavers = new IInputSaver[TaskConsts.STRING_QUANTITY]
        {
            new FirstInputSaver(),
            new SecondInputSaver(),
            new ThirdInputSaver()
        };

        Task[] tasks = new Task[TaskConsts.STRING_QUANTITY];
        for (int i = 0; i < TaskConsts.STRING_QUANTITY; i++)
            tasks[i] = inputSavers[i].InputAndWriteStringAsync(_moqInput.Object, _moqErrorGenerator.Object);
        var allTasks = Task.WhenAll(tasks);
        await allTasks;

        _moqErrorGenerator.Verify(m => m.ThrowRandomExceptionWithProbabilityOneThird(), Times.Exactly(3));
        _moqInput.Verify(m => m.GetString(1), Times.Once);
        _moqInput.Verify(m => m.GetString(2), Times.Once);
        _moqInput.Verify(m => m.GetString(3), Times.Once);
    }
}