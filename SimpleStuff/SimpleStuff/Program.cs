using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("create a username");
            var UName = Console.ReadLine();
            Console.WriteLine("your name is " + UName + "");
            Console.Clear();

            Player currentplayer = new Player(UName);
            currentplayer.LoadPlayer(UName);
            Console.WriteLine("Health: " +currentplayer.Stats.Health);
            Console.WriteLine("Level: " +currentplayer.Level);
            Console.WriteLine("Experience: " + currentplayer.Exp);

            Game(currentplayer);
        }
        static void Game(Player ThisGuy)
        {
            Console.WriteLine("Hello " +ThisGuy.GetName());
            Console.WriteLine("buckle up");
            Monster blob = new Monster(10, "blob");
            
            
            while (blob.Health > 0)
            {
                Console.WriteLine("a "+blob.Name+" has spawned with " +blob.Health+ " health");
                Console.WriteLine("what do you want to do, attack or save");
                var action = Console.ReadLine();
                switch (action) {
                    case "attack":
                        Random RnD = new Random();
                        int dmg = RnD.Next(0, 3);

                        if (dmg == 0)
                        {
                            Console.WriteLine("you bungled it...");
                        }
                        else
                        {
                            Console.WriteLine("you throw a rock and deal " + dmg + " damage");
                            blob.damageHealth(dmg);
                            Console.WriteLine("the " + blob.Name + " has " + blob.Health + " left. YOU GOT THIS!!!");

                            if (blob.Health <= 0)
                            {
                                Console.WriteLine("You defeated the " + blob.Name + "! Congradulations!!");
                                ThisGuy.GiveExp(25);
                                ThisGuy.IncreaseHealth(1);

                                blob = new Monster(10, "blob");
                            }
                        }

                        break;
                    case "save":
                        Console.WriteLine("Saved");
                        blob.Health = 0;
                        ThisGuy.SavePlayer();
                        break;

                default: Console.WriteLine("you had 2 options, and you didnt choose one -_- ");
                        break;
                }
            }
           
            
            Thread.Sleep(2000);
        }
    }
    public class Monster
    {
        public int Health { get; set; }
        public string Name { get; set; }
        public Monster(int health, string name) { Health = health; Name = name; }
        public int damageHealth(int damage)
        {
            Health = Health - damage;
            return Health;
        }
    }
}
