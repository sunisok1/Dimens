using Core.Entities;

namespace Core
{
    public class DamageInfo
    {
        public enum DamageType
        {
            Normal,
            Thorns,
            HpLoss
        }

        public AbstractEntity owner;
        public string name;
        public DamageType type;
        public int num;

        public DamageInfo(AbstractEntity damageSource, int num, DamageType type = DamageType.Normal)
        {
            owner = damageSource;
            this.type = type;
            this.num = num;
        }
    }
}