namespace Tests
{
    using System;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;
    using Service.Models.Contracts;
    using Service.Models.Parts;

    public class PartTests
    {
        private const decimal multiplierPCPart = 1.2m;
        private const decimal multiplierLaptopPart = 1.5m;
        private const decimal multiplierPhonePart = 1.3m;

        private PropertyInfo[] properties;
        private MethodInfo[] methods;

        private const string PartName = "HDD";
        private const decimal PartCost = 10.0m;
        private const bool PartIsBroken = true;
        

        [SetUp]
        public void Setup()
        {
            this.properties = typeof(Part)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);

            this.methods = typeof(Part)
                .GetMethods(BindingFlags.Public | BindingFlags.Instance);
        }

        [Test]
        public void TestPartClassShouldBeAbstract()
        {
            Assert.IsTrue(typeof(Part).IsAbstract);
        }

        [Test]
        public void TestPartShouldHaveConstructor()
        {
            Type[] parameterTypes = new Type[] { typeof(string), typeof(decimal), typeof(bool)};

            var constructor = typeof(Part)
                .GetConstructor(BindingFlags.NonPublic |  BindingFlags.Public | BindingFlags.Instance,
                    null, parameterTypes, null);

            Assert.IsTrue(constructor != null);
        }

        [Test]
        public void TestPartShouldHaveNameProperty()
        {
            Assert.IsTrue(properties.Any(p => p.Name == "Name"));
        }

        [Test]
        public void TestPartShouldHaveCostProperty()
        {
            Assert.IsTrue(properties.Any(p => p.Name == "Cost"));
        }

        [Test]
        public void TestPartShouldHaveIsBrokenProperty()
        {
            Assert.IsTrue(properties.Any(p => p.Name == "IsBroken"));
        }

        [Test]
        public void TestPartNamePropertyShouldReturnString()
        {
            var part = properties.First(p => p.Name == "Name");

            Assert.IsTrue(part.PropertyType == typeof(string));
        }

        [Test]
        public void TestPartCostPropertyShouldReturnDecimal()
        {
            var part = properties.First(p => p.Name == "Cost");

            Assert.IsTrue(part.PropertyType == typeof(decimal));
        }

        [Test]
        public void TestPartIsBrokenPropertyShouldReturnBool()
        {
            var part = properties.First(p => p.Name == "IsBroken");

            Assert.IsTrue(part.PropertyType == typeof(bool));
        }

        [Test]
        public void TestPartShouldHaveMethodRepair()
        {
            Assert.IsTrue(methods.Any(m => m.Name == "Repair"));
        }

        [Test]
        public void TestPartShouldHaveMethodReport()
        {
            Assert.IsTrue(methods.Any(m => m.Name == "Report"));
        }

        [Test]
        public void TestPartMethodReportShouldReturnString()
        {
            var partMethod = methods.First(m => m.Name == "Report");

            Assert.IsTrue(partMethod.ReturnType == typeof(string));
        }

        /// <summary>
        /// PCPart
        /// </summary>

        [Test]
        public void TestPCPartShouldHavePartAsBaseClass()
        {
            Assert.IsTrue(typeof(PCPart).BaseType == typeof(Part));
        }

        [Test]
        public void TestPCPartShouldBeInstantiatedWith2parameters()
        {
            IPart pcPart = new PCPart(PartName, PartCost);

            Assert.AreEqual(PartName, pcPart.Name);
            Assert.AreEqual((PartCost*multiplierPCPart), pcPart.Cost);
            Assert.AreEqual(false, pcPart.IsBroken);
        }

        [Test]
        public void TestPCPartShouldBeInstantiatedWith3parameters()
        {
            IPart pcPart = new PCPart(PartName, PartCost, PartIsBroken);

            Assert.AreEqual(PartName, pcPart.Name);
            Assert.AreEqual((PartCost*multiplierPCPart), pcPart.Cost);
            Assert.AreEqual(PartIsBroken, pcPart.IsBroken);
        }
        
        [Test]
        public void TestPCPartShouldNotHaveNullName()
        {
            Assert.Throws<ArgumentException>(() => new PCPart(null, PartCost, PartIsBroken));
        }

        [Test]
        public void TestPCPartShouldNotHaveCostZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() => new PCPart(PartName, 0, PartIsBroken));
        }

        [Test]
        public void TestRepairPCPartShouldFixBrokenPart()
        {
            IPart pcPart = new PCPart(PartName, PartCost);

            pcPart.Repair();

            Assert.IsTrue(pcPart.IsBroken == false);
        }

        [Test]
        public void TestReportPCPartShouldReturnCorrectMessage()
        {
            IPart pcPart = new PCPart(PartName, PartCost, PartIsBroken);

            string expected = $"{PartName} - {(PartCost*multiplierPCPart):f2}$" + Environment.NewLine + $"Broken: {PartIsBroken}";
            string actual = pcPart.Report();

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// LaptopPart
        /// </summary>

        [Test]
        public void TestLaptopPartShouldHavePartAsBaseClass()
        {
            Assert.IsTrue(typeof(LaptopPart).BaseType == typeof(Part));
        }

        [Test]
        public void TestLaptopPartShouldBeInstantiatedWith2parameters()
        {
            IPart laptopPart = new LaptopPart(PartName, PartCost);

            Assert.AreEqual(PartName, laptopPart.Name);
            Assert.AreEqual((PartCost*multiplierLaptopPart), laptopPart.Cost);
            Assert.AreEqual(false, laptopPart.IsBroken);
        }

        [Test]
        public void TestLaptopPartShouldBeInstantiatedWith3parameters()
        {
            IPart laptopPart = new LaptopPart(PartName, PartCost, PartIsBroken);

            Assert.AreEqual(PartName, laptopPart.Name);
            Assert.AreEqual((PartCost*multiplierLaptopPart), laptopPart.Cost);
            Assert.AreEqual(PartIsBroken, laptopPart.IsBroken);
        }

        [Test]
        public void TestLaptopPartShouldNotHaveNullName()
        {
            Assert.Throws<ArgumentException>(() => new LaptopPart(null, PartCost, PartIsBroken));
        }

        [Test]
        public void TestLaptopPartShouldNotHaveCostZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() => new LaptopPart(PartName, 0, PartIsBroken));
        }

        [Test]
        public void TestRepairLaptopPartShouldFixBrokenPart()
        {
            IPart laptopPart = new LaptopPart(PartName, PartCost);

            laptopPart.Repair();

            Assert.IsTrue(laptopPart.IsBroken == false);
        }

        [Test]
        public void TestReportLaptopPartShouldReturnCorrectMessage()
        {
            IPart laptopPart = new LaptopPart(PartName, PartCost, PartIsBroken);

            string expected = $"{PartName} - {(PartCost*multiplierLaptopPart):f2}$" + Environment.NewLine + $"Broken: {PartIsBroken}";
            string actual = laptopPart.Report();

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// PhonePart
        /// </summary>

        [Test]
        public void TestPhonePartShouldHavePartAsBaseClass()
        {
            Assert.IsTrue(typeof(PhonePart).BaseType == typeof(Part));
        }

        [Test]
        public void TestPhonePartShouldBeInstantiatedWith2parameters()
        {
            IPart phonePart = new PhonePart(PartName, PartCost);

            Assert.AreEqual(PartName, phonePart.Name);
            Assert.AreEqual((PartCost*multiplierPhonePart), phonePart.Cost);
            Assert.AreEqual(false, phonePart.IsBroken);
        }

        [Test]
        public void TestPhonePartShouldBeInstantiatedWith3parameters()
        {
            IPart phonePart = new PhonePart(PartName, PartCost, PartIsBroken);

            Assert.AreEqual(PartName, phonePart.Name);
            Assert.AreEqual((PartCost*multiplierPhonePart), phonePart.Cost);
            Assert.AreEqual(PartIsBroken, phonePart.IsBroken);
        }

        [Test]
        public void TestPhonePartShouldNotHaveNullName()
        {
            Assert.Throws<ArgumentException>(() => new PhonePart(null, PartCost, PartIsBroken));
        }

        [Test]
        public void TestPhonePartShouldNotHaveCostZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() => new PhonePart(PartName, 0, PartIsBroken));
        }

        [Test]
        public void TestRepairPhonePartShouldFixBrokenPart()
        {
            IPart phonePart = new PhonePart(PartName, PartCost);

            phonePart.Repair();

            Assert.IsTrue(phonePart.IsBroken == false);
        }

        [Test]
        public void TestReportPhonePartShouldReturnCorrectMessage()
        {
            IPart laptopPart = new LaptopPart(PartName, PartCost, PartIsBroken);

            string expected = $"{PartName} - {(PartCost*multiplierLaptopPart):f2}$" + Environment.NewLine + $"Broken: {PartIsBroken}";
            string actual = laptopPart.Report();

            Assert.AreEqual(expected, actual);
        }
    }
}