namespace MarsRoverTest.Classes
{
    /// <summary>
    /// Base class for everything on the map
    /// </summary>
    public class Point
    {
        public Point(int x, int y)
        {
            Axis = new int[] { x, y };
        }

        protected int[] Axis { get; set; }

        /// <summary>
        /// Method to retrieve the axis
        /// </summary>
        /// <returns></returns>
        public int[] GetAxis()
        {
            return Axis;
        }
    }
}
