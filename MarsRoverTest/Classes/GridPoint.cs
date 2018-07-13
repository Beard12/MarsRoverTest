using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverTest.Classes
{
    /// <summary>
    /// Class to represent a grid point on the map
    /// </summary>
    public class GridPoint : Point
    {

        public GridPoint(int x, int y) : base(x, y)
        {

        }

        /// <summary>
        /// Boolean to determine rover is present at grid point
        /// </summary>
        private bool RoverPresent = false;

        /// <summary>
        /// List of rovers at current grid point
        /// </summary>
        public List<Rover> Rovers = new List<Rover>();

        /// <summary>
        /// Method to check if rover is present
        /// </summary>
        /// <returns>true if rover presnt, false if not</returns>
        public bool IsRoverPresent()
        {
            return RoverPresent;
        }

        /// <summary>
        /// Method to add rover to point, sets RoverPresent to true
        /// </summary>
        /// <param name="rover">rover to add</param>
        public void SetRover(Rover rover)
        {
            Rovers.Add(rover);
            RoverPresent = true;
        }

        /// <summary>
        /// Method to remove rover, will set RoverPresent to false if no more rovers
        /// </summary>
        /// <param name="rover">rover to remove</param>
        public void RemoveRover(Rover rover)
        {
            Rovers.Remove(rover);
            if(Rovers.Count == 0)
            {
                RoverPresent = false;
            }
        }
    }
}
