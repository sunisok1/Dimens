using System;
using Classes;
using Classes.Core;

namespace Cards
{
    internal class DiscardArgs : EventArgs
    {
        public AbstractCard card;
    }
}