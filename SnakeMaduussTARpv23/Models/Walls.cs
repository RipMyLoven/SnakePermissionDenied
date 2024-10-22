namespace SnakeMaduussTARpv23.Models
{
    internal class Walls
    {
        List<Figure> wallList;

        public Walls(int mapWidth, int mapHeight)
        {
            wallList = new List<Figure>();

            HorizontalLine upLine = new (0, mapWidth - 2, 0, '+');
            HorizontalLine downLine = new (0, mapWidth - 2, mapHeight - 1, '+');
            VerticalLine leftLine = new (0, mapHeight - 1, 0, '+');
            VerticalLine rightLine = new (0, mapHeight - 1, mapWidth - 2, '+');

            wallList.Add(upLine);
            wallList.Add(downLine);
            wallList.Add(leftLine);
            wallList.Add(rightLine);
        }

        internal bool IsHit(Figure figure)
        {
            foreach (Figure wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
            }
            return false;
        }

        public void Draw()
        {
            foreach (Figure wall in wallList)
            {
                wall.Draw();
            }
        }
    }
}
