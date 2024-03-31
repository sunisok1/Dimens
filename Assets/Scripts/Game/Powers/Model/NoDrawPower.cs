using Common;
using Core;

namespace Game.Powers.Model
{
    public class NoDrawPower : AbstractPower
    {
        public const string ID = "No Draw";
        private static PowerStrings powerStrings = LocalizedStrings.GetPowerStrings(ID);

        public NoDrawPower(IUserController user) : base(ID, powerStrings.NAME, "red/attack/strike", powerStrings.DESCRIPTIONS)
        {
        }
    }
}