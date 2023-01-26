using Projet7;

namespace TestUnitaire
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void CreatePokemon()
        {
            Pokemon P = Pokemon.GetPokemon(25,5);
            Console.WriteLine(P.name["english"]);
            Console.WriteLine("lvl " + P.level);
        }

        [Test]
        public void CreateAttack()
        {
            Attack A = Attack.GetAttack(25);
            Console.WriteLine(A.ename);
            Console.WriteLine("power : " + A.power);
            Console.WriteLine("accuracy : " + A.accuracy);
        }
    }
}