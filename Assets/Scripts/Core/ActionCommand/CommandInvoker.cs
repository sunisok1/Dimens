using System.Collections.Generic;

namespace Core.ActionCommand
{
    public static class CommandInvoker
    {
        private static readonly Stack<ICommand> commandHistory = new();

        public static void ExecuteCommand(ICommand command)
        {
            command.Execute();
            commandHistory.Push(command);
        }
    }
}