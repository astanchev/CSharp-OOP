namespace Service.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using System.Reflection;
    using Models.Contracts;
    using Models.Devices;
    using Models.Parts;

    public class DeviceTests
    {
        private const string makeTest = "IBM";
        
        private PropertyInfo[] properties;
        private MethodInfo[] methods;

        [SetUp]
        public void Setup()
        {
            this.properties = typeof(Device)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);

            this.methods = typeof(Device)
                .GetMethods(BindingFlags.Public | BindingFlags.Instance);
        }
        [Test]
        public void TestDeviceClassShouldBeAbstract()
        {
            Assert.IsTrue(typeof(Device).IsAbstract);
        }

        [Test]
        public void DeviceShouldHavePrivateListOfParts()
        {
            var fields = typeof(Device)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            var field = fields.Skip(1).First();

            Assert.AreEqual(field.FieldType, typeof(List<IPart>));
        }

        [Test]
        public void TestDeviceShouldHaveConstructor()
        {
            Type[] parameterTypes = new Type[] { typeof(string)};

            var constructor = typeof(Device)
                .GetConstructor(BindingFlags.NonPublic |  BindingFlags.Public | BindingFlags.Instance,
                    null, parameterTypes, null);

            Assert.IsTrue(constructor != null);
        }

        [Test]
        public void TestDeviceShouldHaveMakeProperty()
        {
            Assert.IsTrue(properties.Any(p => p.Name == "Make"));
        }

        [Test]
        public void TestDeviceMakePropertyShouldReturnString()
        {
            var part = properties.First(p => p.Name == "Make");

            Assert.IsTrue(part.PropertyType == typeof(string));
        }

        [Test]
        public void TestDeviceShouldHavePartsProperty()
        {
            Assert.IsTrue(properties.Any(p => p.Name == "Parts"));
        }

        [Test]
        public void TestDevicePartsPropertyShouldReturnIReadOnlyCollection()
        {
            var part = properties.First(p => p.Name == "Parts");

            Assert.IsTrue(part.PropertyType == typeof(IReadOnlyCollection<IPart>));
        }

        [Test]
        public void TestDeviceShouldHaveMethodAddPart()
        {
            Assert.IsTrue(methods.Any(m => m.Name == "AddPart"));
        }

        [Test]
        public void TestDeviceShouldHaveMethodRemovePart()
        {
            Assert.IsTrue(methods.Any(m => m.Name == "RemovePart"));
        }

        [Test]
        public void TestDeviceShouldHaveMethodRepairPart()
        {
            Assert.IsTrue(methods.Any(m => m.Name == "RepairPart"));
        }
        
        /// <summary>
        /// PC
        /// </summary>

        [Test]
        public void TestPCShouldHaveDeviceAsBaseClass()
        {
            Assert.IsTrue(typeof(PC).BaseType == typeof(Device));
        }
        
        [Test]
        public void TestPCShouldBeInstantiatedCorrectly()
        {
            IRepairable pc = new PC(makeTest);

            Assert.AreEqual(makeTest, pc.Make);
        }

        [Test]
        public void TestPCShouldNotHaveNullName()
        {
            Assert.Throws<ArgumentException>(() => new PC(null));
        }

        [Test]
        public void TestCollectionOfPartsShouldBeInstantiated()
        {
            IRepairable pc = new PC(makeTest);

            Assert.That(pc.Parts != null);
        }

        [Test]
        public void TestShouldBeAbleToAddPCPart()
        {
            IPart pcPart = new PCPart("CD", 10m);
            IRepairable pc = new PC(makeTest);

            pc.AddPart(pcPart);

            Assert.AreEqual(1, pc.Parts.Count);
        }

        [Test]
        public void TestShouldNotBeAbleToAddExistingPCPart()
        {
            IPart pcPart = new PCPart("CD", 10m);
            IRepairable pc = new PC(makeTest);

            pc.AddPart(pcPart);

            Assert.Throws<InvalidOperationException>(() => pc.AddPart(pcPart));
        }

        [Test]
        public void TestShouldNotBeAbleToAddNonPCPart()
        {
            IPart laptopPart = new LaptopPart("CD", 10m);
            IRepairable pc = new PC(makeTest);

            Assert.Throws<InvalidOperationException>(() => pc.AddPart(laptopPart));
        }

        [Test]
        public void TestRemoveCorrectlyPCPart()
        {
            IPart pcPart = new PCPart("CD", 10m);
            IRepairable pc = new PC(makeTest);

            pc.AddPart(pcPart);
            pc.RemovePart("CD");

            int expectedCount = 0;
            int actualCount = pc.Parts.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void TestRemovePCPartWithEmptyName()
        {
            IPart pcPart = new PCPart("CD", 10m);
            IRepairable pc = new PC(makeTest);

            pc.AddPart(pcPart);

            Assert.Throws<ArgumentException>(() =>
                pc.RemovePart(String.Empty));
        }

        [Test]
        public void TestRemoveNotExistingPCPart()
        {
            IPart pcPart = new PCPart("CD", 10m);
            IPart pcPart2 = new PCPart("HDD", 100m);
            IRepairable pc = new PC(makeTest);

            pc.AddPart(pcPart);

            Assert.Throws<InvalidOperationException>(() =>
                pc.RemovePart("HDD"));
        }

        [Test]
        public void TestCorrectlyRepairPCPart()
        {
            IPart pcPart = new PCPart("CD", 10m, true);
            IRepairable pc = new PC(makeTest);

            pc.AddPart(pcPart);
            pc.RepairPart("CD");

            bool expectedIsBroken = false;
            bool actualIsBroken = pc.Parts.First(p => p.Name == "CD").IsBroken;

            Assert.AreEqual(expectedIsBroken, actualIsBroken);
        }

        [Test]
        public void TestRepairPCPartWithEmptyName()
        {
            IPart pcPart = new PCPart("CD", 10m, true);
            IRepairable pc = new PC(makeTest);

            pc.AddPart(pcPart);

            Assert.Throws<ArgumentException>(() => pc.RepairPart(String.Empty));
        }

        [Test]
        public void TestRepairPCPartWithNotExistingPCPart()
        {
            IPart pcPart = new PCPart("CD", 10m);
            IPart pcPart2 = new PCPart("HDD", 100m);
            IRepairable pc = new PC(makeTest);

            pc.AddPart(pcPart);

            Assert.Throws<InvalidOperationException>(() => pc.RepairPart("HDD"));
        }

        [Test]
        public void TestRepairNotBrokenPCPart()
        {
            IPart pcPart = new PCPart("CD", 10m, false);
            IRepairable pc = new PC(makeTest);

            pc.AddPart(pcPart);
            
            Assert.Throws<InvalidOperationException>(() => pc.RepairPart("CD"));
        }

        /// <summary>
        ///Laptop 
        /// </summary>
        
        [Test]
        public void TestLaptopShouldHaveDeviceAsBaseClass()
        {
            Assert.IsTrue(typeof(Laptop).BaseType == typeof(Device));
        }
        
        [Test]
        public void TestLaptopShouldBeInstantiatedCorrectly()
        {
            IRepairable laptop = new Laptop(makeTest);

            Assert.AreEqual(makeTest, laptop.Make);
        }

        [Test]
        public void TestLaptopShouldNotHaveNullName()
        {
            Assert.Throws<ArgumentException>(() => new Laptop(null));
        }

        [Test]
        public void TestCollectionOfLaptopPartsShouldBeInstantiated()
        {
            IRepairable laptop = new Laptop(makeTest);

            Assert.That(laptop.Parts != null);
        }

        [Test]
        public void TestShouldBeAbleToAddLaptopPart()
        {
            IPart laptopPart = new LaptopPart("CD", 10m);
            IRepairable laptop = new Laptop(makeTest);

            laptop.AddPart(laptopPart);

            Assert.AreEqual(1, laptop.Parts.Count);
        }

        [Test]
        public void TestShouldNotBeAbleToAddExistingLaptopPart()
        {
            IPart laptopPart = new LaptopPart("CD", 10m);
            IRepairable laptop = new Laptop(makeTest);

            laptop.AddPart(laptopPart);

            Assert.Throws<InvalidOperationException>(() => laptop.AddPart(laptopPart));
        }

        [Test]
        public void TestShouldNotBeAbleToAddNonLaptopPart()
        {
            IPart pcPart = new PCPart("CD", 10m);
            IRepairable laptop = new Laptop(makeTest);

            Assert.Throws<InvalidOperationException>(() => laptop.AddPart(pcPart));
        }

        [Test]
        public void TestRemoveCorrectlyLaptopPart()
        {
            IPart laptopPart = new LaptopPart("CD", 10m);
            IRepairable laptop = new Laptop(makeTest);

            laptop.AddPart(laptopPart);
            laptop.RemovePart("CD");

            int expectedCount = 0;
            int actualCount = laptop.Parts.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void TestRemoveLaptopPartWithEmptyName()
        {
            IPart laptopPart = new LaptopPart("CD", 10m);
            IRepairable laptop = new Laptop(makeTest);

            laptop.AddPart(laptopPart);

            Assert.Throws<ArgumentException>(() => laptop.RemovePart(String.Empty));
        }

        [Test]
        public void TestRemoveNotExistingLaptopPart()
        {
            IPart laptopPart = new LaptopPart("CD", 10m);
            IPart laptopPart2 = new LaptopPart("HDD", 100m);
            IRepairable laptop = new Laptop(makeTest);

            laptop.AddPart(laptopPart);

            Assert.Throws<InvalidOperationException>(() =>
                laptop.RemovePart("HDD"));
        }

        [Test]
        public void TestCorrectlyRepairLaptopPart()
        {
            IPart laptopPart = new LaptopPart("CD", 10m, true);
            IRepairable laptop = new Laptop(makeTest);

            laptop.AddPart(laptopPart);
            laptop.RepairPart("CD");

            bool expectedIsBroken = false;
            bool actualIsBroken = laptop.Parts.First(p => p.Name == "CD").IsBroken;

            Assert.AreEqual(expectedIsBroken, actualIsBroken);
        }

        [Test]
        public void TestRepairLaptopPartWithEmptyName()
        {
            IPart laptopPart = new LaptopPart("CD", 10m, true);
            IRepairable laptop = new Laptop(makeTest);

            laptop.AddPart(laptopPart);

            Assert.Throws<ArgumentException>(() => laptop.RepairPart(String.Empty));
        }

        [Test]
        public void TestRepairLaptopPartWithNotExistingPCPart()
        {
            IPart laptopPart = new LaptopPart("CD", 10m);
            IPart laptopPart2 = new LaptopPart("HDD", 100m);
            IRepairable laptop = new Laptop(makeTest);

            laptop.AddPart(laptopPart);

            Assert.Throws<InvalidOperationException>(() => laptop.RepairPart("HDD"));
        }

        [Test]
        public void TestRepairNotBrokenLaptopPart()
        {
            IPart laptopPart = new LaptopPart("CD", 10m, false);
            IRepairable laptop = new Laptop(makeTest);

            laptop.AddPart(laptopPart);
            
            Assert.Throws<InvalidOperationException>(() => laptop.RepairPart("CD"));
        }

        /// <summary>
        /// Phone
        /// </summary>

        [Test]
        public void TestPhoneShouldHaveDeviceAsBaseClass()
        {
            Assert.IsTrue(typeof(Phone).BaseType == typeof(Device));
        }
        
        [Test]
        public void TestPhoneShouldBeInstantiatedCorrectly()
        {
            IRepairable phone = new Phone(makeTest);

            Assert.AreEqual(makeTest, phone.Make);
        }

        [Test]
        public void TestPhoneShouldNotHaveNullName()
        {
            Assert.Throws<ArgumentException>(() => new Phone(null));
        }

        [Test]
        public void TestCollectionOfPhonePartsShouldBeInstantiated()
        {
            IRepairable phone = new Phone(makeTest);

            Assert.That(phone.Parts != null);
        }

        [Test]
        public void TestShouldBeAbleToAddPhonePart()
        {
            IPart phonePart = new PhonePart("CD", 10m);
            IRepairable phone = new Phone(makeTest);

            phone.AddPart(phonePart);

            Assert.AreEqual(1, phone.Parts.Count);
        }

        [Test]
        public void TestShouldNotBeAbleToAddExistingPhonePart()
        {
            IPart phonePart = new PhonePart("CD", 10m);
            IRepairable phone = new Phone(makeTest);

            phone.AddPart(phonePart);

            Assert.Throws<InvalidOperationException>(() => phone.AddPart(phonePart));
        }

        [Test]
        public void TestShouldNotBeAbleToAddNonPhonePart()
        {
            IPart pcPart = new PCPart("CD", 10m);
            IRepairable phone = new Phone(makeTest);

            Assert.Throws<InvalidOperationException>(() => phone.AddPart(pcPart));
        }

        [Test]
        public void TestRemoveCorrectlyPhonePart()
        {
            IPart phonePart = new PhonePart("CD", 10m);
            IRepairable phone = new Phone(makeTest);

            phone.AddPart(phonePart);
            phone.RemovePart("CD");

            int expectedCount = 0;
            int actualCount = phone.Parts.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void TestRemovePhonePartWithEmptyName()
        {
            IPart phonePart = new PhonePart("CD", 10m);
            IRepairable phone = new Phone(makeTest);

            phone.AddPart(phonePart);

            Assert.Throws<ArgumentException>(() => phone.RemovePart(String.Empty));
        }

        [Test]
        public void TestRemoveNotExistingPhonePart()
        {
            IPart phonePart = new PhonePart("CD", 10m);
            IPart phonePart2 = new PhonePart("HDD", 100m);
            IRepairable phone = new Phone(makeTest);

            phone.AddPart(phonePart);

            Assert.Throws<InvalidOperationException>(() =>
                phone.RemovePart("HDD"));
        }

        [Test]
        public void TestCorrectlyRepairPhonePart()
        {
            IPart phonePart = new PhonePart("CD", 10m, true);
            IRepairable phone = new Phone(makeTest);

            phone.AddPart(phonePart);
            phone.RepairPart("CD");

            bool expectedIsBroken = false;
            bool actualIsBroken = phone.Parts.First(p => p.Name == "CD").IsBroken;

            Assert.AreEqual(expectedIsBroken, actualIsBroken);
        }

        [Test]
        public void TestRepairPhonePartWithEmptyName()
        {
            IPart phonePart = new PhonePart("CD", 10m, true);
            IRepairable phone = new Phone(makeTest);

            phone.AddPart(phonePart);

            Assert.Throws<ArgumentException>(() => phone.RepairPart(String.Empty));
        }

        [Test]
        public void TestRepairPhonePartWithNotExistingPCPart()
        {
            IPart phonePart = new PhonePart("CD", 10m);
            IPart phonePart2 = new PhonePart("HDD", 100m);
            IRepairable phone = new Phone(makeTest);

            phone.AddPart(phonePart);

            Assert.Throws<InvalidOperationException>(() => phone.RepairPart("HDD"));
        }

        [Test]
        public void TestRepairNotBrokenPhonePart()
        {
            IPart phonePart = new PhonePart("CD", 10m, false);
            IRepairable phone = new Phone(makeTest);

            phone.AddPart(phonePart);
            
            Assert.Throws<InvalidOperationException>(() => phone.RepairPart("CD"));
        }
    }
}
