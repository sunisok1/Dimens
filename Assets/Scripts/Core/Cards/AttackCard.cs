namespace Core.Cards
{
    public class AttackCard : Card
    {
        public CardEffect Effect { get; private set; }

        public AttackCard(string name, string description, int cost, CardEffect effect) : base(name, description, cost)
        {
            Effect = effect;
        }

        public override void ExecuteEffect(CardEffectArgs args)
        {
            Effect?.Invoke(args);
        }
    }
}