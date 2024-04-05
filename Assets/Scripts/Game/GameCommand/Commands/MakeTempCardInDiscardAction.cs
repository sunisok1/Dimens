using System;
using Core;
using Core.Card;

namespace Game.GameCommand.Commands
{
    public class MakeTempCardInDiscardAction : Command
    {
        public MakeTempCardInDiscardAction(AbstractCard card, int i) : base(() => { throw new NotImplementedException(); })
        {
        }
    }
}