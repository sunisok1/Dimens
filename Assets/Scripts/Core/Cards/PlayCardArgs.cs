using System;
using Classes;
using Classes.Entities;

namespace Core.Cards
{
    public class PlayCardArgs : EventArgs
    {
        public AbstractCard card;
        public ITarget target;
    }
}