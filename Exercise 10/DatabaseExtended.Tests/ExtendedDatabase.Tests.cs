namespace Tests
{
    using System;
    using NUnit.Framework;

    using ExtendedDatabase;

    public class ExtendedDatabaseTests
    {
        private Person personOne;
        private Person personTwo;
        private Person testPerson;
        private ExtendedDatabase testDatabase;
        private const long testID = 1003;
        private const string testUsername = "Gosho";

        [SetUp]
        public void Setup()
        {
            this.personOne = new Person(1001, "Ivan");
            this.personTwo = new Person(1002, "Mitko");
            this.testPerson = new Person(testID, testUsername);

            this.testDatabase = new ExtendedDatabase(personOne, personTwo);
        }

        [Test]
        public void TestConstructorCreatesCorrectDatabase()
        {
            ExtendedDatabase newDatabase = new ExtendedDatabase(personOne, personTwo);

            int expectedCountOfPersons = 2;
            int actualCountOfPersons = newDatabase.Count;

            Assert.AreEqual(expectedCountOfPersons, actualCountOfPersons);
        }


        [Test]
        public void TestConstructorShouldThrowExceptionWithMoreThan16People()
        {
            Person[] people = CreatePeople(17);

            Assert.That(() => new ExtendedDatabase(people), Throws.ArgumentException);
        }

        [Test]
        public void TestConstructorShouldThrowExceptionWithEmptyPeople()
        {
            Person[] people = new Person[17];

            Assert.That(() => new ExtendedDatabase(people), Throws.ArgumentException);
        }

        [Test]
        public void TestAddCorrectlyUser()
        {
            this.testDatabase.Add(testPerson);

            int expectedCountOfPersons = 3;
            int actualCountOfPersons = this.testDatabase.Count;

            Assert.AreEqual(expectedCountOfPersons, actualCountOfPersons);
        }

        [Test]
        public void TesAddShouldNotAddExistingUsername()
        {
            this.testDatabase.Add(testPerson);
            Person newPerson = new Person(1111, testUsername);

            Assert.That(() => testDatabase.Add(newPerson), Throws.InvalidOperationException);
        }

        [Test]
        public void TesAddShouldNotAddExistingId()
        {
            this.testDatabase.Add(testPerson);
            Person newPerson = new Person(testID, "Pesho");

            Assert.That(() => testDatabase.Add(newPerson), Throws.InvalidOperationException);
        }

        [Test]
        public void TestAddInFullDatabase()
        {
            Person[] people = CreatePeople(15);

            ExtendedDatabase newDatabase = new ExtendedDatabase(people);
            newDatabase.Add(personOne);


            Assert.Throws<InvalidOperationException>(() => newDatabase.Add(personTwo));

        }

        [Test]
        public void TestRemoveCorrectly()
        {
            testDatabase.Remove();

            int expectedCountOfPersons = 1;
            int actualCountOfPersons = this.testDatabase.Count;

            Assert.AreEqual(expectedCountOfPersons, actualCountOfPersons);
        }

        [Test]
        public void TestRemoveFromEmptyDatabase()
        {
            ExtendedDatabase newDatabase = new ExtendedDatabase();

            Assert.Throws<InvalidOperationException>(() => newDatabase.Remove());
        }

        [Test]
        public void TestFindByUsernameNonExistingUserNameThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => this.testDatabase.FindByUsername(testUsername));
        }

        [Test]
        public void TestFindByUsernameNullArgumentThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => this.testDatabase.FindByUsername(null));
        }

        [Test]
        public void TestFindByUsernameIsCaseSensitive()
        {
            this.testDatabase.Add(testPerson);

            Assert.Throws<InvalidOperationException>(() => this.testDatabase.FindByUsername(testUsername.ToLower()));
        }

        [Test]
        public void TestFindByUsernameWorksCorrectly()
        {
            this.testDatabase.Add(testPerson);

            Person expectedPerson = testPerson;
            Person actualPerson = this.testDatabase.FindByUsername(testUsername);

            Assert.AreEqual(expectedPerson, actualPerson);
        }

        [Test]
        public void TestFindByIDExistingIDThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => this.testDatabase.FindById(testID));
        }

        [Test]
        public void TestFindByIDNegativeIDThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.testDatabase.FindById(-testID));
        }

        [Test]
        public void TestFindByIDWorksCorrectly()
        {
            this.testDatabase.Add(testPerson);

            Person expectedPerson = testPerson;
            Person actualPerson = this.testDatabase.FindById(testID);

            Assert.AreEqual(expectedPerson, actualPerson);
        }

        private Person[] CreatePeople(int countOfPeople)
        {
            Person[] people = new Person[countOfPeople];

            for (int i = 0; i < countOfPeople; i++)
            {
                long id = 2000 + i;
                string userName = "Petar" + (char)('a' + i);

                Person person = new Person(id, userName);
                people[i] = person;
            }

            return people;
        }
    }
}