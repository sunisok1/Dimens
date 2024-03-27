using Classes;
using CodiceApp.EventTracking.Plastic;

namespace Core.GameCommand.Commands
{
    public class MakeTempCardInDiscardAction : ICommand
    {
        public MakeTempCardInDiscardAction(TrackEvent.Func<AbstractCard> makeStatEquivalentCopy, int i)
        {
            
        }

        public void Execute()
        {
            
        }
    }
}