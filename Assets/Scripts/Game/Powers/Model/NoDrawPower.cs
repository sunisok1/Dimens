using Core;
using Core.Entities;
using Core.Localization;

namespace Game.Powers.Model
{
    public class NoDrawPower : AbstractPower
    {
        public const string ID = "No Draw";
        private static PowerStrings powerStrings = CardCrawlGame.languagePack.GetPowerStrings(ID);

        public NoDrawPower(AbstractEntity user) : base(ID, powerStrings.NAME, "red/attack/strike", powerStrings.DESCRIPTIONS)
        {
        }
    }
}