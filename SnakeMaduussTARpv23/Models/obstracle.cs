using System;
using System.Collections.Generic;
namespace SnakeMaduussTARpv23.Models
{
    internal class Obstacle
    {
        List<Point> obstacleList;

        private int width;
        private int height;

        public Obstacle(int xStart, int yStart, int width, int height)
        {
            this.width = width;
            this.height = height;
            obstacleList = [];

            GenerateObstacle(xStart, yStart,width, height);
        }
        public void GenerateObstacle(int xStart, int yStart, int width, int height)
        {
            obstacleList = []; 

            for (int x = xStart; x < xStart + width; x++)
            {
                obstacleList.Add(new Point(x, yStart, '─'));
                obstacleList.Add(new Point(x, yStart + height - 1, '─'));
            }

            for (int y = yStart; y < yStart + height; y++)
            {
                obstacleList.Add(new Point(xStart, y, '│'));
                obstacleList.Add(new Point(xStart + width - 1, y, '│'));
            }

            obstacleList.Add(new Point(xStart, yStart, '┌'));
            obstacleList.Add(new Point(xStart + width - 1, yStart, '┐'));
            obstacleList.Add(new Point(xStart, yStart + height - 1, '└'));
            obstacleList.Add(new Point(xStart + width - 1, yStart + height - 1, '┘'));
            }
            public void MoveObstacle(int maxWidth, int maxHeight, List<Point> snakePoints, Point foodPoint)
            {
            Random rand = new ();
            int xStart, yStart;
            bool overlap;

            do
            {
                overlap = false;
                xStart = rand.Next(1, maxWidth - width - 1);
                yStart = rand.Next(1, maxHeight - height - 1);

                foreach (var point in snakePoints)
                {
                    if (point.IsHit(new Point(xStart, yStart, ' ')) || foodPoint.IsHit(new Point(xStart, yStart, ' ')))
                    {
                        overlap = true;
                        break;
                    }
                }
            }
            while (overlap);

            foreach (var obstacle in obstacleList)
            {
                obstacle.Clear();
            }

            obstacleList.Clear();
            GenerateObstacle(xStart, yStart,width, height);

            Draw();
        }

        internal bool IsHit(Figure figure)
        {
            foreach (var obstacle in obstacleList)
            {
                if (figure.IsHit(obstacle))
                {
                    return true;
                }
            }
            return false;
        }

        public void Draw()
        {
            foreach (var obstacle in obstacleList)
            {
                obstacle.Draw();
            }
        }
    }
}