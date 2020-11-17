using System;
using System.Collections.Generic;

public class Flight
{
	private List<Passenger> _bookedPassengers;
	private Plane _plane;
	private string _flightNumber;
	private string _destination;
	private string _departure;
	private TimeSpan _departureTime;

	public Flight()
	{
		BookedPassengers = new List<Passenger>();
	}

	public Flight(Plane plane, string flightNumber, string destination, string departure, TimeSpan departureTime)
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
	public TimeSpan DepartureTime { get => _departureTime; set => _departureTime = value; }
	public Plane Plane { get => _plane; set => _plane = value; }
	public List<Passenger> BookedPassengers { get => _bookedPassengers; set => _bookedPassengers = value; }

	public int BookedCount()
	{
		return BookedPassengers.Count;
	}

	public int Capacity()
	{
		return Plane.Capacity;
	}

	public int FlightTotalWeight()
	{
		return Plane.TotalWeight;
	}

	public int AvailableSeats()
	{
		return Capacity() - BookedCount();
	}

	public void BookPassenger(Passenger passenger)
	{
		if (BookedCount() <= AvailableSeats())
		{
			BookedPassengers.Add(passenger);
		}
	}
	public void BookPassengerWithSeat(Passenger passenger, int seatNumber)
	{
		if (AvailableSeats() > 0)
		{
			BookedPassengers.Add(passenger);
			passenger.Seat = seatNumber;
		}
	}

	public int PassengerBaggageWeight()
	{
		var total = 0;
		foreach (Passenger passenger in BookedPassengers)
		{
			total += passenger.NoOfBags;
		}

		return total;
	}

	public bool SeatAvailabilityCheck(int seatNumber)
	{
		foreach (Passenger passenger in BookedPassengers)
		{
			if (passenger.Seat == seatNumber)
				return false;
		}

		return true;
	}

	public void BubbleSortSeats()
	{
		Passenger t;
		for (int p = 0; p <= BookedPassengers.Count - 2; p++)
		{
			for (int i = 0; i <= BookedPassengers.Count - 2; i++)
			{
				if (BookedPassengers[i].Seat > BookedPassengers[i + 1].Seat)
				{
					t = BookedPassengers[i + 1];
					BookedPassengers[i + 1] = BookedPassengers[i];
					BookedPassengers[i] = t;

				}
			}
		}

	}

    public Passenger BinarySearchSeat(int seatNumber)
	{
		BubbleSortSeats();
		int minNum = 0;
		int maxNum = BookedPassengers.Count - 1;

		while (minNum <= maxNum)
		{
			int mid = (minNum + maxNum) / 2;
			if (seatNumber == BookedPassengers[mid].Seat)
			{
				return BookedPassengers[mid];
			}
			else if (seatNumber < BookedPassengers[mid].Seat)
			{
				maxNum = mid - 1;
			}
			else
			{
				minNum = mid + 1;
			}
		}
		return null;
	}

}
