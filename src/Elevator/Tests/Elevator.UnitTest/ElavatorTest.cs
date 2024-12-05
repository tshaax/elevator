using Elevator.Domain;
using Elevator.Domain.Contracts;

namespace ElevatorUnitTest
{
    public class ElevatorTests
    {
        [Fact]
        public void Elevator_Call_ShouldMoveToCorrectFloor()
        {
            // Arrange
            var elevator = new ElevatorLift(1, 10, 5);

            // Act
            elevator.Call(5);

            // Assert
            Assert.Equal(5, elevator.GetCurrentFloor());
        }

        [Fact]
        public void Elevator_Go_ShouldIncreaseOccupantsAndMoveToFloor()
        {
            // Arrange
            var elevator = new ElevatorLift(1, 10, 5);

            // Act
            elevator.Go(8);

            // Assert
            Assert.Equal(8, elevator.GetCurrentFloor());
            Assert.Equal(1, elevator.GetOccupants());
        }

        [Fact]
        public void Elevator_ShouldNotExceedCapacity()
        {
            // Arrange
            var elevator = new ElevatorLift(10, 1, 5);

            // Act

            elevator.Go(3);
     
            elevator.Go(4);
     
            elevator.Go(5);
     

            // Assert
            Assert.Equal(0, elevator.GetOccupants());
        }

        [Fact]
        public void Elevator_DistanceTo_ShouldReturnCorrectDistance()
        {
            // Arrange
            var elevator = new ElevatorLift(1, 10, 5);
            elevator.Call(5);

            // Act
            var distance = elevator.DistanceTo(8);

            // Assert
            Assert.Equal(3, distance);
        }
    }

    public class BuildingTests
    {


        [Fact]
        public void Building_SendPassenger_ShouldUseCorrectElevator()
        {
            // Arrange
            var building = new Building(10, 2, 5);

            // Act
            building.CallElevator(3); // Elevator 1 to floor 3
            building.SendPassenger(1, 6); // Use Elevator 1 to go to floor 6

            // Assert
            var elevator1 = building.GetElevators().First(e => e.Id == 1);
            Assert.Equal(10, building.GetCurrentFloor());
        }

        [Fact]
        public void Building_InvalidElevatorId_ShouldNotThrowException()
        {
            // Arrange
            var building = new Building(10, 2, 5);

            // Act & Assert
            Exception ex = Record.Exception(() => building.SendPassenger(99, 5));
            Assert.Null(ex); // Ensure no exceptions were thrown
        }
    }
}
