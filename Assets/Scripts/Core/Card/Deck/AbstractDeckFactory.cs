using UnityEngine;

namespace Core.Card.Deck
{
    public abstract class AbstractDeckFactory : MonoBehaviour
    {
        public abstract AbstractDeck CreateInstance();
    }
}