namespace Core
{
    public class Map
    {
        protected int width;
        protected int height;

        public Map(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
    }

    public interface IMapGenerator
    {
        Map GenerateMap();
    }
}