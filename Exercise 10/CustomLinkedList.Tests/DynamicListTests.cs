namespace CustomLinkedList.Tests
{
    using NUnit.Framework;
    using CustomLinkedList;
    using System;

    [TestFixture]
    public class DynamicListTests
    {
        private DynamicList<int> dynamicList;

        [SetUp]
        public void Setup()
        {
            dynamicList = new DynamicList<int>();
        }

        [Test]
        public void ConstructorCreatesNewObjectCorrectly()
        {
            Assert.IsNotNull(this.dynamicList);
        }

        [Test]
        public void CountPropertyGetsCorrectValue()
        {
            // new DynamicList should have count == 0 :
            Assert.AreEqual(0, dynamicList.Count);
        }

        [Test]
        public void AddingObjectToAnEmptyListChangesCount()
        {
            for (int i = 1; i <= 32; i++)
            {
                this.dynamicList.Add(i);
            }

            Assert.AreEqual(32, this.dynamicList.Count);
        }

        [Test]
        public void AddingObjectToANonEmptyListChangesCount()
        {
            for (int i = 1; i <= 32; i++)
            {
                this.dynamicList.Add(i);
            }

            this.dynamicList.Add(33);

            Assert.AreEqual(33, this.dynamicList.Count);
        }

        [Test]
        public void IndexAccessOperatorGetsCorrectValue()
        {
            this.dynamicList.Add(1);
            var valueAtIndexZero = this.dynamicList[0];

            Assert.AreEqual(valueAtIndexZero, 1);
        }

        [Test]
        [TestCase(-1)]  // index < 0
        [TestCase(1)]   // index == count
        [TestCase(2)]   // index > count
        public void IndexAccessOperatorTrowsExceptionWhenGetsInvalidIndex(int index)
        {
            this.dynamicList.Add(1);   // count == 1;
            var value = 0;

            Assert.Throws<ArgumentOutOfRangeException>(() => value = this.dynamicList[index]);
        }

        [Test]
        public void IndexAccessOperatorSetsCorrectValue()
        {
            this.dynamicList.Add(1);

            var newValueAtIndexZero = 2;
            this.dynamicList[0] = newValueAtIndexZero;

            Assert.AreEqual(2, this.dynamicList[0]);
        }

        [Test]
        [TestCase(-1)]  // index < 0
        [TestCase(1)]   // index == count
        [TestCase(2)]   // index > count
        public void IndexAccessOperatorTrowsExceptionWhenSetsInvalidIndex(int index)
        {
            this.dynamicList.Add(1);  // count == 1;
            var newValue = 2;

            Assert.Throws<ArgumentOutOfRangeException>(() => this.dynamicList[index] = newValue);
        }

        [Test]
        [TestCase(-1)]  // index < 0
        [TestCase(1)]   // index == count
        [TestCase(2)]   // index > count
        public void RemoveAtInvalidIndexThrowsException(int index)
        {
            this.dynamicList.Add(1);  // count == 1;

            Assert.Throws<ArgumentOutOfRangeException>(() => this.dynamicList.RemoveAt(index));
        }

        [Test]
        public void RemoveAtReturnsCorrectElementWhenCorrectIndexIsPassed()
        {
            this.dynamicList.Add(1);
            var targetElement = dynamicList.RemoveAt(0);

            Assert.AreEqual(1, targetElement);
        }

        [Test]
        public void RemoveElementReturnsCorrectIndexWhenIsFound()
        {
            this.dynamicList.Add(1);
            var correctIndex = 0;

            Assert.AreEqual(correctIndex, this.dynamicList.Remove(1));
        }

        [Test]
        public void RemoveElementReturnsCorrectValueWhenIsNotFound()
        {
            var correctValue = -1;

            Assert.AreEqual(correctValue, this.dynamicList.Remove(32));
        }

        [Test]
        public void IndexOfReturnsCorrectIndexWhenIsFound()
        {
            this.dynamicList.Add(1);
            var correctIndex = 0;

            Assert.AreEqual(correctIndex, this.dynamicList.IndexOf(1));
        }

        [Test]
        public void IndexOfReturnsCorrectValueWhenIsNotFound()
        {
            var correctValue = -1;

            Assert.AreEqual(correctValue, this.dynamicList.IndexOf(32));
        }

        [Test]
        public void ContainsReturnsTrueWhenIsFound()
        {
            this.dynamicList.Add(1);

            Assert.AreEqual(true, this.dynamicList.Contains(1));
        }

        [Test]
        public void ContainReturnsFalseWhenIsNotFound()
        {
            Assert.AreEqual(false, this.dynamicList.Contains(32));
        }
    }
}
