namespace Tests
{
    using NUnit.Framework;
    using System;
    using FightingArena;

    public class WarriorTests
    {
        private const string Name = "Test Warrior";
        private const int Damage = 100;
        private const int HP = 20;
        private Warrior testWarrior;

        [SetUp]
        public void Setup()
        {
            testWarrior = new Warrior(Name, Damage, HP);
        }

        [Test]
        public void TestConstructorCreatesWarrior()
        {
            Warrior newWarrior = new Warrior(Name, Damage, HP);

            Assert.That(newWarrior != null);
        }

        [Test]
        public void TestNameReturnsWarriorName()
        {
            string expectedResult = Name;
            string actualResult = testWarrior.Name;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestWarriorShouldNotBeCreatedWithNullName()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(null, Damage, HP));
        }

        [Test]
        public void TestWarriorShouldNotBeCreatedWithWhiteSpace()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(" ", Damage, HP));
        }

        [Test]
        public void TestWarriorShouldNotBeCreatedWithStringEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(String.Empty, Damage, HP));
        }

        [Test]
        public void TestDamageReturnsWarriorDamage()
        {
            int expectedResult = Damage;
            int actualResult = testWarrior.Damage;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestWarriorShouldNotBeCreatedWithZeroOrNegativeDamage()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(Name, 0, HP));
        }

        [Test]
        public void TestHPReturnsWarriorHP()
        {
            int expectedResult = HP;
            int actualResult = testWarrior.HP;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestWarriorShouldNotBeCreatedWithNegativeHP()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(Name, Damage, -10));
        }

        [Test]
        public void TestWarriorCanNotAttackWithHPBelow30()
        {
            Warrior attacker = new Warrior("Pesho", 10, 20);
            Warrior defender = new Warrior("Gosho", 5, 60);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        
        [Test]
        public void TestWarriorCanNotBeAttackedWithHPBelow30()
        {
            Warrior attacker = new Warrior("Pesho", 10, 50);
            Warrior defender = new Warrior("Gosho", 5, 20);

           Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }
        
        [Test]
        public void TestAttackStrongerEnemy()
        {
            Warrior attacker = new Warrior("Pesho", 10, 50);
            Warrior defender = new Warrior("Gosho", 60, 40);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        public void TestAttackWorksCorrectly()
        {
            Warrior attacker = new Warrior("Pesho", 10, 50);
            Warrior defender = new Warrior("Gosho", 5, 60);


            attacker.Attack(defender);

            int expectedAttackerHP = 45;
            int expectedDefenderHP = 50;

            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }

        [Test]
        public void TestAttackWorksCorrectlyWhenDamageIsSmallerThanAttackedHP()
        {
            Warrior attacker = new Warrior("Pesho", 40, 50);
            Warrior defender = new Warrior("Gosho", 30, 50);

            attacker.Attack(defender);

            int expectedAttackerHP = 20;
            int expectedDefenderHP = 10;

            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);

        }

        [Test]
        public void TestAttackWorksCorrectlyWhenDamageIsBiggerThanAttackedHP()
        {
            Warrior attacker = new Warrior("Pesho", 60, 50);
            Warrior defender = new Warrior("Gosho", 30, 50);

            attacker.Attack(defender);

            int expectedAttackerHP = 20;
            int expectedDefenderHP = 0;

            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);

        }
    }
}