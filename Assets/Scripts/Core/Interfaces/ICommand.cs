using System;

namespace Core
{
    public abstract class Command
    {
        private readonly Action action;

        protected Command(Action action)
        {
            this.action = action;
        }

        public void Execute() => action();
    }
}