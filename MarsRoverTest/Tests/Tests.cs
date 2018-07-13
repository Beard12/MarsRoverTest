using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRoverTest.Constants;
using MarsRoverTest.Classes;

namespace MarsRoverTest.Tests
{
    public static class MovementTests
    {

        public static bool TestInput()
        {
            bool testSuccess = false;
            Map map = new Map(5, 5);
            Rover rover = new Rover(1, 2, 'N');
            string response = rover.TakeInstructionString(map,"LMLMLMLMM");
            if (response.Equals("Successful traversal. All movement has stopped. Rover will shut down with current location: 1 3 N", StringComparison.InvariantCulture))
            {
                testSuccess = true;
            }
            return testSuccess;
        }

        public static bool TestInput2()
        {
            bool testSuccess = false;
            Map map = new Map(5, 5);
            Rover rover = new Rover(3, 3, 'E');
            string response = rover.TakeInstructionString(map, "MMRMMRMRRM");
            if (response.Equals("Successful traversal. All movement has stopped. Rover will shut down with current location: 5 1 E", StringComparison.InvariantCulture))
            {
                testSuccess = true;
            }
            return testSuccess;
        }

        public static bool TestInput3()
        {
            bool testSuccess = false;
            Map map = new Map(5, 5);
            Rover rover = new Rover(2, 1, 'N');
            string response = rover.TakeInstructionString(map, "MMRMMR");
            if (response.Equals("Successful traversal. All movement has stopped. Rover will shut down with current location: 4 3 S", StringComparison.InvariantCulture))
            {
                testSuccess = true;
            }
            return testSuccess;
        }

        public static bool FailInput()
        {
            bool testSuccess = false;
            Map map = new Map(5, 5);
            Rover rover = new Rover(1, 3, 'S');
            string response = rover.TakeInstructionString(map, "MMMM");
            if (response.Equals("Catastrophic Instruction Passed. Rover has fallen off plateau towards estimated grid point: 1 -1", StringComparison.InvariantCulture))
            {
                testSuccess = true;
            }
            return testSuccess;
        }

        public static bool FailInput2()
        {
            bool testSuccess = false;
            Map map = new Map(5, 5);
            Rover rover = new Rover(1, 3, 'S');
            string response = rover.TakeInstructionString(map, "MM777M");
            if (response.Equals("Incorrect Instruction Passed. All movement has stopped. Rover will shut down with current location: 1 1 S", StringComparison.InvariantCulture))
            {
                testSuccess = true;
            }
            return testSuccess;
        }
    }
}
