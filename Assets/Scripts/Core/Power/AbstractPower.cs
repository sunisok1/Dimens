using UnityEngine;

namespace Core.Power
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

        public IPowerOwner owner;

        public PowerType powerType;

        public readonly string powerID;
        public readonly string name;
        public readonly string portrait;
        public readonly string[] descriptions;

        protected AbstractPower(string powerID, string name, string portrait, string[] descriptions, IPowerOwner owner, PowerType powerType = PowerType.Buff)
        {
            this.powerID = powerID;
            this.name = name;
            this.portrait = PortraitsDirectory + portrait;
            this.descriptions = descriptions;
            this.owner = owner;
            this.powerType = powerType;
        }

        public virtual void OnAdded()
        {
            Debug.Log($"{GetType()} been added.");
        }

        public virtual void OnRemoved()
        {
            Debug.Log($"{GetType()} been removed.");
        }

        public static AbstractPower operator +(AbstractPower power1, AbstractPower power2)
        {
            power1.amount += power2.amount;
            return power1;
        }
    }
}