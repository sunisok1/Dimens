namespace Core.System
{
    public interface ICommand
    {
        void Execute();
    }

    public class AttackCommand : ICommand
    {
        private Entity attacker;
        private Entity target;

        public AttackCommand(Entity attacker, Entity target)
        {
            this.attacker = attacker;
            this.target = target;
        }

        public void Execute()
        {
            // 实现攻击逻辑
        }
    }
}