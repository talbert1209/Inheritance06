using System;
using System.Collections.Generic;

namespace Inheritance06
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new Player() { Name = "Bob", Strength = 20 };
            var warrior = new Warrior() { Name = "Baltek", Strength = 100, Bonus = 10 };
            var wizard = new Wizard() { Name = "Pentagorn", Strength = 50, Energy = 50 };

            var players = new List<Player>();
            players.Add(player);
            players.Add(warrior);
            players.Add(wizard);

            DoBattle(players);

            Console.ReadLine();
        }

        static void DoBattle(List<Player> players)
        {
            foreach (var player in players)
            {
                player.Attack();
                Console.WriteLine("");
            }
        }
    }

    public class Player
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        private readonly Random _random;

        public Player()
        {
            _random = new Random();
        }
        public virtual void Attack()
        {
            var damage = _random.Next(Strength + 1);
            Console.WriteLine($"{Name} attacked for {damage} damage.");
        }
    }
}

