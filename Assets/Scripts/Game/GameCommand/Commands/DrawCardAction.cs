using Core;

namespace Game.GameCommand.Commands
{
    public class DrawCardAction : Command
    {
        public DrawCardAction(ITarget target, int amount) : base(() => target.Draw(amount))
        {
        }
    }
}