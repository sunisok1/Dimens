using System;
using Classes;
using Classes.Core;

namespace Cards
{
    internal class CardDrawArgs : EventArgs
    {
        public AbstractCard card;
    }
}