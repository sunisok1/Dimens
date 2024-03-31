using System;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Game.Entities.Controller
{
    public partial class PlayerController : ICardOwner
    {
        public event Action<AbstractCard> OnDrawCard;
        public event Action<AbstractCard> OnDiscard;

        public void Draw(int num)
        {
            Debug.Log("test draw");
        }

        public void DisCard(List<AbstractCard> cards)
        {
            throw new NotImplementedException();
        }

        public List<AbstractCard> GetCards()
        {
            throw new NotImplementedException();
        }
    }
}