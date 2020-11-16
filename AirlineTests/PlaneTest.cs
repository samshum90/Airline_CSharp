using Airline;
using NUnit.Framework;

namespace AirlineTests
{
    [TestFixture]
    public class PlaneTest
    {
        private Plane DouglasMD80;
        private Plane Cessina;
        private Plane Boeing747;

        [SetUp]
        public void Setup()
        {

            DouglasMD80 = new Plane("DouglasMD80", 2, 10);
            Cessina = new Plane("Cessina", 6, 400);
            DouglasMD80 = new Plane("Boeing747", 100, 500);

        }

        [Test]
        public void getTypeSetTypeTest()
        {
            DouglasMD80.Type = "DouglasMD70";
            Assert.AreEqual("DouglasMD70", DouglasMD80.Type);
        }

        [Test]
        public void getCapacitySetCapacityTest()
        {
            DouglasMD80.Capacity = 4;
            Assert.AreEqual(4, DouglasMD80.Capacity);
        }

        [Test]
        public void getTotalWeightSetTotalWeightTest()
        {
            DouglasMD80.TotalWeight = 40;
            Assert.AreEqual(40, DouglasMD80.TotalWeight);
        }


    }
}