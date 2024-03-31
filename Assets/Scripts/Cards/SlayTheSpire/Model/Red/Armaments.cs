using Classes;
using Classes.Core;
using Classes.Core.Entities;
using Common;
using Game.GameCommand;
using Game.GameCommand.Commands;

namespace Cards.SlayTheSpire.Model.Red
{
    internal class Armaments : SlayTheSpireCard, IBlockCard
    {
        private const string ID = "Armaments";
        private static readonly CardStrings cardStrings = LocalizedStrings.GetCardStrings(ID);
        public int Block { get; private set; }

        public Armaments() : base(ID,cardStrings.NAME, "red/skill/armaments", 1, cardStrings.DESCRIPTION, CardType.Attack,CardColor.Red ,CardRarity.Basic, CardTarget.Self)
        {
            Block = 5;
        }

        public override void Upgrade()
        {
            UpgradeName();
            rawDescription = cardStrings.UPGRADE_DESCRIPTION;
        }

  
        protected override AbstractCard MakeCopy()
        {
            return new Armaments();
        }

        public override void Use(IUserController user, ITarget target)
        {
            CommandInvoker.ExecuteCommand(new GainBlockAction(user, user, Block));
            CommandInvoker.ExecuteCommand(new ArmamentsAction(Upgraded));
        }
    }
}