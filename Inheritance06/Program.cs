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
        protected readonly Random Random;

        public Player()
        {
            Random = new Random();
        }
        public virtual void Attack()
        {
            var damage = Random.Next(Strength + 1);
            Console.WriteLine($"{Name} attacked for {damage} damage.");
        }
    }

    public class Warrior : Player
    {
        public int Bonus { get; set; }

        public override void Attack()
        {
            var damage = Random.Next(Strength + 1) + Bonus;
            Console.WriteLine($"{Name} charges for {damage} damage (includes +{Bonus} bonus.)");
        }
    }

    public class Wizard : Player
    {
        public int Energy { get; set; }

        public override void Attack()
        {
            var energyUsage = Random.Next(Energy + 1);
            base.Attack();
            Energy -= energyUsage; 
            Console.WriteLine($"     (Wizard {Name} depleted {energyUsage} energy.)");
        }
    }
}

