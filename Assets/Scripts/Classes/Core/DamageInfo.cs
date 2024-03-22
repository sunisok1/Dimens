
    using Core;

    public class DamageInfo
    {
        public enum DamageType
        {
            Normal,
            Thorns,
            HpLoss
        }

        public IUser owner;
        public string name;
        public DamageType type;
        public int num;

        public DamageInfo(IUser damageSource, int num, DamageType type = DamageType.Normal)
        {
            this.owner = damageSource;
            this.type = type;
            this.num = num;
        }
    }
