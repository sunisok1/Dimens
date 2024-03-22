using System;

namespace Core
{
    public class PlayCardArgs : EventArgs
    {
        public AbstractCard card;
        public ITarget target;
    }
}