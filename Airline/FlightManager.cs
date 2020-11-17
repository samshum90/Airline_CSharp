using System;

public class FlightManager
{
    private Flight _flight;

    public FlightManager(Flight flight)
    {
        this._flight = flight;
    }

    public Flight Flight { get => _flight; set => _flight = value; }

    public int BaggagePerPassenger()
    {
        return Flight.FlightTotalWeight() / Flight.Capacity() ;
    }

    public int BookedBaggageWeight()
    {
        return Flight.PassengerBaggageWeight();
    }

    public int RemainingWeight()
    {
        return Flight.FlightTotalWeight() - Flight.PassengerBaggageWeight();
    }
    
    public int PassengersBooked()
    {
        return Flight.BookedCount();
    }       
    
    public int FlightCapacity()
    {
        return Flight.Capacity();
    }

    public void BookPassenger(Passenger passenger, int seatNumber)
    {
        Flight.BookPassenger(passenger);
        passenger.BookFlight(Flight, seatNumber);
    }

    public void BookPassengerRandomSeat(Passenger passenger)
    {
        if (Flight.BookedCount() <= Flight.AvailableSeats())
        {
            Random r = new Random();
            int randomSeatNumber = r.Next(0, FlightCapacity());
            while (!Flight.SeatAvailabilityCheck(randomSeatNumber))
                randomSeatNumber = r.Next(0, FlightCapacity());

            Flight.BookPassenger(passenger);
            passenger.BookFlight(Flight, randomSeatNumber);
        }
    }
}
