using Core;
using Core.Localization;

namespace Game.Powers.Model
{
    public class BarricadePower : AbstractPower
    {
        private const string ID = "Barricade";
        private static readonly PowerStrings powerStrings = CardCrawlGame.languagePack.GetPowerStrings("Barricade");

        public BarricadePower(IPowerOwner owner) : base(ID, powerStrings.NAME, "barricade", powerStrings.DESCRIPTIONS)
        {
            this.owner = owner;
            amount = -1;
        }
    }
}