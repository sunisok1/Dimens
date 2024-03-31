using Common;
using Core;
using Game.GameCommand;
using Game.GameCommand.Commands;

namespace Cards.SlayTheSpire.Model.Red
{
    internal class Bash : AbstractSlayTheSpireCard, IMagicCard, IDamageCard
    {
        private const string ID = "Strike_R";
        private static readonly CardStrings cardStrings = LocalizedStrings.GetCardStrings(ID);
        public int Damage { get; private set; }
        public int MagicNumber { get; private set; }

        public Bash() : base(ID, cardStrings.NAME, "red/attack/bash", 2, cardStrings.DESCRIPTION, CardType.Attack, CardColor.Red, CardRarity.Basic, CardTarget.Enemy)
        {
            Damage = 8;
            MagicNumber = 2;
        }

        public override void Use(IUserController user, ITarget target)
        {
            CommandInvoker.ExecuteCommand(new DamageCommand(target, new DamageInfo(user, 6)));
        }

        public override void Upgrade()
        {
            UpgradeName();
            Damage += 2;
            this.MagicNumber += 1;
        }

        protected override AbstractCard MakeCopy()
        {
            return new Bash();
        }
    }
}