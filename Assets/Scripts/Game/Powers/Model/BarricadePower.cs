using Common;
using Core;

namespace Game.Powers.Model
{
    public class BarricadePower : AbstractPower
    {
        private const string ID = "Barricade";
        private static readonly PowerStrings powerStrings = LocalizedStrings.GetPowerStrings("Barricade");

        public BarricadePower(ITarget owner) : base(ID, powerStrings.NAME, "barricade", powerStrings.DESCRIPTIONS)
        {
            this.owner = owner;
            this.amount = -1;
        }
    }
}