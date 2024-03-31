using System.Collections.Generic;
using Core;

namespace Game.GameCommand
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