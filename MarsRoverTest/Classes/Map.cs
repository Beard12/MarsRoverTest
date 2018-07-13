using System;
using System.Collections.Generic;
using System.Linq;
using MarsRoverTest.Constants;

namespace MarsRoverTest.Classes
{
    /// <summary>
    /// Class to reperesent the collection of grid points to make up the map
    /// </summary>
    public class Map
    {
        public Map(int x, int y)
        {
            for(int i = 0; i <= x; i++)
            {
                for(int j = 0; j <= y; j++)
                {
                    Grid.Add(new GridPoint(i, j));
                }
            }
        }

        public List<GridPoint> Grid = new List<GridPoint>();

        /// <summary>
        /// Static method to determine if map input was valid
        /// </summary>
        /// <param name="input">map input</param>
        /// <returns>null if invalid input, otherwise returns new map</returns>
        public static Map VerifyMapInput(string input)
        {
            Map map = null;
            input.Trim();
            string[] inputSplit = input.Split(' ');

            if(inputSplit.Length <= 2 && Int32.TryParse(inputSplit[P.X], out int X) && Int32.TryParse(inputSplit[P.Y], out int Y)){
                map = new Map(X, Y);
            }

            return map;
        }

        /// <summary>
        /// Method to determin if point is out of bounds of grid
        /// </summary>
        /// <param name="x">x axis of point</param>
        /// <param name="y">y axis of point</param>
        /// <returns>true if out of bounds, false if not </returns>
        public bool IsOutOfBounds(int x, int y)
        {
            bool outOfBounds = false;
            int validpoints = Grid.Count(p => (x == p.GetAxis()[P.X]) && (y == p.GetAxis()[P.Y]));
            if (validpoints == 0)
            {
                outOfBounds = true;
            }
            return outOfBounds;
        }

        /// <summary>
        /// Method to access specific grid point
        /// </summary>
        /// <param name="x">x axis of point</param>
        /// <param name="y">y axis of point</param>
        /// <returns>null if no point found, otherwise returns point</returns>
        public GridPoint AccessGridPoint(int x, int y)
        {
            return Grid.FirstOrDefault(point => (x == point.GetAxis()[P.X]) && (y == point.GetAxis()[P.Y]));
        }

        /// <summary>
        /// 
        /// </summary>
        public void GetAllRoverDisplay()
        {
            List<string> gridpoints = Grid.Where(point => point.IsRoverPresent()).Select(r => $"{r.Rovers.Count} rover(s) present at {r.GetAxis()[P.X]} {r.GetAxis()[P.Y]}").ToList();
            foreach(string point in gridpoints)
            {
                Console.WriteLine(point);
            }
        }

    }
}
