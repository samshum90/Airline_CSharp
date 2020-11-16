using System.Collections.Generic;

public class Flight
{
	private List<Passenger> BookedPassengers;
	private Plane _plane;
	private string _flightNumber;
	private string _destination;
	private string _departure;
	private string _departureTime;

	public Flight()
	{
		BookedPassengers = new List<Passenger>();
	}

    public Flight(Plane plane, string flightNumber, string destination, string departure, string departureTime)
			: this()
	{
		_plane = plane;
		_flightNumber = flightNumber;
        _destination = destination;
        _departure = departure;
        _departureTime = departureTime;
    }

    public string FlightNumber { get => _flightNumber; set => _flightNumber = value; }
	public string Destination { get => _destination; set => _destination = value; }
	public string Departure { get => _departure; set => _departure = value; }
	public string DepartureTime { get => _departureTime; set => _departureTime = value; }
    public Plane Plane { get => _plane; set => _plane = value; }

	public int BookedCount()
	{
		return this.BookedPassengers.Count;
	}

	public int AvailableSeats()
    {
		return Plane.Capacity - BookedCount(); 
    }

	public void BookPassenger(Passenger passenger)
    {
		BookedPassengers.Add(passenger);
    }
}
