using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace Projet7
{
    public class Player
    {

        public int[] PlayerPos { get; set; }
        public int Money { get; set; }
        public List<Pokemon> ListPokemonTeam { get; set; }

        public static List<Option>? options { get; set; }
        public void InitWIthoutJSon(int x, int y)
        {
            Random rId = new Random();
            int PokemonId = rId.Next(1, 613);
            Pokemon pokemon = Pokemon.GetPokemon(PokemonId, 5);
            ListPokemonTeam = new List<Pokemon> { };
            ListPokemonTeam.Add(pokemon);
            //_pokemonTeam.CreateTeam();
            PlayerPos = new int[2];
            PlayerPos[0] = x;
            PlayerPos[1] = y;
            Money = 0;
        }

        public void FullHeal()
        {
            foreach (var pokemon in ListPokemonTeam)
            {
                pokemon.currentHp = pokemon.Base["HP"];
                foreach (var attack in pokemon.attack)
                {
                    attack.currentPp = attack.pp;
                }
            }
        }

        public void Heal(Item item)
        {

            foreach (var pokemon in ListPokemonTeam)
            {
                pokemon.currentHp = pokemon.Base["HP"];
                foreach (var attack in pokemon.attack)
                {
                    attack.currentPp = attack.pp;
                }
            }
        }

        public void Inputs(Map _map)
        {
            ConsoleKeyInfo input = Console.ReadKey(true);
            switch (input.Key)
            {
                case ConsoleKey.Q:
                    if (input.Modifiers == ConsoleModifiers.Shift)
                    {
                        int i;
                        for (i = 0; i <= 3; i++)
                        {

                            if (_map.GetMap()[PlayerPos[1], PlayerPos[0] - i] != '#' && _map.GetMap()[PlayerPos[1], PlayerPos[0] - i] != '/' && _map.GetMap()[PlayerPos[1], PlayerPos[0] - i] != '-' && _map.GetMap()[PlayerPos[1], PlayerPos[0] - i] != 'C' && _map.GetMap()[PlayerPos[1], PlayerPos[0] - i] != '~')
                            {
                                if (i != 0 && _map.GetMap()[PlayerPos[1], PlayerPos[0] - i] == 'w')
                                {
                                    Random rand = new Random();
                                    int wildEncounter = rand.Next(5);
                                    if (wildEncounter == 1)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("A wild pokemon appeared");
                                        _map.WildBattle = true;
                                        PlayerPos[0] = PlayerPos[0] - (i - 1);
                                        break;
                                    }
                                }
                                for (int j = 0; j < 6; j++)
                                {
                                    if (_map.GetMap()[PlayerPos[1], PlayerPos[0] - i] == '!')
                                    {
                                        Console.WriteLine("Trainer");
                                        PlayerPos[0] = PlayerPos[0] - (i - 1);
                                        _map.TrainerBattle = true;
                                        break;
                                    }
                                }

                            }
                            else
                            {
                                break;
                            }

                        }
                        PlayerPos[0] = PlayerPos[0] - (i - 1);
                    }
                    else
                    {
                        if (_map.GetMap()[PlayerPos[1], PlayerPos[0] - 1] != '#' && _map.GetMap()[PlayerPos[1], PlayerPos[0] - 1] != '/' && _map.GetMap()[PlayerPos[1], PlayerPos[0] - 1] != '-' && _map.GetMap()[PlayerPos[1], PlayerPos[0] - 1] != 'C' && _map.GetMap()[PlayerPos[1], PlayerPos[0] - 1] != '~')
                        {
                            PlayerPos[0] = PlayerPos[0] - 1;

                        }
                        if (_map.GetMap()[PlayerPos[1], PlayerPos[0]] == 'w')
                        {
                            Random rand = new Random();
                            int wildEncounter = rand.Next(5);
                            if (wildEncounter == 1)
                            {
                                Console.WriteLine();
                                Console.WriteLine("A wild pokemon appeared");
                                _map.WildBattle = true;
                            }
                        }
                        for (int j = 0; j < 6; j++)
                        {
                            if (_map.GetMap()[PlayerPos[1], PlayerPos[0] - j] == '!' || _map.GetMap()[PlayerPos[1], PlayerPos[0] + j] == '!' || _map.GetMap()[PlayerPos[1] - j, PlayerPos[0]] == '!' || _map.GetMap()[PlayerPos[1] + j, PlayerPos[0]] == '!')
                            {
                                Console.WriteLine("Trainer");
                                _map.TrainerBattle = true;
                                break;
                            }
                        }
                    }
                    break;


                case ConsoleKey.Z:
                    if (input.Modifiers == ConsoleModifiers.Shift)
                    {
                        int i;
                        for (i = 0; i <= 3; i++)
                        {

                            if (_map.GetMap()[PlayerPos[1] - i, PlayerPos[0]] != '#' && _map.GetMap()[PlayerPos[1] - i, PlayerPos[0]] != '_' && _map.GetMap()[PlayerPos[1] - i, PlayerPos[0]] != '/' && _map.GetMap()[PlayerPos[1] - i, PlayerPos[0]] != 'C' && _map.GetMap()[PlayerPos[1] - i, PlayerPos[0]] != '-' && _map.GetMap()[PlayerPos[1] - i, PlayerPos[0]] != '~')
                            {
                                if (_map.GetMap()[PlayerPos[1] - i, PlayerPos[0]] == 'c')
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Your pokemons has been healed");
                                    break;
                                }

                                else if (_map.GetMap()[PlayerPos[1] - i, PlayerPos[0]] == 'A')
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Pokemon Gym");
                                    _map.GymBattle = true;
                                    break;
                                }
                                else if (i != 0 && _map.GetMap()[PlayerPos[1] - i, PlayerPos[0]] == 'w')
                                {
                                    Random rand = new Random();
                                    int wildEncounter = rand.Next(5);
                                    if (wildEncounter == 1)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("A wild pokemon appeared");
                                        _map.WildBattle = true;
                                        PlayerPos[1] = PlayerPos[1] - (i - 1);
                                        break;
                                    }
                                }
                                for (int j = 0; j < 6; j++)
                                {
                                    if (_map.GetMap()[PlayerPos[1] - i, PlayerPos[0] - j] == '!' || _map.GetMap()[PlayerPos[1] - i, PlayerPos[0] + j] == '!' || _map.GetMap()[PlayerPos[1] - i - j, PlayerPos[0]] == '!' || _map.GetMap()[PlayerPos[1] - i + j, PlayerPos[0]] == '!')
                                    {
                                        Console.WriteLine("Trainer");
                                        PlayerPos[1] = PlayerPos[1] - (i - 1);
                                        _map.TrainerBattle = true;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }

                        }
                        PlayerPos[1] = PlayerPos[1] - (i - 1);
                    }
                    else
                    {
                        if (_map.GetMap()[PlayerPos[1] - 1, PlayerPos[0]] != '#' && _map.GetMap()[PlayerPos[1] - 1, PlayerPos[0]] != '_' && _map.GetMap()[PlayerPos[1] - 1, PlayerPos[0]] != '/' && _map.GetMap()[PlayerPos[1] - 1, PlayerPos[0]] != 'C' && _map.GetMap()[PlayerPos[1] - 1, PlayerPos[0]] != '-' && _map.GetMap()[PlayerPos[1] - 1, PlayerPos[0]] != '~')
                        {
                            if (_map.GetMap()[PlayerPos[1] - 1, PlayerPos[0]] == 'c')
                            {
                                Console.WriteLine();
                                Console.WriteLine("Your pokemons has been healed");
                                FullHeal();
                            }
                            else
                            {
                                PlayerPos[1] = PlayerPos[1] - 1;
                            }

                        }
                        if (_map.GetMap()[PlayerPos[1], PlayerPos[0]] == 'A')
                        {
                            Console.WriteLine();
                            Console.WriteLine("Pokemon Gym");
                            _map.GymBattle = true;
                            break;
                        }
                        if (_map.GetMap()[PlayerPos[1], PlayerPos[0]] == 'w')
                        {
                            Random rand = new Random();
                            int wildEncounter = rand.Next(5);
                            if (wildEncounter == 1)
                            {
                                Console.WriteLine();
                                Console.WriteLine("A wild pokemon appeared");
                                _map.WildBattle = true;
                            }
                        }
                        for (int j = 0; j < 6; j++)
                        {
                            if (_map.GetMap()[PlayerPos[1], PlayerPos[0] - j] == '!' || _map.GetMap()[PlayerPos[1], PlayerPos[0] + j] == '!' || _map.GetMap()[PlayerPos[1] - j, PlayerPos[0]] == '!' || _map.GetMap()[PlayerPos[1] + j, PlayerPos[0]] == '!')
                            {
                                Console.WriteLine("Trainer");
                                _map.TrainerBattle = true;
                                break;
                            }
                        }
                    }

                    break;

                case ConsoleKey.D:
                    if (input.Modifiers == ConsoleModifiers.Shift)
                    {
                        int i;
                        for (i = 0; i <= 3; i++)
                        {
                            if (_map.GetMap()[PlayerPos[1], PlayerPos[0] + i] != '#' && _map.GetMap()[PlayerPos[1], PlayerPos[0] + i] != '/' && _map.GetMap()[PlayerPos[1], PlayerPos[0] + i] != 'C' && _map.GetMap()[PlayerPos[1], PlayerPos[0] + i] != '-' && _map.GetMap()[PlayerPos[1], PlayerPos[0] + i] != '~')
                            {
                                if (i != 0 && _map.GetMap()[PlayerPos[1], PlayerPos[0] + i] == 'w')
                                {
                                    Random rand = new Random();
                                    int wildEncounter = rand.Next(5);
                                    if (wildEncounter == 1)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("A wild pokemon appeared");
                                        _map.WildBattle = true;
                                        PlayerPos[0] = PlayerPos[0] + (i - 1);
                                        break;
                                    }
                                }
                                for (int j = 0; j < 6; j++)
                                {
                                    if (_map.GetMap()[PlayerPos[1], PlayerPos[0] + i - j] == '!' || _map.GetMap()[PlayerPos[1], PlayerPos[0] + i + j] == '!' || _map.GetMap()[PlayerPos[1] - j, PlayerPos[0] + i] == '!' || _map.GetMap()[PlayerPos[1] + j, PlayerPos[0] + i] == '!')
                                    {
                                        Console.WriteLine("Trainer");
                                        PlayerPos[0] = PlayerPos[0] + (i - 1);
                                        _map.TrainerBattle = true;
                                        break;
                                    }
                                }

                            }

                            else
                            {
                                break;
                            }

                        }
                        PlayerPos[0] = PlayerPos[0] + (i - 1);
                    }
                    else
                    {
                        if (_map.GetMap()[PlayerPos[1], PlayerPos[0] + 1] != '#' && _map.GetMap()[PlayerPos[1], PlayerPos[0] + 1] != '/' && _map.GetMap()[PlayerPos[1], PlayerPos[0] + 1] != 'C' && _map.GetMap()[PlayerPos[1], PlayerPos[0] + 1] != '-' && _map.GetMap()[PlayerPos[1], PlayerPos[0] + 1] != '~')
                        {

                            PlayerPos[0] = PlayerPos[0] + 1;

                        }
                        if (_map.GetMap()[PlayerPos[1], PlayerPos[0]] == 'w')
                        {
                            Random rand = new Random();
                            int wildEncounter = rand.Next(5);
                            if (wildEncounter == 1)
                            {
                                Console.WriteLine();
                                Console.WriteLine("A wild pokemon appeared");
                                _map.WildBattle = true;
                            }
                        }
                        for (int j = 0; j < 6; j++)
                        {
                            if (_map.GetMap()[PlayerPos[1], PlayerPos[0] - j] == '!' || _map.GetMap()[PlayerPos[1], PlayerPos[0] + j] == '!' || _map.GetMap()[PlayerPos[1] - j, PlayerPos[0]] == '!' || _map.GetMap()[PlayerPos[1] + j, PlayerPos[0]] == '!')
                            {
                                Console.WriteLine("Trainer");
                                _map.TrainerBattle = true;
                                break;
                            }
                        }
                    }
                    break;

                case ConsoleKey.S:
                    if (input.Modifiers == ConsoleModifiers.Shift)
                    {
                        int i;
                        bool jump = false;
                        for (i = 0; i <= 3; i++)
                        {
                            if (_map.GetMap()[PlayerPos[1] + i, PlayerPos[0]] != '#' && _map.GetMap()[PlayerPos[1] + i, PlayerPos[0]] != '_' && _map.GetMap()[PlayerPos[1] + i, PlayerPos[0]] != '/' && _map.GetMap()[PlayerPos[1] + i, PlayerPos[0]] != 'C' && _map.GetMap()[PlayerPos[1] + i, PlayerPos[0]] != '~')
                            {
                                if (_map.GetMap()[PlayerPos[1] + i, PlayerPos[0]] == '-')
                                {
                                    jump = true;
                                }
                                else if (_map.GetMap()[PlayerPos[1] - i, PlayerPos[0]] == 'A')
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Pokemon Gym");
                                    break;
                                }
                                else if (_map.GetMap()[PlayerPos[1] + i, PlayerPos[0]] == 'c')
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Your pokemons has been healed");
                                    break;
                                }
                                else if (i != 0 && _map.GetMap()[PlayerPos[1] + i, PlayerPos[0]] == 'w')
                                {
                                    Random rand = new Random();
                                    int wildEncounter = rand.Next(5);
                                    if (wildEncounter == 1)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("A wild pokemon appeared");
                                        _map.WildBattle = true;
                                        if (jump)
                                        {
                                            PlayerPos[1] = PlayerPos[1] + (i);
                                        }
                                        else
                                            PlayerPos[1] = PlayerPos[1] + (i - 1);
                                        break;
                                    }
                                }
                                for (int j = 0; j < 6; j++)
                                {
                                    if (_map.GetMap()[PlayerPos[1] + i, PlayerPos[0] - j] == '!' || _map.GetMap()[PlayerPos[1] + i, PlayerPos[0] + j] == '!' || _map.GetMap()[PlayerPos[1] + i - j, PlayerPos[0]] == '!' || _map.GetMap()[PlayerPos[1] + i + j, PlayerPos[0] + i] == '!')
                                    {
                                        Console.WriteLine("Trainer");
                                        if (jump)
                                        {
                                            PlayerPos[1] = PlayerPos[1] + (i);
                                        }
                                        else
                                            PlayerPos[1] = PlayerPos[1] + (i - 1);
                                        _map.TrainerBattle = true;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }

                        }
                        if (jump)
                        {
                            PlayerPos[1] = PlayerPos[1] + (i);
                        }
                        else
                            PlayerPos[1] = PlayerPos[1] + (i - 1);
                    }
                    else
                    {
                        if (_map.GetMap()[PlayerPos[1] + 1, PlayerPos[0]] != '#' && _map.GetMap()[PlayerPos[1] + 1, PlayerPos[0]] != '_' && _map.GetMap()[PlayerPos[1] + 1, PlayerPos[0]] != '/' && _map.GetMap()[PlayerPos[1] + 1, PlayerPos[0]] != 'C' && _map.GetMap()[PlayerPos[1] + 1, PlayerPos[0]] != '~')
                        {
                            if (_map.GetMap()[PlayerPos[1] + 1, PlayerPos[0]] == '-')
                            {
                                PlayerPos[1] = PlayerPos[1] + 2;
                            }
                            else if (_map.GetMap()[PlayerPos[1] + 1, PlayerPos[0]] == 'c')
                            {
                                Console.WriteLine();

                                FullHeal(); Console.WriteLine("Your pokemons has been healed");
                            }
                            else
                            {
                                PlayerPos[1] = PlayerPos[1] + 1;
                            }

                        }
                        if (_map.GetMap()[PlayerPos[1], PlayerPos[0]] == 'w')
                        {
                            Random rand = new Random();
                            int wildEncounter = rand.Next(5);
                            if (wildEncounter == 1)
                            {
                                Console.WriteLine();
                                Console.WriteLine("A wild pokemon appeared");
                                _map.WildBattle = true;
                            }
                        }
                        for (int j = 0; j < 6; j++)
                        {
                            if (_map.GetMap()[PlayerPos[1], PlayerPos[0] - j] == '!' || _map.GetMap()[PlayerPos[1], PlayerPos[0] + j] == '!' || _map.GetMap()[PlayerPos[1] - j, PlayerPos[0]] == '!' || _map.GetMap()[PlayerPos[1] + j, PlayerPos[0]] == '!')
                            {
                                Console.WriteLine("Trainer");
                                _map.TrainerBattle = true;
                                break;
                            }
                        }
                    }
                    break;
                case ConsoleKey.Escape:
                    _map.Menu = true;
                    break;

                default:
                    break;
            }
            _map.ShowMap(PlayerPos);
        }

        static void WritePokemonMenu(List<Option> options, Option selectedOption, Map _map)
        {

            Console.Clear();
            int i = 0;
            int j = 0;
            Console.SetCursorPosition(0, 10);
            foreach (Option option in options)
            {
                if (i >= 9)
                {
                    
                    Console.SetCursorPosition(40, 0 + j);
                    j+= 3;
                }
                else
                {
                    Console.SetCursorPosition(0, 0 + i);
                }

                if (option == selectedOption)
                {
                    Console.Write(">  ");
                }
                else
                {
                    Console.Write(" ");
                }

                Console.WriteLine(option.Name);
                i = i + 3;
            }
        }

        public void SwitchPlace(string name, Map _map)
        {
            int pokemonSwitched =-1;
            int pokemonToSwitch = 0;
            int index = 0;
            foreach (var item in options)
            {
                if(item.Name == name)
                {
                    break;
                }
                pokemonToSwitch++;
            }
            ConsoleKeyInfo menuNavigate;
            do
            {
                menuNavigate = Console.ReadKey();

                // Handle each key input (down arrow will write the menu again with a different selected item)
                if (menuNavigate.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < options.Count)
                    {
                        index++;
                        WritePokemonMenu(options, options[index], _map);
                    }
                }
                if (menuNavigate.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WritePokemonMenu(options, options[index], _map);
                    }
                }
                // Handle different action for the option
                if (menuNavigate.Key == ConsoleKey.Enter)
                {
                    pokemonSwitched = index;
                }
                if (menuNavigate.Key == ConsoleKey.X)
                {
                    _map.Pokemon = false;
                }

            }
            while (pokemonSwitched == -1);

            Pokemon tempPokemonToSwitch = ListPokemonTeam[pokemonToSwitch];
            Pokemon tempPokemonSwitched = ListPokemonTeam[pokemonSwitched];
            ListPokemonTeam.RemoveAt(pokemonToSwitch);
            ListPokemonTeam.Insert(pokemonToSwitch, tempPokemonSwitched);
            ListPokemonTeam.RemoveAt(pokemonSwitched);
            ListPokemonTeam.Insert(pokemonSwitched, tempPokemonToSwitch);

        }

        public void printPokemonTeam(Map _map)
        {
            int i = 100;
            Console.Clear();
            options = new List<Option> { };
            int index = 0;
            foreach (Pokemon p in ListPokemonTeam)
            {
                options.Add(new Option(p.name["english"] + " Level : " + p.level, () => SwitchPlace(p.name["english"] + " Level : " + p.level, _map)));
            }
            WritePokemonMenu(options, options[index], _map);
            ConsoleKeyInfo menuNavigate;
            do
            {
                menuNavigate = Console.ReadKey();

                // Handle each key input (down arrow will write the menu again with a different selected item)
                if (menuNavigate.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < options.Count)
                    {
                        index++;
                        WritePokemonMenu(options, options[index], _map);
                    }
                }
                if (menuNavigate.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WritePokemonMenu(options, options[index], _map);
                    }
                }
                // Handle different action for the option
                if (menuNavigate.Key == ConsoleKey.Enter)
                {
                    options[index].Selected.Invoke();
                    index = 0;
                }
                if (menuNavigate.Key == ConsoleKey.X)
                {
                    _map.Pokemon = false;
                }

            }
            while (_map.Pokemon);

        }
    }
}