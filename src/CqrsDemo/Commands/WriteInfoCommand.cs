using MicroCQRS;

namespace CqrsDemo.Commands
{
    public class WriteInfoCommand : ICommand
    {
        public string Message { get; }

        public WriteInfoCommand(string message)
        {
            Message = message;
        }
    }
}
