using System;
using System.Collections.Generic;

namespace Core
{
    public interface ICardOwner
    {
        public event Action<AbstractCard> OnDrawCard ;
        public event Action<AbstractCard> OnDiscard ;
        void Draw(int num);
        void DisCard(List<AbstractCard> cards);
        List<AbstractCard> GetCards();
    }
}