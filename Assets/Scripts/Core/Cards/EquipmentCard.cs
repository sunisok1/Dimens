using Core.Entities;

namespace Core.Cards
{
    public class EquipmentCard : Card
    {
        private readonly Equipment equipment;

        public EquipmentCard(string name, string description, int cost, Equipment equipment) : base(name, description, cost)
        {
            this.equipment = equipment;
        }

        public override void ExecuteEffect(CardEffectArgs args)
        {
            if (args.target is Player player)
            {
                player.Equip(equipment);
            }
        }
    }
}