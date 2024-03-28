using Classes;
using Classes.Entities;
using Common;
using Core.GameCommand;
using Core.GameCommand.Commands;

namespace Core.Cards.Model.Red
{
    internal class Armaments : SlayTheSpireCard
    {
        private const string ID = "Armaments";
        private static readonly CardStrings cardStrings = LocalizedStrings.GetCardStrings(ID);

        public Armaments() : base(ID,cardStrings.NAME, "red/attack/armaments", 1, cardStrings.DESCRIPTION, CardType.Attack, CardRarity.Basic,CardColor.Red ,CardTarget.Self)
        {
            this.block = 5;
        }

        public override void Upgrade()
        {
            base.Upgrade();
            this.rawDescription = cardStrings.UPGRADE_DESCRIPTION;
        }

        public override AbstractCard MakeCopy()
        {
            return new Armaments();
        }

        public override void Use(IUserController user, IHealthController target)
        {
            CommandInvoker.ExecuteCommand(new GainBlockAction(user, user, this.block));
            CommandInvoker.ExecuteCommand(new ArmamentsAction(this.Upgraded));
        }
    }
}