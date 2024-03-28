namespace Core.Powers
{
    public abstract class AbstractPower
    {
        private const string PortraitsDirectory = "Slay the Spire/powers/128/";

        public enum PowerType
        {
            Buff,
            Debuff
        }

        public int amount = -1;

        public int priority = 5;
        protected bool isTurnBased = false;

        public bool isPostActionPower = false;

        public bool canGoNegative = false;

        public IPowerCapable owner;

        public readonly string powerID;
        public readonly string name;
        public readonly string portrait;
        public readonly string[] descriptions;

        protected AbstractPower(string powerID, string name, string portrait, string[] descriptions)
        {
            this.powerID = powerID;
            this.name = name;
            this.portrait = PortraitsDirectory + portrait;
            this.descriptions = descriptions;
        }
    }
}