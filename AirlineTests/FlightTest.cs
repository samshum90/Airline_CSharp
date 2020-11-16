using Airline;
using NUnit.Framework;

namespace AirlineTests
{
    [TestFixture]
    public class FlightTest
    {
        private Plane DouglasMD80;
        private Plane Cessina;
        private Plane Boeing747;
        private Flight BA213;
        private Passenger pass1;

        [SetUp]
        public void Setup()
        {
            DouglasMD80 = new Plane("DouglasMD80", 2, 10);
            Cessina = new Plane("Cessina", 6, 400);
            Boeing747 = new Plane("Boeing747", 100, 500);
            pass1 = new Passenger("Alice", 0);
            BA213 = new Flight( DouglasMD80, "BA213", "LON", "EDI", "18:00");
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
            BA213.DepartureTime = "19:00";
            Assert.AreEqual("19:00", BA213.DepartureTime);
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
        public void BookPassengerTest()
        {
            BA213.BookPassenger(pass1);
            Assert.AreEqual(1, BA213.AvailableSeats());
            Assert.AreEqual(1, BA213.BookedCount());
        }

    }
}