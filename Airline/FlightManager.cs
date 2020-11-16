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
}
