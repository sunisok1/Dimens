using Core;
using Core.Localization;
using Core.Power;

namespace Game.Powers
{
    public class BarricadePower : AbstractPower
    {
        private const string ID = "Barricade";
        private static readonly PowerStrings powerStrings = CardCrawlGame.languagePack.GetPowerStrings(ID);

        public BarricadePower(IPowerOwner owner) : base(ID, powerStrings.NAME, "barricade", powerStrings.DESCRIPTIONS,owner)
        {
            amount = -1;
        }
    }
}