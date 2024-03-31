using Cards.SlayTheSpire.Model.Red.Core.GameCommand.Commands;
using Cards.SlayTheSpire.Model.Red.Core.Powers.Model;
using Classes.Core;
using Classes.Core.Entities;
using Common;
using Game.GameCommand;
using Game.GameCommand.Commands;

namespace Cards.SlayTheSpire.Model.Red
{
    internal class BattleTrance : SlayTheSpireCard, IMagicCard
    {
        private const string ID = "Battle Trance";
        private static CardStrings cardStrings;
        public int MagicNumber { get; }

        public BattleTrance() : base(ID, cardStrings.NAME, "red/skill/battle_trance", 0, cardStrings.DESCRIPTION, CardType.Skill, CardColor.Red, CardRarity.Uncommon, CardTarget.Self)
        {
            MagicNumber = 3;
        }

        public override void Use(IUserController user, ITarget target)
        {
            CommandInvoker.ExecuteCommand(new DrawCardAction(user, MagicNumber));
            CommandInvoker.ExecuteCommand(new ApplyPowerAction(user, target, new NoDrawPower(user)));
        }

        protected override AbstractCard MakeCopy()
        {
            throw new System.NotImplementedException();
        }

        public override void Upgrade()
        {
            throw new System.NotImplementedException();
        }
    }

    namespace Core.GameCommand.Commands

    {
        internal class DrawCardAction : ICommand
        {
            public DrawCardAction(IUserController source, int amount)
            {
            }

            public void Execute()
            {
            }
        }
    }

    namespace Core.Powers.Model
    {
        internal class NoDrawPower : AbstractPower
        {
            public const string ID = "No Draw";
            private static PowerStrings powerStrings = LocalizedStrings.GetPowerStrings(ID);

            public NoDrawPower(IUserController user) : base(ID, powerStrings.NAME, "red/attack/strike", powerStrings.DESCRIPTIONS)
            {
            }
        }
    }
}