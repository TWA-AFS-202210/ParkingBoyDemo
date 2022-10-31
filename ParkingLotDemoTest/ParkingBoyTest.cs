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

        [Fact]
        public void Should_return_car_when_customer_fetch_a_car_with_ticket()
        {
            //given
            ParkingLot parkingLot = new ParkingLot();
            ParkingBoy parkingBoy = new ParkingBoy(parkingLot);
            Car aCarNeedToPark = new Car();
            Ticket ticket = parkingBoy.ParkingCar(aCarNeedToPark);
            //when
            Car aCarFetched = parkingBoy.FetchCar(ticket);
            //then

            Assert.NotNull(aCarFetched);
        }
    }
}