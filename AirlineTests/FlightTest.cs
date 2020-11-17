using Airline;
using NUnit.Framework;
using System;

namespace AirlineTests
{
    [TestFixture]
    public class FlightTest
    {
        private Plane DouglasMD80;
        private Plane Cessina;
        private Plane Boeing747;
        private Flight BA213;
        private Flight BA214;
        private Passenger pass1;
        private Passenger pass2;
        private Passenger pass3;
        private Passenger pass4;
        private Passenger pass5;
        private Passenger pass6;
        private TimeSpan BA213Time;
        private TimeSpan BA213UpdatedTime;

        [SetUp]
        public void Setup()
        {
            DouglasMD80 = new Plane("DouglasMD80", 2, 10);
            Cessina = new Plane("Cessina", 6, 400);
            Boeing747 = new Plane("Boeing747", 100, 500);
            pass1 = new Passenger("Alice", 2);
            pass2 = new Passenger("John", 3);
            pass3 = new Passenger("Timmy", 4);
            pass4 = new Passenger("Stan", 10);
            pass5 = new Passenger("Jenny", 6);
            pass6 = new Passenger("Sophia", 4);
            BA213Time = new TimeSpan(19, 00, 00);
            BA213UpdatedTime = new TimeSpan(20, 00, 00);
            BA213 = new Flight( DouglasMD80, "BA213", "LON", "EDI", BA213Time);
            BA214 = new Flight(Cessina, "BA214", "ABR", "MAN", BA213Time);
        }

        [Test]
        public void getPlaneTest()
        {
            Assert.AreEqual(DouglasMD80, BA213.Plane);
        }

        [Test]
        public void setPlaneTest()
        {
            BA213.Plane = Cessina;
            Assert.AreEqual(Cessina, BA213.Plane);
        }       
        
        [Test]
        public void getAndSetFlightNumberTest()
        {
            BA213.FlightNumber = "BA212";
            Assert.AreEqual("BA212", BA213.FlightNumber);
        }     
        
        [Test]
        public void getAndSetDestinationTest()
        {
            BA213.Destination = "MAN";
            Assert.AreEqual("MAN", BA213.Destination);
        }  
        
        [Test]
        public void getAndSetDepartureTest()
        {
            BA213.Departure = "ABR";
            Assert.AreEqual("ABR", BA213.Departure);
        }       
        
        [Test]
        public void getAndSetTimeTest()
        {
            BA213.DepartureTime = BA213UpdatedTime;
            Assert.AreEqual(BA213UpdatedTime, BA213.DepartureTime);
        }

        [Test]
        public void getBookedCountTest()
        {
            Assert.AreEqual(0, BA213.BookedCount());
        }    
        
        [Test]
        public void getAvailableSeatsTest()
        {
            Assert.AreEqual(2, BA213.AvailableSeats());
        }       
        [Test]
        public void getOneAvailableSeatsTest()
        {
            BA213.BookPassenger(pass1);
            Assert.AreEqual(1, BA213.AvailableSeats());
        }        
        
        [Test]
        public void getTwoAvailableSeatsTest()
        {
            BA213.BookPassenger(pass1);
            BA213.BookPassenger(pass2);
            Assert.AreEqual(0, BA213.AvailableSeats());
        }

        [Test]
        public void getCapacityTest()
        {
            Assert.AreEqual(2, BA213.Capacity());
        }

        [Test]
        public void BookPassengerTest()
        {
            BA213.BookPassenger(pass1);
            Assert.AreEqual(1, BA213.AvailableSeats());
            Assert.AreEqual(1, BA213.BookedCount());
        }        
        
        [Test]
        public void FullPassengersTest()
        {
            BA213.BookPassenger(pass1);
            BA213.BookPassenger(pass2);
            BA213.BookPassenger(pass3); 
            Assert.AreEqual(2, BA213.BookedCount());
            Assert.AreEqual(0, BA213.AvailableSeats());
        }

        [Test]
        public void getTotalWeightTest()
        {
            Assert.AreEqual(10, BA213.FlightTotalWeight());
        }

        [Test]
        public void PassengersBaggageWeightTest()
        {
            BA213.BookPassenger(pass1);
            BA213.BookPassenger(pass2);
            Assert.AreEqual(5, BA213.PassengerBaggageWeight());
        }     
        
        [Test]
        public void BookPassengerWithSeatTest()
        {
            BA213.BookPassengerWithSeat(pass1, 1);
            BA213.BookPassengerWithSeat(pass2, 0);
            BA213.BookPassengerWithSeat(pass3, 2);
            Assert.AreEqual(2, BA213.BookedCount());
            Assert.AreEqual(1, pass1.Seat);
            Assert.AreEqual(0, pass2.Seat);
        }     
        
        [Test]
        public void FalseBookPassengerWithSeatandAvailablityCheckTest()
        {
            BA213.BookPassengerWithSeat(pass1, 1);
            Assert.IsFalse(BA213.SeatAvailabilityCheck(1));
        }   
        
        [Test]
        public void TrueBookPassengerWithSeatandAvailablityCheckTest()
        {
            Assert.IsTrue(BA213.SeatAvailabilityCheck(1));
        }  
        
        [Test]
        public void getBookedPassengersTest()
        {
            BA213.BookPassenger(pass1);

            Passenger[] expected = { pass1 };
            Assert.AreEqual(expected, BA213.BookedPassengers);
        }         
        
        [Test]
        public void BubbleSortPassengerSeatsTest()
        {
            BA214.BookPassengerWithSeat(pass1, 5);
            BA214.BookPassengerWithSeat(pass2, 4);
            BA214.BookPassengerWithSeat(pass3, 3);  
            BA214.BookPassengerWithSeat(pass4, 2);
            BA214.BookPassengerWithSeat(pass5, 0);
            BA214.BookPassengerWithSeat(pass6, 1);
            BA214.BubbleSortSeats();
            Passenger[] expected = { pass5, pass6, pass4, pass3, pass2, pass1};

            Assert.AreEqual(expected, BA214.BookedPassengers);
        }       
        
        [Test]
        public void BinarySearchPassengerSeatTest()
        {
            BA214.BookPassengerWithSeat(pass1, 5);
            BA214.BookPassengerWithSeat(pass2, 4);
            BA214.BookPassengerWithSeat(pass3, 3);  
            BA214.BookPassengerWithSeat(pass4, 2);
            BA214.BookPassengerWithSeat(pass5, 0);
            BA214.BookPassengerWithSeat(pass6, 1);

            Assert.AreEqual(pass3, BA214.BinarySearchSeat(3));
        }  

    }
}