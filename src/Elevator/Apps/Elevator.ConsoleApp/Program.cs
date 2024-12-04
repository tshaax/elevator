using Elevator.Domain;
using Elevator.Domain.Contracts;

namespace Elevator.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Elevator Challenge!");

            Console.Write("\nEnter Total Number of floors: ");
            var floors = Console.ReadLine();
            int.TryParse(floors, out int noOffloors);

            Console.Write("\nEnter Total Number of elavators: ");
            var elevators = Console.ReadLine();
            int.TryParse(elevators, out int noOfelevators);

            Console.Write("\nEnter maximum number of passenger per elevator: ");
            var maxPassengers = Console.ReadLine();
            int.TryParse(maxPassengers, out int noOfmaxPassengers);


            IBuilding building = new Building(noOffloors, noOfelevators, noOfmaxPassengers); 
            string command;

            do
            {
                Console.WriteLine("\nCommands to operate the evelators: 'call <floor>', 'go <elevatorId> <floor>', 'status', 'exit'");
                Console.Write("Enter command: ");
                command = Console.ReadLine();

                string[] parts = command.Split(' ');

                switch (parts[0].ToLower())
                {
                    case "call":
                        if (int.TryParse(parts[1], out int callFloor))
                            building.CallElevator(callFloor);
                        else
                            Console.WriteLine("Invalid floor number.");
                        break;

                    case "go":
                        if (parts.Length == 3 &&
                            int.TryParse(parts[1], out int elevatorId) &&
                            int.TryParse(parts[2], out int goFloor))
                        {
                            building.SendPassenger(elevatorId, goFloor);
                        }
                        else
                            Console.WriteLine("Invalid command format. Use 'go <elevatorId> <floor>'.");
                        break;

                    case "status":
                        building.DisplayStatus();
                        break;

                    case "exit":
                        Console.WriteLine("Exiting the program.");
                        break;

                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            } while (command.ToLower() != "exit");
        }
    }

 
  




   

}
