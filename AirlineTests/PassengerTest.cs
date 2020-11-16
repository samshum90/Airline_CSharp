using Airline;
using NUnit.Framework;

namespace AirlineTests
{
    [TestFixture]
    public class PassengerTest
    {
        private Passenger pass1;

        [SetUp]
        public void Setup()
        {
            pass1 = new Passenger("Alice", 0);
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


    }
}