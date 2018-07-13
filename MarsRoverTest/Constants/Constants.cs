namespace MarsRoverTest.Constants
{
    /// <summary>
    /// Class to compare string instruction against
    /// </summary>
    public static class Instruction
    {
        public const char L = 'L';
        public const char R = 'R';
        public const char M = 'M';
    }

    /// <summary>
    /// Enum to add distance to x or y axis depending on direction
    /// </summary>
    public enum Movement
    {
        N = 1,
        S = -1,
        E = 1,
        W = -1

    }
    
    /// <summary>
    /// Class to set the index at which the x,y axis were set and the heading index when needed
    /// </summary>
    public static class P
    {
        public const int X = 0;
        public const int Y = 1;
        public const int H = 2;
    }

    /// <summary>
    /// Class to compare heading against
    /// </summary>
    public static class Heading
    {
        public const char N = 'N';
        public const char E = 'E';
        public const char S = 'S';
        public const char W = 'W';

        /// <summary>
        /// Determine if heading was actual heading
        /// </summary>
        /// <param name="heading">char to compare </param>
        /// <returns>true if heading, false if not</returns>
        public static bool IsHeading(char heading)
        {
            return (heading == N || heading == E || heading == S || heading == W);
        }
    }
}
