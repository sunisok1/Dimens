using Core;

namespace Game.GameCommand.Commands
{
    public class DamageCommand : Command
    {
        public DamageCommand(ITarget target, DamageInfo damageInfo) : base(() => target.TakeDamage(damageInfo))
        {
        }
    }
}