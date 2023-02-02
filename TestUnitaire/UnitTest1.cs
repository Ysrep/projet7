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
            Pokemon P = Pokemon.GetPokemon(165, 5);

            Console.WriteLine(P.name["english"]);
            Console.WriteLine("lvl " + P.level);
            Console.WriteLine(P.Base["HP"]);
            Console.WriteLine(P.Base["Attack"]);
            Console.WriteLine(P.Base["Defense"]);
            Console.WriteLine(P.Base["Sp. Attack"]);
            Console.WriteLine(P.Base["Sp. Defense"]);
            Console.WriteLine(P.Base["Speed"]);
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(P.attack[i].ename +" " + P.attack[i].category);
            }
        }

        [Test]
        public void CreateAttack()
        {
            Attack A = Attack.GetAttack(25);
            Console.WriteLine(A.ename);
            Console.WriteLine("power : " + A.power);
            Console.WriteLine("accuracy : " + A.accuracy);
        }

        [Test]
        public void CheckGetTeam()
        {
            NPC.CreateNPC();
            PokemonTeam A = PokemonTeam.CreateTeam();
            Console.WriteLine(A.PT[0].Base["Attack"]);
        }
    }
}