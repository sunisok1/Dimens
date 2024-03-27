using System;
using Classes;

namespace Core.Cards
{
    internal class DiscardArgs : EventArgs
    {
        public AbstractCard card;
    }
}