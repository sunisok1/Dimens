using Core;

namespace Game.GameCommand.Commands
{
    public class DrawCardAction : Command
    {
        public DrawCardAction(ICardOwner powerOwner, int amount) : base(() => powerOwner.Draw(amount))
        {
        }
    }
}