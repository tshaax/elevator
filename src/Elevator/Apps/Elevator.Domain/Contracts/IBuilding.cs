namespace Elevator.Domain.Contracts
{
    // Interfaces to define the contracts
    public interface IBuilding
    {
        void CallElevator(int floor);
        void SendPassenger(int elevatorId, int floor);
        void DisplayStatus();
    }
}
