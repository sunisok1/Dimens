using Classes;
using Classes.Entities.Controller;

namespace Core.GameCommand.Commands
{
    public class DamageCommand : ICommand
    {
        private readonly IHealthController target;
        private readonly DamageInfo damageInfo;

        public DamageCommand(IHealthController target, DamageInfo damageInfo)
        {
            this.target = target;
            this.damageInfo = damageInfo;
        }

        public void Execute()
        {
            target.TakeDamage(damageInfo);
        }
    }
}