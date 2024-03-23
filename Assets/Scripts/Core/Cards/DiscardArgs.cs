using System;
using Classes;

namespace Core.Cards
{
    public class DiscardArgs : EventArgs
    {
        public AbstractCard card;
    }
}