using System.Collections;

namespace Core.Action
{
    public abstract class AbstractGameAction
    {
        public enum AttackEffect
        {
            BluntLight,
            BluntHeavy,
            SlashDiagonal,
            Smash,
            SlashHeavy,
            SlashHorizontal,
            SlashVertical,
            None,
            Fire,
            Poison,
            Shield,
            Lightning
        }

        public enum ActionType
        {
            Block,
            Power,
            CardManipulation,
            Damage,
            Debuff,
            Discard,
            Draw,
            Exhaust,
            Heal,
            Energy,
            Text,
            Use,
            ClearCardQueue,
            Dialog,
            Special,
            Wait,
            Shuffle,
            ReducePower
        }

        protected static float DEFAULT_DURATION = 0.5F;
        protected float duration;
        protected float startDuration;
        public ActionType actionType;
        public bool isDone = false;
        public int amount;
        public AttackEffect attackEffect = AttackEffect.None;

        public IUser source;
        public ITarget target;


        protected AbstractGameAction(IUser source, ITarget target, int amount = 0)
        {
            this.source = source;
            this.target = target;
            this.amount = amount;
        }

        public abstract IEnumerator Execute();
    }
}