using System.Collections.Generic;
using Core;
using UnityEditor;
using UnityEngine;

namespace Game.GameCommand
{
    public static class CommandInvoker
    {
        private static readonly List<Command> commandsRecord = new();

        private static readonly Stack<Command> commandHistory = new();

        public static void ExecuteCommand(Command command)
        {
            command.Execute();
            commandHistory.Push(command);
            commandsRecord.Add(command);
        }
#if UNITY_EDITOR
        [MenuItem("Tools/CommandInvoker/LogRecord")]
        public static void LogRecord()
        {
            foreach (Command command in commandsRecord)
            {
                Debug.Log(command);
            }
        }
#endif
    }
}