using System;
using MarsRoverTest.Classes;
using MarsRoverTest.Tests;

namespace MarsRoverTest
{
    class Program
    {
        static void Main()
        {
            RunTests();
            Console.WriteLine("Welcome to the Rover Map Program!\nPlease begin by inputting map coordinates.");
            Map newMap = Map.VerifyMapInput(Console.ReadLine());
            while(newMap == null)
            {
                Console.WriteLine("The previous coordinates entered were invalid. Please try again. The correct format is: X Y");
                newMap = Map.VerifyMapInput(Console.ReadLine());
            }

            bool moreRovers = true;
            Rover rover = null;
            while (moreRovers)
            {
                Console.WriteLine("Please enter the rover information.");
                rover = Rover.CreateRover(newMap);
                Console.WriteLine("Please enter the instruction string to move the rover");
                Console.WriteLine(rover.TakeInstructionString(newMap, Console.ReadLine()));

                Console.WriteLine("Press Y to add one more rover. If you are done entering rover information please hit enter to exit.");
                Console.WriteLine();
                char answer = Console.ReadKey().KeyChar;
                if(answer != 'Y' && answer != 'y')
                {
                    moreRovers = false;
                }
            }

            newMap.GetAllRoverDisplay();
            Console.ReadKey();
        }

        public static void RunTests()
        {
            bool testSuccess = false;
            testSuccess = MovementTests.TestInput();
            testSuccess = MovementTests.TestInput2();
            testSuccess = MovementTests.TestInput3();
            testSuccess = MovementTests.FailInput();
            testSuccess = MovementTests.FailInput2();
            if (testSuccess)
            {
                Console.WriteLine("Initial tests run successfully!");
            }
            else
            {
                Console.WriteLine("Imminent failure, initial tests have failed");
            }
        }
    }
}
