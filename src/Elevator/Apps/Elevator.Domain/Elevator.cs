namespace Elevator.Domain
{
  
    public class Elevator : IElevator
    {
        public int Id { get; private set; }
        private int _currentFloor = 1;
        private readonly int _totalFloors;
        private readonly int _capacity;
        private int _occupants = 0;

        public Elevator(int id, int totalFloors, int capacity)
        {
            Id = id;
            _totalFloors = totalFloors;
            _capacity = capacity;
        }

        public void Call(int floor)
        {
            MoveToFloor(floor);
            Console.WriteLine($"Elevator {Id} called to floor {floor}.");
        }

        public void Go(int floor)
        {
            if (_occupants >= _capacity)
            {
                Console.WriteLine($"Elevator {Id} is full. Cannot add more passengers.");
                return;
            }

            if (floor < 1 || floor > _totalFloors)
            {
                Console.WriteLine("Invalid floor.");
                return;
            }

            _occupants++;
            Console.WriteLine($"Passenger added to Elevator {Id}. Current occupants: {_occupants}");
            MoveToFloor(floor);
        }

        public void Status()
        {
            Console.WriteLine($"Elevator {Id} - Current floor: {_currentFloor}, Occupants: {_occupants}/{_capacity}");
        }

        public int DistanceTo(int floor)
        {
            return Math.Abs(_currentFloor - floor);
        }

        private void MoveToFloor(int floor)
        {
            Console.WriteLine($"Elevator {Id} moving from floor {_currentFloor} to floor {floor}...");
            _currentFloor = floor;
            Console.WriteLine($"Elevator {Id} arrived at floor {floor}.");
        }
    }
}
