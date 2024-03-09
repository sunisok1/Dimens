namespace Core.Cards
{
    public class AttackCard : Card
    {
        public int Damage { get; private set; }
        public CardEffect Effect { get; private set; }

        public AttackCard(string name, string description, int cost, int damage, CardEffect effect) : base(name, description, cost)
        {
            Damage = damage;
            Effect = effect;
        }

        public override void ExecuteEffect(CardEffectArgs args)
        {
            Effect?.Invoke(args);
        }
    }
}