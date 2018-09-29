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
            Console.WriteLine("Hello World!");
            Console.WriteLine("make a password");
            var pass = Console.ReadLine();
            Console.WriteLine("password is " + pass + "");
            Console.Clear();
            
            while (true)
            {

                Console.WriteLine("what was the password");
                
                var attempt = Console.ReadLine();
                if (attempt == pass)
                {
                    Console.WriteLine("the game has started");
                    
                    Game();
                    Thread.Sleep(2000);
                    break;
                }
                else
                {
                    Console.WriteLine("how did you forget already");
                }

                Thread.Sleep(2000);
            }
        }
        static void Game()
        {
            Console.WriteLine("buckle up");
            Monster blob = new Monster(10, "blob");
            
            Console.WriteLine("a "+blob.Name+" has spawned with " +blob.Health+ " health");
            while (blob.Health > 0)
            {
                Console.WriteLine("what do you want to do, attack or run");
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
                            Console.WriteLine("the " + blob.Name + "has " + blob.Health + "left. YOU GOT THIS!!!");

                            if (blob.Health <= 0)
                            {
                                Console.WriteLine("You defeated the " + blob.Name + "! Congradulations!!");
                            }
                        }

                        break;
                    case "run":
                        Console.WriteLine("GAME OVER");
                        blob.Health = 0;
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
