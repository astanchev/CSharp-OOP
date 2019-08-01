namespace Tests
{
    using System;
    using System.Linq;
    using FightingArena;
    using NUnit.Framework;

    public class ArenaTests
    {
        private Warrior attackerWarrior;
        private Warrior defenderWarrior;
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            attackerWarrior = new Warrior("Pesho", 100, 50);
            defenderWarrior = new Warrior("Gosho", 50, 50);
            arena = new Arena();
        }

        [Test]
        public void TestConstructorCreatesArena()
        {
            Arena newArena = new Arena();

            Assert.That(newArena != null);
        }

        [Test]
        public void TestConstructorInitiatesListOfWarriors()
        {
            Assert.That(arena.Warriors != null);
        }

        [Test]
        public void TestArenaEnrollsCorrectly()
        {
            arena.Enroll(attackerWarrior);

            //Warrior expectedWarrior = attackerWarrior;
            //Warrior actualWarrior = this.arena.Warriors.FirstOrDefault();

            Assert.That(arena.Warriors, Has.Member(attackerWarrior));
           // Assert.AreEqual(expectedWarrior, actualWarrior);
        }

        [Test]
        public void TestCountWorksCorrectly()
        {
            arena.Enroll(attackerWarrior);

            int expectedCount = 1;
            int actualCount = arena.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void TestCanNotEnrollEnrolledWarrior()
        {
            Warrior newWarrior = new Warrior("Pesho", 60, 60);
            arena.Enroll(attackerWarrior);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(newWarrior));
        }

        [Test]
        public void TestFightWorksCorrectly()
        {
            arena.Enroll(attackerWarrior);
            arena.Enroll(defenderWarrior);

            arena.Fight(attackerWarrior.Name, defenderWarrior.Name);
            int expectedDefenderHP = 0;
            int actualDefenderHP = defenderWarrior.HP;

            Assert.AreEqual(expectedDefenderHP, actualDefenderHP);
        }

        [Test]
        public void TestCanNotBeFightWithNotEnrolledAttackerWarrior()
        {
            arena.Enroll(attackerWarrior);
            arena.Enroll(defenderWarrior);

            Assert.That(() => arena.Fight("Ivan", defenderWarrior.Name), Throws.InvalidOperationException.With.Message.EqualTo("There is no fighter with name Ivan enrolled for the fights!"));
        }

        [Test]
        public void TestCanNotBeFightWithNotEnrolledDefenderWarrior()
        {
            arena.Enroll(attackerWarrior);
            arena.Enroll(defenderWarrior);

            Assert.That(() => arena.Fight(attackerWarrior.Name, "Ivan"), Throws.InvalidOperationException.With.Message.EqualTo("There is no fighter with name Ivan enrolled for the fights!"));
        }
    }
}
