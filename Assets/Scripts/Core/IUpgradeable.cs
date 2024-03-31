namespace Core
{
    public interface IUpgradeable
    {
        int TimesUpgraded { get; set; }
        void Upgrade();
        void UpgradeName();
    }
}