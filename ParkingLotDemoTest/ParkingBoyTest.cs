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

            // when
            var response = parkingBoy.Parking(cars);

            // then
            Assert.Equal(car1.CarNumber, response.Tickets[0].CarNumber);
            Assert.Equal(car2.CarNumber, response.Tickets[1].CarNumber);
            Assert.Equal(car3.CarNumber, response.Tickets[2].CarNumber);
        }

        [Fact]
        public void Should_can_pick_up_use_batch_parking_ticket()
        {
            var car1 = new Car("car1");
            var car2 = new Car("car2");
            var car3 = new Car("car3");
            var cars = new List<Car>
            {
                car1,
                car2,
                car3,
            };
            var paringLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(paringLot);
            var response = parkingBoy.Parking(cars);
            //then
            Assert.Equal(car1, parkingBoy.PickUp(response.Tickets[0]));
            Assert.Equal(car2, parkingBoy.PickUp(response.Tickets[1]));
            Assert.Equal(car3, parkingBoy.PickUp(response.Tickets[2]));
        }

        [Fact]
        public void Should_return_null_when_given_null_as_ticket()
        {
            // given
            var paringLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(paringLot);

            // when
            // then
            var parkingException = Assert.Throws<ParkingException>(() => parkingBoy.PickUp(null));
            Assert.Equal("Please provide your parking ticket.", parkingException.Message);
        }

        [Fact]
        public void Should_return_null_when_given_ticket_not_in_lot()
        {
            // given
            var paringLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(paringLot);

            // when
            // then
            var parkingException = Assert.Throws<ParkingException>(() => parkingBoy.PickUp(new Ticket(null)));
            Assert.Equal("Unrecognized parking ticket.", parkingException.Message);
        }

        [Fact]
        public void Should_return_null_when_ticket_is_used()
        {
            // given
            var paringLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(paringLot);
            var car = new Car("car1");
            var ticket = parkingBoy.Parking(car);
            parkingBoy.PickUp(ticket);

            // when
            // then
            var parkingException = Assert.Throws<ParkingException>(() => parkingBoy.PickUp(ticket));
            Assert.Equal("Unrecognized parking ticket.", parkingException.Message);
        }

        [Fact]
        public void Should_can_not_parking_when_lot_is_full()
        {
            //given
            var paringLot = new ParkingLot(2);
            var parkingBoy = new ParkingBoy(paringLot);
            var car1 = new Car("car1");
            var car2 = new Car("car2");
            var car3 = new Car("car3");
            parkingBoy.Parking(car1);
            parkingBoy.Parking(car2);

            //when
            var lotFullException = Assert.Throws<LotFullException>(() => parkingBoy.Parking(car3));
            Assert.Equal("Not enough positions.", lotFullException.Message);
        }

        [Fact]
        public void Should_can_not_parking_when_lot_not_set_and_parking_10()
        {
            // given
            var paringLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(paringLot);
            var car = new Car("lastCar");

            for (var i = 0; i < 10; i++)
            {
                parkingBoy.Parking(new Car(i.ToString()));
            }

            // then
            var lotFullException = Assert.Throws<LotFullException>(() => parkingBoy.Parking(car));
            Assert.Equal("Not enough positions.", lotFullException.Message);
        }

        [Fact]
        public void Should_can_not_batch_parking_when_lot_is_full()
        {
            // given
            var paringLot = new ParkingLot(2);
            var parkingBoy = new ParkingBoy(paringLot);
            var car1 = new Car("car1");
            var car2 = new Car("car2");
            var car3 = new Car("car3");
            parkingBoy.Parking(car1);

            // when
            BatchParkingResponse parkingResult = parkingBoy.Parking(new List<Car>() { car2, car3 });

            // then
            Assert.False(parkingResult.IsSuccess);
            Assert.Equal(1, parkingResult.Tickets.Count);
            Assert.Equal("Not enough positions.", parkingResult.ErrorMessage);
        }

        [Fact]
        public void Should_parking_to_lot_2_when_parking_given_parking_boy_has_two_lot_and_lot1_is_full()
        {
            //given
            var lot1 = new ParkingLot(1);
            var lot2 = new ParkingLot(2);
            var parkingBoy = new ParkingBoy(new List<ParkingLot>() { lot1, lot2 });
            parkingBoy.Parking(new Car("car1"));
            var car = new Car("car2");
            //when
            var ticket = parkingBoy.Parking(car);
            //then
            Assert.Equal(car, lot2.PickUp(ticket));
        }

        [Fact]
        public void Should_can_parking_up_when_boy_has_two_lot_and_parking_to_lot2()
        {
            // given
            var lot1 = new ParkingLot(1);
            var lot2 = new ParkingLot(2);
            var parkingBoy = new ParkingBoy(new List<ParkingLot>() { lot1, lot2 });
            parkingBoy.Parking(new Car("car1"));
            var car = new Car("car2");
            var ticket = parkingBoy.Parking(car);

            // when
            var pickUp = parkingBoy.PickUp(ticket);

            // then
            Assert.Equal(car, pickUp);
        }

        [Fact]
        public void Should_can_bath_parking_given_boy_has_two_lot_and_one_is_over_size()
        {
            //given
            var lot1 = new ParkingLot(1);
            var lot2 = new ParkingLot(2);
            var parkingBoy = new ParkingBoy(new List<ParkingLot>() { lot1, lot2 });
            var car1 = new Car("car1");
            var car2 = new Car("car2");
            //when
            var response = parkingBoy.Parking(new List<Car>() { car1, car2 });
            //then
            Assert.Equal(car1, lot1.PickUp(response.Tickets[0]));
            Assert.Equal(car2, lot2.PickUp(response.Tickets[1]));
        }
    }
}