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
            Car car = new Car("car1");
            //when
            Ticket ticket = parkingBoy.Parking(car);
            //then
            Assert.NotNull(ticket);
        }

        [Fact]
        public void Should_return_car_when_customer_fetch_a_car_with_ticket()
        {
            //given
            ParkingLot parkingLot = new ParkingLot();
            ParkingBoy parkingBoy = new ParkingBoy(parkingLot);
            Car aCarNeedToPark = new Car("car1");
            Ticket ticket = parkingBoy.Parking(aCarNeedToPark);
            //when
            Car aCarFetched = parkingBoy.PickUp(ticket);
            //then

            Assert.NotNull(aCarFetched);
        }


        [Fact]
        public void Should_return_tickets_when_batch_parking_car_given_parking_boy_and_cars()
        {
            var car1 = new Car("car1");
            var car2 = new Car("car2");
            var car3 = new Car("car3");
            List<Car> cars = new List<Car>();
            cars.Add(car1);
            cars.Add(car2);
            cars.Add(car3);
            var paringLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(paringLot);
            //when
            var tickets = parkingBoy.Parking(cars);
            //then
            Assert.Equal(car1.CarNumber, tickets[0].CarNumber);
            Assert.Equal(car2.CarNumber, tickets[1].CarNumber);
            Assert.Equal(car3.CarNumber, tickets[2].CarNumber);
        }
    }
}