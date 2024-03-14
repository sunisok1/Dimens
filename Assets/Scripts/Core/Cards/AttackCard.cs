namespace Core.Cards
{
    [CardImage("Art/Slay the Spire/Strike_R")]
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