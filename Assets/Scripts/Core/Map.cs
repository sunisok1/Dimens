namespace Core
{
    public abstract class Map
    {
    }

    public interface IMapGenerator
    {
        Map GenerateMap();
    }
}