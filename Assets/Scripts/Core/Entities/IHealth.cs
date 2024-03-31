namespace Core.Entities
{
    public interface IHealth
    {
        int CurHealth { get; set; }
        int MaxHealth { get; set; }
    }
}