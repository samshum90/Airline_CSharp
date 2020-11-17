using System;
using System.Collections.Generic;

public class Passenger
{
    private string _name;

    private int 
        _noOfBags;

    private Flight _bookedFlight;

    private int _seat;
    public Passenger(string name, int noOfBags)
    {
        Name = name;
        NoOfBags = noOfBags;
    }

    public int NoOfBags { get => _noOfBags; set => _noOfBags = value; }
    public string Name { get => _name; set => _name = value; }
    public Flight BookedFlight { get => _bookedFlight; set => _bookedFlight = value; }
    public int Seat { get => _seat; set => _seat = value; }

    public void AddBags(int number)
    {
        NoOfBags = number;
    }

    public void ChangeName(string newName )
    {
        Name = newName;
    }
    
    public void BookFlight(Flight flight, int seat )
    {
        BookedFlight = flight;
        Seat = seat;
    }

}
