using Airline;
using NUnit.Framework;
using System;

namespace AirlineTests
{
    [TestFixture]
    public class PassengerTest
    {
        private Passenger pass1;
        private Plane DouglasMD80;
        private TimeSpan BA213Time;
        private Flight BA213;

        [SetUp]
        public void Setup()
        {
            pass1 = new Passenger("Alice", 0);
            DouglasMD80 = new Plane("DouglasMD80", 2, 10);
            BA213Time = new TimeSpan(19, 00, 00);
            BA213 = new Flight(DouglasMD80, "BA213", "LON", "EDI", BA213Time);

        }

        [Test]
        public void getNameSetNameTest ()
        {
            pass1.Name = "John";
            var expected = "John";
            Assert.AreEqual(expected, pass1.Name);
        }       
        
        [Test]
        public void getBagsSetbagsTest ()
        {
            pass1.NoOfBags = 2;
            var expected = 2;
            Assert.AreEqual(expected, pass1.NoOfBags);
        }

        [Test]
        public void addBagsTest()
        {
            pass1.AddBags(1);
            Assert.AreEqual(1, pass1.NoOfBags);
        }
        
        [Test]
        public void changeNameTest()
        {
            pass1.ChangeName("Jenny");
            Assert.AreEqual("Jenny", pass1.Name);
        }

        [Test]
        public void BookFlightTest()
        {
            pass1.BookFlight(BA213, 21);
            Assert.AreEqual(BA213, pass1.BookedFlight);
            Assert.AreEqual(21, pass1.Seat);
        }
    }
}