namespace Core.Powers
{
    public interface IPowerCapable
    {
        void AddPower(AbstractPower power);
        bool HasPower(string powerId);
    }
}