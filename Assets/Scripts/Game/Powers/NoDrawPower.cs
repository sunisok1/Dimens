using Core;
using Core.Localization;
using Core.Power;

namespace Game.Powers
{
    public class NoDrawPower : AbstractPower
    {
        private const string ID = "No Draw";
        private static readonly PowerStrings powerStrings = CardCrawlGame.languagePack.GetPowerStrings(ID);

        public NoDrawPower(IPowerOwner owner) : base(ID, powerStrings.NAME, "red/attack/strike", powerStrings.DESCRIPTIONS, owner)
        {
        }
    }
}