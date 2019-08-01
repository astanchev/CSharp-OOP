namespace Tests
{
    using System;
    using NUnit.Framework;

    using CarManager;

    public class CarTests
    {
        private const string make = "Opel";
        private const string model = "Corsa";
        private const double fuelConsumption = 10.0;
        private const double fuelCapacity = 50.0;
        private const double fuelAmount = 0.0;
        private Car testCar;


        [SetUp]
        public void Setup()
        {
            testCar = new Car(make, model, fuelConsumption, fuelCapacity);
        }

        [Test]
        public void TestConstructorShouldCreateCar()
        {
            Car newCar = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.IsTrue(newCar != null);
        }

        [Test]
        public void TestMakeShouldReturnMakeofCar()
        {
            string expectedResult = make;
            string actualResult = this.testCar.Make;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestCarShouldNotBeCreatedWithNullMake()
        {
            Assert.Throws<ArgumentException>(() => new Car(null, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void TestModelShouldReturnModelOfCar()
        {
            string expectedResult = model;
            string actualResult = this.testCar.Model;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestCarShouldNotBeCreatedWithNullModel()
        {
            Assert.Throws<ArgumentException>(() => new Car(make, null, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void TestFuelConsumptionShouldReturnFuelConsumptionOfCar()
        {
            double expectedResult = fuelConsumption;
            double actualResult = this.testCar.FuelConsumption;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestCarShouldNotBeCreatedWithZeroOrNegativeFuelConsumption()
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, 0, fuelCapacity));
        }

        [Test]
        public void TestFuelAmountShouldReturnFuelAmountOfCar()
        {
            double expectedResult = fuelAmount;
            double actualResult = this.testCar.FuelAmount;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestFuelCapacityShouldReturnFuelCapacityOfCar()
        {
            double expectedResult = fuelCapacity;
            double actualResult = this.testCar.FuelCapacity;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestCarShouldNotBeCreatedWithZeroOrNegativeFuelCapacity()
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, 0));
        }
        
        [Test]
        public void TestCarShouldNotBeRefueledWithNegativeFuel()
        {
            Assert.Throws<ArgumentException>(() => testCar.Refuel(-10));
        }

        [Test]
        public void TestCarShouldNotBeRefueledWithZeroFuel()
        {
            Assert.Throws<ArgumentException>(() => testCar.Refuel(0));
        }

        [Test]
        public void TestRefuelShouldWorkCorrectly()
        {
            testCar.Refuel(40);

            double expectedResult = fuelAmount + 40;
            double actualResult = this.testCar.FuelAmount;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestRefuelWithMoreThanCapacityReturnsCapacity()
        {
            testCar.Refuel(60);

            double expectedResult = fuelCapacity;
            double actualResult = this.testCar.FuelAmount;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestCarShouldDriveCorrectlyAffordableDistance()
        {
            testCar.Refuel(50);
            testCar.Drive(100);

            double expectedResult = 40;
            double actualResult = this.testCar.FuelAmount;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestCarShouldThrowExceptionDrivingNotAffordableDistance()
        {
            Assert.Throws<InvalidOperationException>(() => testCar.Drive(100));
        }

    }
}