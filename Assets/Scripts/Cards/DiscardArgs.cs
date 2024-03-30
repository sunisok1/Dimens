using System;
using Classes;

namespace Cards
{
    internal class DiscardArgs : EventArgs
    {
        public AbstractCard card;
    }
}