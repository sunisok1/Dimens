using Core.Entities;

namespace Core.Cards
{
    [CardImage("Art/Slay the Spire/Anger")]
    public class EquipmentCard : Card
    {
        public Equipment equipment { get; }

        public EquipmentCard(string name, string description, Equipment equipment) : base(name, description, 0)
        {
            this.equipment = equipment;
        }

        public override void ExecuteEffect(CardEffectArgs args)
        {
        }
    }
}