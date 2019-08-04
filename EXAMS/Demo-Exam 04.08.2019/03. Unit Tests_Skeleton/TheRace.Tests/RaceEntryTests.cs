namespace TheRace.Tests
{
    using NUnit.Framework;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class RaceEntryTests
    {
        private const string Name = "Pesho";
        private const string Model = "BMW";
        private const int HorsePower = 100;
        private const double CubicCentimeters = 75.0;
        private UnitMotorcycle testMotorcycle;
        private UnitRider testRider;
        private RaceEntry testRaceEntry;

        [SetUp]
        public void Setup()
        {
            testMotorcycle = new UnitMotorcycle(Model, HorsePower, CubicCentimeters);
            testRider = new UnitRider(Name, testMotorcycle);
            testRaceEntry = new RaceEntry();
        }

        [Test]
        public void TestConstructorUnitMotorcycleCreatesMotorCycle()
        {
            UnitMotorcycle motorcycle = new UnitMotorcycle(Model, HorsePower, CubicCentimeters);

            Assert.That(motorcycle != null);
            Assert.AreEqual(Model, motorcycle.Model);
            Assert.AreEqual(HorsePower, motorcycle.HorsePower);
            Assert.AreEqual(CubicCentimeters, motorcycle.CubicCentimeters);
        }

        [Test]
        public void TestConstructorUnitRiderCreatesRider()
        {
            UnitRider rider = new UnitRider(Name, testMotorcycle);

            Assert.That(rider != null);
            Assert.AreEqual(Name, rider.Name);
            Assert.AreEqual(testMotorcycle, rider.Motorcycle);
        }

        [Test]
        public void TestConstructorRaceEntryWorksCorrectly()
        {
            RaceEntry raceEntry = new RaceEntry();

            Assert.That(raceEntry != null);
            Assert.AreEqual(0, raceEntry.Counter);
        }

        [Test]
        public void TestRaceEntryShouldHavePrivateDictionaryOfRacers()
        {
            var fields = typeof(RaceEntry)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            var field = fields.First();

            Assert.AreEqual(field.FieldType, typeof(Dictionary<string, UnitRider>));
        }

        [Test]
        public void TestAddRiderWorksCorrectly()
        {
            string expectedResult = $"Rider {Name} added in race.";
            string actualResult =  testRaceEntry.AddRider(testRider);

            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(1, testRaceEntry.Counter);
        }

        [Test]
        public void TestAddNullRiderThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => testRaceEntry.AddRider(null));
        }

        [Test]
        public void TestAddAlreadyAddedRider()
        {
            testRaceEntry.AddRider(testRider);

            Assert.Throws<InvalidOperationException>(() => testRaceEntry.AddRider(testRider));
        }

        [Test]
        public void TestCalculateAverageHorsePowerThrowsExceptionWhenParticipantsBellowMin()
        {
            testRaceEntry.AddRider(testRider);

            Assert.Throws<InvalidOperationException>(() => testRaceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void TestCalculateAverageHorsePowerWorksCorrectly()
        {
            UnitMotorcycle moto1 = new UnitMotorcycle("A", 50, 100);
            UnitMotorcycle moto2 = new UnitMotorcycle("B", 100, 100);
            UnitMotorcycle moto3 = new UnitMotorcycle("C", 150, 100);
            
            UnitRider rider1 = new UnitRider("Pesho", moto1);
            UnitRider rider2 = new UnitRider("Gosho", moto2);
            UnitRider rider3 = new UnitRider("Ivan", moto3);

            testRaceEntry.AddRider(rider1);
            testRaceEntry.AddRider(rider2);
            testRaceEntry.AddRider(rider3);

            Assert.AreEqual(100, testRaceEntry.CalculateAverageHorsePower());
        }
    }
}