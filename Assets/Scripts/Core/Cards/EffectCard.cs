namespace Core.Cards
{
    [CardImage("Art/Slay the Spire/Bash")]
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