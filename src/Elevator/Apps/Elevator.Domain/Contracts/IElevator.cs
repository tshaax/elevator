namespace Elevator.Domain.Contracts
{

    // Interfaces to define the contracts
    public interface IElevator
    {
        int Id { get; }
        void Call(int floor);
        void Go(int floor);
        void Status();
        int DistanceTo(int floor);
    }
}
