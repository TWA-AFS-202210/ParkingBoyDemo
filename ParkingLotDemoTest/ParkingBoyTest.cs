namespace ParkingLotDemoTest
{
    using ParkingLotDemo;
    using Xunit;

    public class ParkingBoyTest
    {
        [Fact]
        public void Should_return_ticket_when_ParkingBoy_Parking_a_car()
        {
            //given
            ParkingLot parkingLot = new ParkingLot();
            ParkingBoy parkingBoy = new ParkingBoy(parkingLot);
            Car car = new Car();
            //when
            Ticket ticket = parkingBoy.ParkingCar(car);
            //then
            Assert.NotNull(ticket);
        }
    }
}