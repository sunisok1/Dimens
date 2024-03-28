using Common;

namespace Core.Powers.Model
{
    public class BarricadePower : AbstractPower
    {
        public const string ID = "Barricade";
        private static  PowerStrings powerStrings = LocalizedStrings.GetPowerStrings("Barricade");

        public BarricadePower(IPowerCapable owner) : base(ID, powerStrings.NAME, "barricade", powerStrings.DESCRIPTIONS)
        {
            this.owner = owner;
            this.amount = -1;
        }
    }
}