using Core.Entities;

namespace Core.Cards
{
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