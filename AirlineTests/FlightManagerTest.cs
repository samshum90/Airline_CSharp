using NUnit.Framework;
using System;

namespace AirlineTests
{
    [TestFixture]
    public class FlightManagerTest
    {
        private Plane DouglasMD80;
        private Plane Cessina;
        private Plane Boeing747;
        private Flight BA213;
        private Passenger pass1;
        private Passenger pass2;
        private Passenger pass3;
        private FlightManager Flight1;
        private TimeSpan BA213Time;

        [SetUp]
        public void Setup()
        {
            DouglasMD80 = new Plane("DouglasMD80", 2, 10);
            Cessina = new Plane("Cessina", 6, 400);
            Boeing747 = new Plane("Boeing747", 100, 500);
            pass1 = new Passenger("Alice", 2);
            pass2 = new Passenger("John", 3);
            pass3 = new Passenger("Timmy", 4);
            BA213Time = new TimeSpan(18, 00, 00);
            BA213 = new Flight(DouglasMD80, "BA213", "LON", "EDI", BA213Time);
            Flight1 = new FlightManager(BA213);
        }

        [Test]
        public void calculateReservedBaggageWeightPerPassengerTest()
        {
            Assert.AreEqual(5, Flight1.BaggagePerPassenger());
        }    
        
        [Test]
        public void calculateBookedBaggageWeightTest()
        {
            BA213.BookPassenger(pass1);
            BA213.BookPassenger(pass2);
            Assert.AreEqual(5, Flight1.BookedBaggageWeight());
        }
        
        [Test]
        public void calculateRemainingBaggageWeightTest()
        {
            BA213.BookPassenger(pass1);
            BA213.BookPassenger(pass2);
            Assert.AreEqual(5, Flight1.RemainingWeight());
        }     
        
        [Test]
        public void PassengersBookedTest()
        {
            Flight1.BookPassenger(pass1, 1);
            Assert.AreEqual(1, Flight1.PassengersBooked());
        }     
        
        [Test]
        public void BookPassengerOntoFlightTest()
        {
            Flight1.BookPassenger(pass1, 1);
            Assert.AreEqual(1, Flight1.PassengersBooked());
            Assert.AreEqual(BA213, pass1.BookedFlight);            Assert.AreEqual(BA213, pass1.BookedFlight);
            Assert.AreEqual(1, pass1.Seat); 
        }       
        
        [Test]
        public void BookPassengerOntoFlightWithRandomSeatsTest()
        {
            Flight1.BookPassengerRandomSeat(pass1);
            Flight1.BookPassengerRandomSeat(pass2);
            Assert.AreEqual(2, Flight1.PassengersBooked());
            Assert.AreEqual(BA213, pass1.BookedFlight);   
            Assert.AreEqual(BA213, pass2.BookedFlight);
        }

    }
}