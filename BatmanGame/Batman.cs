using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatmanGame
{
    public class Batman
    {
        public enum Gadget { Punch, StunGun, BatBat, Batarang, SharkRepellent, BatGauntlet, BatLightSaber, DevTool }

        public Batman()
        {
            Health = 100;
            GadgetOne = Gadget.Punch;
        }
        public int Health { get; set; }
        public int DiceOne { get; set; }
        public int DiceTwo { get; set; }
        public int DiceThree { get; set; }
        public Gadget GadgetOne { get; set; }
        public Gadget GadgetTwo { get; set; }
        public Gadget GadgetThree { get; set; }
        public Gadget GadgetFour { get; set; }
        public bool VillainStunned { get; set; }
        public int Punch(int roll)
        {
            Console.WriteLine("Batman punches the enemy...you know you have like...other stuff right?");
            return roll;
        }
        public int BatLightSaber(int roll)
        {
            if (roll == 6)
            {
                Console.WriteLine("Batman becomes one with the force and swings his highly damaging laser sword");
                return 18;
            }
            else
            {
                Console.WriteLine("Can only take in a 6");
                return 0;
            }
        }

        public int StunGunAttack(int roll)
        {
            if (roll == 6)
            {
                Console.WriteLine("Batman attempts to defeat the villain with his greatest weapon...action economy!");
                VillainStunned = true;
                return 6;

            }
            else
            {
                Console.WriteLine("Can only take in a 6");
                return 0;
            }

        }
        public int BatarangAttack(int roll)
        {
            if (roll == 1)
            {
                Console.WriteLine("Low roll, huh?");
                return 13;
            }
            else
            {
                Console.WriteLine("It's statiscally better than punching them");
                return 5;
            }
        }

        public int BatBatAttack(int roll)
        {
            if (roll % 2 == 0)
            {
                Console.WriteLine("Batman gets his stance squared up for a home-run swing");
                return 10;
            }
            else
            {
                Console.WriteLine("Can only take in an even");
                return 0;

            }
        }

        public int BatGauntletAttack(int roll)
        {
            if (roll % 2 == 1)
            {
                Console.WriteLine("Batman punches the enemy...but while wearing cool gauntlets");
                return 10;
            }
            else
            {
                Console.WriteLine("Can only take odd numbers");
                return 0;
            }
        }

        public int BatSharkRepellent(int roll)
        {
            Console.WriteLine("You...spray the enemy with...I mean what even is that stuff?");
            Random rng = new Random();
            return rng.Next(1, 21) + roll;
        }
        public void UnStun()
        {
            VillainStunned = false;
        }


    }
}
