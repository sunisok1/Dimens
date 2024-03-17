using System.Collections;

namespace Core.Action
{
    public class DamageAction : AbstractGameAction
    {
        private readonly DamageInfo info;

        public DamageAction(ITarget target, DamageInfo info, AttackEffect effect = AttackEffect.None) : base(info.owner, target, info.num)
        {
            this.info = info;
            this.actionType = ActionType.Damage;
            this.attackEffect = effect;
            this.duration = 0.1F;
        }

        public override IEnumerator Execute()
        {
            this.target.Damage(this.info);
            yield break;
        }
    }
}