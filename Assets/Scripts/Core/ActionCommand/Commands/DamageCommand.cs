namespace Core.ActionCommand.Commands
{
    public class DamageCommand : ICommand
    {
        private readonly ITarget target;
        private readonly DamageInfo damageInfo;

        public DamageCommand(ITarget target, DamageInfo damageInfo)
        {
            this.target = target;
            this.damageInfo = damageInfo;
        }

        public void Execute()
        {
            target.Damage(damageInfo);
        }
    }
}