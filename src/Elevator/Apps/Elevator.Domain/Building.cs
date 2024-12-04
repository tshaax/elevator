namespace Elevator.Domain
{
    // Building manages multiple elevators
    public class Building : IBuilding
    {
        private readonly List<IElevator> _elevators;
        private readonly int _totalFloors;

        public Building(int totalFloors, int numElevators, int capacity)
        {
            _totalFloors = totalFloors;
            _elevators = new List<IElevator>();

            for (int i = 1; i <= numElevators; i++)
            {
                _elevators.Add(new Elevator(i, totalFloors, capacity));
            }
        }

        public void CallElevator(int floor)
        {
            if (floor < 1 || floor > _totalFloors)
            {
                Console.WriteLine("Invalid floor.");
                return;
            }

            var nearestElevator = _elevators.OrderBy(e => e.DistanceTo(floor)).First();
            nearestElevator.Call(floor);
        }

        public void SendPassenger(int elevatorId, int floor)
        {
            var elevator = _elevators.FirstOrDefault(e => e.Id == elevatorId);
            if (elevator == null)
            {
                Console.WriteLine("Invalid elevator ID.");
                return;
            }

            elevator.Go(floor);
        }

        public void DisplayStatus()
        {
            foreach (var elevator in _elevators)
            {
                elevator.Status();
            }
        }
    }
}
