using System;
using MarsRoverTest.Constants;

namespace MarsRoverTest.Classes
{
    /// <summary>
    /// Rover class 
    /// </summary>
    public class Rover : Point
    {
        public Rover(int x, int y, char heading) : base(x, y)
        {
            Heading = heading;
        }

        private char Heading;

        /// <summary>
        /// Method to take instruction string and execute, if there is a problem with string, returns apporpriate error message
        /// </summary>
        /// <param name="map">the map the rover is traversing</param>
        /// <param name="instructions">the instruction string</param>
        /// <returns>message dependent on input string</returns>
        public string TakeInstructionString(Map map, string instructions)
        {
            string output = "";
            bool success = true;
            instructions = instructions.ToUpper();

            foreach(char instruction in instructions)
            {
                if(instruction == Instruction.L || instruction == Instruction.R)
                {
                    Turn(instruction);
                }
                else if(instruction == Instruction.M)
                {
                    map.AccessGridPoint(Axis[P.X], Axis[P.Y]).RemoveRover(this);
                    success = Move(map);
                    if (!success)
                    {
                        output = $"Catastrophic Instruction Passed. Rover has fallen off plateau towards estimated grid point: {Axis[P.X]} {Axis[P.Y]}";
                        break;
                    }

                }
                else
                {
                    output = $"Incorrect Instruction Passed. All movement has stopped. Rover will shut down with current location: {Axis[P.X]} {Axis[P.Y]} {Heading}";
                    success = false;
                    break;
                }

            }
            if (success)
            {
                map.AccessGridPoint(Axis[P.X], Axis[P.Y]).SetRover(this);
                output = $"Successful traversal. All movement has stopped. Rover will shut down with current location: {Axis[P.X]} {Axis[P.Y]} {Heading}";
            } 
            return output;
        }

        /// <summary>
        /// Method to turn the rover, will update heading member
        /// </summary>
        /// <param name="instruct">turn instruction</param>
        private void Turn(char instruct)
        {
            switch (Heading)
            {
                case Constants.Heading.N:
                    Heading = instruct == Instruction.L ? Constants.Heading.W : Constants.Heading.E;
                    break;
                case Constants.Heading.E:
                    Heading = instruct == Instruction.L ? Constants.Heading.N : Constants.Heading.S;
                    break;
                case Constants.Heading.S:
                    Heading = instruct == Instruction.L ? Constants.Heading.E : Constants.Heading.W;
                    break;
                case Constants.Heading.W:
                    Heading = instruct == Instruction.L ? Constants.Heading.S : Constants.Heading.N;
                    break;
            }
        }

        /// <summary>
        /// method to move rover 
        /// </summary>
        /// <param name="map">map the rover is traversing</param>
        /// <returns>returns true if move was successful, otherwise false if rover has been navigated out of bounds off the plateau</returns>
        private bool Move(Map map)
        {
            switch (Heading)
            {
                case Constants.Heading.N:
                    Axis[P.Y] += (int)Movement.N;
                    break;
                case Constants.Heading.E:
                    Axis[P.X] += (int)Movement.E;
                    break;
                case Constants.Heading.S:
                    Axis[P.Y] += (int)Movement.S;
                    break;
                case Constants.Heading.W:
                    Axis[P.X] += (int)Movement.W;
                    break;
            }
            
            return !map.IsOutOfBounds(Axis[P.X], Axis[P.Y]); 
        }

        /// <summary>
        /// Method to verify rover input
        /// </summary>
        /// <param name="map">map the rover is traversing</param>
        /// <param name="input">rover input</param>
        /// <returns>new rover if valid input, otherwise null</returns>
        public static Rover VerifyRoverInput(Map map, string input)
        {
            Rover rover = null;
            input.Trim();
            string[] inputSplit = input.Split(' ');
            if(inputSplit.Length <= 3)
            {
                try
                {
                    char heading = Convert.ToChar(inputSplit[P.H].ToUpper());
                    if (Int32.TryParse(inputSplit[P.X], out int X) && Int32.TryParse(inputSplit[P.Y], out int Y) && Constants.Heading.IsHeading(heading))
                    {
                        if(map.AccessGridPoint(X, Y) != null)
                        {
                            rover = new Rover(X, Y, heading);
                        }
                    }
                }
                catch
                {
                    rover = null;
                }
               
            }
            return rover;

        }

        /// <summary>
        /// Method to create rover from user input, puts user in loop until successful creation
        /// </summary>
        /// <param name="map">map rover is traversing</param>
        /// <returns>newly created rover</returns>
        public static Rover CreateRover(Map map)
        {
            Rover rover = VerifyRoverInput(map, Console.ReadLine());
            while (rover == null)
            {
                Console.WriteLine("The rover coordinates entered were invalid. Either the coordinates were out of the plateau or incorrectly input. Please try again. The correct format is: X Y H");
                rover = VerifyRoverInput(map, Console.ReadLine());
            }

            return rover;
        }

    }
}
