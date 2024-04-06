using Core.Card;

namespace Core
{
    public interface IHasTarget
    {
        CardTarget Target { get; }
    }
}