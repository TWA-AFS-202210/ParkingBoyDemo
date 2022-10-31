namespace ParkingLotDemoTest;

using ParkingLotDemo;
using Xunit;

public class SmartParkingBoyTest
{
    [Fact]
    public void
        Should_parking_to_lot_2_when_parking_given_smart_parking_boy_has_two_lot_and_lot1_has_1_position_and_lot2_has_2position()
    {
        // given
        var lot1 = new ParkingLot(2);
        var lot2 = new ParkingLot(2);
        var parkingBoy = new SmartParkingBoy(new List<ParkingLot>() { lot1, lot2 });
        parkingBoy.Parking(new Car("car1"));
        var car = new Car("car2");

        // when
        var ticket = parkingBoy.Parking(car);

        // then
        Assert.Equal(car, lot2.PickUp(ticket));
    }

    [Fact]
    public void
        Should_batch_parking_to_lot_2_when_parking_given_smart_parking_boy_has_two_lot_and_lot1_has_1_position_and_lot2_has_2position()
    {
        // given
        var lot1 = new ParkingLot(2);
        var lot2 = new ParkingLot(3);
        var parkingBoy = new SmartParkingBoy(new List<ParkingLot>() { lot1, lot2 });
        var car1 = new Car("car1");
        var car2 = new Car("car2");

        // when
        var response = parkingBoy.Parking(new List<Car>() { car1, car2 });

        // then
        Assert.Equal(car1, lot2.PickUp(response.Tickets[0]));
        Assert.Equal(car2, lot1.PickUp(response.Tickets[1]));
    }
}