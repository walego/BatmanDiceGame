using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatmanGame
{
    public class Villain
    {
        public Villain() { }
        public Villain(string villainName, int health)
        {
            Name = villainName;
            Health = health;
        }
        public int Health { get; set; }
        public string Name { get; set; }

        public int GoonAttack()
        {
            Console.WriteLine("Goon foolishly attacks Batman with only his fists");
            return 1;
        }

        public int PoisonIvyAttack(int roll)
        {
            Console.WriteLine("Poison Ivy tries to kiss Batman!");
            if(roll <= 4) 
            {
                Console.WriteLine("Just a Peck");

                return 4;
            }
            else
            {
                Console.WriteLine("She touches the lips. Oh no!");
                return 9;
            }
        }

        public int PeguinAttack(int roll)
        {
            if( roll <= 3)
            {
                Console.WriteLine("Peguin uses umbrella to hit Batman!");
                return 2;
            }
            else if( roll <= 5)
            {
                Console.WriteLine("What, the Peguin has a knife in this umbrella?");
                return 3;
            }
            else
            {
                Console.WriteLine("Umbrella Gun!");
                return 4;
            }
        }

        public int ScarecrowAttack(int roll)
        {
            if(roll == 1)
            {
                Console.WriteLine("Batman resists the fear toxin quite well");
                return 3;
            }
            else if(roll <= 3)
            {
                Console.WriteLine("The fear toxin is starting hurt you!");

                return 6;
            }
            else if(roll <= 5)
            {
                Console.WriteLine("The fear toxin is damaging the Bat Brain");
                return 7;
            }
            else
            {
                Console.WriteLine("The toxin is too much to handle!");
                return 8;
            }
        }

        public int TwoFaceAttack(int roll)
        {
            Console.WriteLine("Two-Face flips his coin!");
            if(roll <= 3)
            {
                
                return 1;
            }
            else
            {
                return 10;
            }
        }

        public int BaneAttack(int roll)
        {
            if(roll == 1)
            {
                Console.WriteLine("Bane puches hard even at no effort");
                return 7;
            }
            else if(roll <= 3)
            {
                Console.WriteLine("Bane feriously punches the batman 5 times");
                return 9;
            }
            else if(roll <= 5)
            {
                Console.WriteLine("Bane throws the Batman across the room");
                return 11;
            }
            else
            {
                Console.WriteLine("Bane does his best to break the Batmans back");
                return 13;
            }
        }

        public int JokerAttack(int roll)
        {
            if(roll == 1)
            {

                Console.WriteLine("Joker's laughter still hurts you");
                return 5;
            }
            else if(roll == 2)
            {
                Console.WriteLine("Shoe Knife, the Joker has many hidden knives");
                return 8;
            }
            else if( roll == 3)
            {
                Console.WriteLine("Joker throws multiple knives at Batman");
                return 11;
            }
            else if(roll == 4)
            {
                Console.WriteLine("Laughting Gas fills the room making it hard to concentrate");
                return 13;

            }
            else if(roll == 5)
            {
                Console.WriteLine("The Joker uses the BatBat he stole and hits for the cycle" );
                return 15;
            }
            else
            {
                Console.WriteLine("The Joker throws a pie with a bomb in it (like in that Spongebob episode)");
                return 17;

            }
        }

    }

}
