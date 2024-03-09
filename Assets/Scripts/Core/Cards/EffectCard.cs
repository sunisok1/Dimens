namespace Core.Cards
{
    public class EffectCard : Card
    {
        public CardEffect Effect { get; private set; }

        public EffectCard(string name, string description, int cost, CardEffect effect) : base(name, description, cost)
        {
            Effect = effect;
        }

        public override void ExecuteEffect(CardEffectArgs args)
        {
            Effect?.Invoke(args);
        }
    }
}