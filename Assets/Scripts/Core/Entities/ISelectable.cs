namespace Core.Entities
{
    public interface ISelectable
    {
        bool Select();
        bool Deselect();
    }
}