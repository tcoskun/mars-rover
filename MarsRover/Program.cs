using MarsRover.Core;
using MarsRover.Core.Aggregates;
using System;
using System.Collections.Generic;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            var roverMovements = new List<RoverCommand>();
            Console.WriteLine("-------------Mars Rover-------------");
            Plateau plateau = default;

            while (true)
            {
                try
                {
                    Console.Write("Enter Plateau Size (5 5): ");
                    var plateauInput = Console.ReadLine();
                    plateau = new Plateau(plateauInput.ToUpper());
                    break;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("------------------------------------");
                }
            }

            var order = 1;

            while (true)
            {
                try
                {
                    Console.Write("Enter Rover Position (0 0 N): ");
                    var roverInput = Console.ReadLine();
                    var rover = new Rover(roverInput.ToUpper());
                    plateau.AddRover(rover);

                    Console.Write("Enter Rover Commands (NLM): ");
                    var roverCommandInput = Console.ReadLine();
                    var roverCommand = new RoverCommand(rover.Id, order, roverCommandInput.ToUpper());
                    roverMovements.Add(roverCommand);

                    Console.Write("Do you want to add new rover? (Y or N): ");
                    var answer = Console.ReadLine();

                    if (!answer.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                    {
                        break;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("------------------------------------");
                }
            }

            var movementManager = new MovementManager(plateau, roverMovements);
            movementManager.StartMovements();

            Console.WriteLine("---------------Result---------------");
            var writeOrder = 1;

            foreach (var rover in movementManager.Plateau.Rovers)
            {
                Console.WriteLine($"Rover{order} Location: {rover.XPosition} {rover.YPosition} {rover.Direction}");
                writeOrder++;
            }

            Console.WriteLine("------------------------------------");
            Console.WriteLine("Press any key for exit");
            Console.ReadLine();
        }
    }
}
