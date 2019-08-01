namespace Tests
{
    using NUnit.Framework;

    using System;
    using System.Linq;
    using Database;


    [TestFixture]
    public class DatabaseTests
    {
        private int[] smallerArray;
        private int[] biggerArray;
        private int[] fullArray;
        private const int DefaultCapacity = 16;
        private Database testDatabase;
        private const int testElement = 10;

        [SetUp]
        public void SetUp()
        {
            this.smallerArray = Enumerable.Range(1, 8).ToArray();
            this.biggerArray = Enumerable.Range(1, 20).ToArray();
            this.fullArray = Enumerable.Range(1, DefaultCapacity).ToArray();

            testDatabase = new Database(smallerArray);
        }

        [Test]
        public void TestConstructorShouldInitialize16Integers()
        {
            Database database = new Database(fullArray);

            int actualCapacity = database.Count;
            int expectedCapacity = DefaultCapacity;

            Assert.That(actualCapacity, Is.EqualTo(expectedCapacity));
        }

        [Test]
        public void TestConstructorShouldThrowExceptionWithMoreThan16Args()
        {
            Assert.That(() => new Database(biggerArray), Throws.InvalidOperationException, "The size of the parameter must be equal or less than 16!");
        }
        
        [Test]
        public void TestAddShouldAddAtNextFreePosition()
        {
            this.testDatabase.Add(testElement);
         
            int expectedCount = smallerArray.Length + 1;
            int actualCount = testDatabase.Count;

            Assert.AreEqual(expectedCount, actualCount, $"Expected length should be {expectedCount}");
        }

        [Test]
        public void TestAddShouldAddAtNextFreePosition2()
        {
            testDatabase.Add(testElement);

            int[] expectedResult = smallerArray.Concat(new int[] { testElement }).ToArray();
            int[] actualResult = testDatabase.Fetch();

            CollectionAssert.AreEqual(expectedResult, actualResult, $"Expected length should be {expectedResult.Length}");
        }

        
        [Test]
        public void TestAddShouldThrowExceptionWhenAdd17Element()
        {
            for (int i = 0; i < 8; i++)
            {
                this.testDatabase.Add(testElement);
            }

            Assert.Throws<InvalidOperationException>(() => testDatabase.Add(testElement), "Database is full!");
        }

        [Test]
        public void TestRemoveShouldRemoveAtLastIndex()
        {
            testDatabase.Remove();

            int expectedLastElementAfterRemove = smallerArray[smallerArray.Length - 2];
            int actualRemovedElement = testDatabase.Fetch().Last();

            Assert.AreEqual(expectedLastElementAfterRemove, actualRemovedElement);
        }

        [Test]
        public void TestRemoveFromEmptyDatabaseShoulThrowException()
        {
            Database newDatabase = new Database();

            Assert.That(() => newDatabase.Remove(), Throws.InvalidOperationException, "Can not remove from empty Database!");
        }

        [Test]
        public void TestFetchShouldReturnArray()
        {
            int[] expectedResult = this.smallerArray;
            int[] actualResult = testDatabase.Fetch();

            CollectionAssert.AreEqual(expectedResult,actualResult);
        }

    }
}