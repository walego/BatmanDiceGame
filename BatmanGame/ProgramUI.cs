using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BatmanGame
{
    public class ProgramUI
    {
        private int _villainNumber = 0;
        private Villain _villain = new Villain();
        private Batman _batman = new Batman();
        private int _attackDie = 0;
        private bool _invalidAttack = true;
        private int _batDamage = 0;
        public void Run()
        {
            Game();
        }
        private void Game()
        {
            _batman.Health = 100;
            _villainNumber = 0;
            Console.Clear();
            Console.WriteLine("Batman has been captured and is now trapped in Arkham Asylum by the Joker!!\n" +
                "He will need to fight his way through some of Gotham's toughest villains\n" +
                "in order to stop the Joker's master plan!\n" +
                "\n" +
                "Unfortunately the villains took most of his gadgets, but not all of them!\n" +
                "Batman managed to keep his fists, his lucky Bat-Dice, and 3 other Bat-Gadgets\n" +
                "Pick which 3 gadgets you need:\n" +
                "1. Stun Gun (Low damage but can stun an enemy with a roll of 6)\n" +
                "2. Bat-Bat (Uses only an even number to do moderate damage) \n" +
                "3. Batarang (If you roll a 1, you'll be happy you brought the Batarang)\n" +
                "4. Bat Shark Repellent (We don't know how this got in here but you can take it if you want)\n" +
                "5. Bat-LightSaber (High damage gadget that will only use a 6)\n" +
                "6. Bat-Gauntlet (Similar to the Bat-Bat, but using odd numbers and a less funny name)");

            string gadgetTwo = Console.ReadLine();
            _batman.GadgetTwo = GameStartPick(gadgetTwo);
            string gadgetThree = Console.ReadLine();
            _batman.GadgetThree = GameStartPick(gadgetThree);
            string gadgetFour = Console.ReadLine();
            _batman.GadgetFour = GameStartPick(gadgetFour);
            Console.Clear();
            Console.WriteLine("Those will probably come in handy...maybe...");
            Thread.Sleep(2200);
            //Encounter loop
            while (_batman.Health > 0)
            {
                NewVilian();
                AnyKey();
                //Fight loop
                if (_villain.Name == "The Riddler")
                {
                    RiddlerFight();
                }
                else
                {
                    Console.Clear();
                    while (_villain.Health > 0 && _batman.Health > 0)
                    {
                        TurnStartInfo();
                        _invalidAttack = true;
                        Console.Clear();
                        while (_batman.DiceOne != 0 || _batman.DiceTwo != 0)
                        {

                            while (_invalidAttack)
                            {
                                ChooseAttackDisplay();
                                Console.Write("Please enter the (#) of the Die you want to use: ");
                                string chooseDie = Console.ReadLine();

                                if (chooseDie == "1")
                                {
                                    _attackDie = _batman.DiceOne;
                                    _batman.DiceOne = 0;
                                }
                                else if (chooseDie == "2")
                                {
                                    _attackDie = _batman.DiceTwo;
                                    _batman.DiceTwo = 0;
                                }
                                Console.Write("Please enter the number of the gadget you want to use: ");
                                string chooseGadget = Console.ReadLine();
                                Console.Clear();
                                Batman.Gadget attackGadget = PickGadget(chooseGadget);
                                _batDamage = AttackMethod(attackGadget);
                                if (_batDamage != 0)
                                {
                                    _invalidAttack = false;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid attack");
                                    AnyKey();
                                }
                            } // Loop to ensure valid attack

                            _invalidAttack = true;
                            _villain.Health -= _batDamage;
                            Thread.Sleep(1000);
                            Console.WriteLine($"That attack did {_batDamage} damage to {_villain.Name}!");
                            Thread.Sleep(2000);
                            Console.WriteLine($"They have {_villain.Health} health remaining");
                            AnyKey();
                            Console.Clear();
                            if (_villain.Health < 1)
                            {
                                _batman.DiceTwo = 0;
                                _batman.DiceOne = 0;
                            }
                        }
                        //Check to see if villain is defeated
                        if (_villain.Health < 1)
                        {
                            Console.WriteLine($"{_villain.Name} has been defeated!\n" +
                                $"Batman still has {_batman.Health} health left.");
                            //Defeat Message
                            //Recap Message
                        }
                        else
                        {
                            //Villain Rolls
                            if (!_batman.VillainStunned)
                            {

                                _attackDie = DiceRoll();
                                int villainAttack = VillainAttackMethod();
                                _batman.Health -= villainAttack;
                                Thread.Sleep(2500);
                                Console.WriteLine($"They do {villainAttack} damage to Batman");
                                Thread.Sleep(1500);
                                Console.WriteLine($"Batman has {_batman.Health} health remaining");
                                if (_batman.Health < 1)
                                {
                                    GameOver();
                                }
                                else
                                {
                                    Console.WriteLine("And the fight continues...");
                                    AnyKey();
                                    Console.Clear();
                                }
                            }
                            else
                            {
                                Console.WriteLine($"{_villain.Name} is stunned and cannot attack!");
                                _batman.UnStun();
                                AnyKey();
                                Console.Clear();
                            }
                        }       // Villain Attack
                    }           // Fight Loop
                }               // If--Else for Riddler fight
                _villainNumber++;
                if (_villainNumber == 8)
                {
                    YouWin();
                }
            }                   // Encounter Loop
        }

        //**********************************************HELPER METHODS*******************************************
        private int DiceRoll()
        {
            Random rand = new Random();
            return rand.Next(1, 7);
        }
        private void DiceDisplay()
        {
            switch (_batman.DiceOne)
            {
                case 1:
                    Console.WriteLine("   (1)   ");
                    Console.WriteLine("┌———————┐");
                    Console.WriteLine("│       │");
                    Console.WriteLine("│   o   │");
                    Console.WriteLine("│       │");
                    Console.WriteLine("└———————┘");
                    break;
                case 2:
                    Console.WriteLine("   (1)   ");
                    Console.WriteLine("┌———————┐");
                    Console.WriteLine("│ o     │");
                    Console.WriteLine("│       │");
                    Console.WriteLine("│     o │");
                    Console.WriteLine("└———————┘");
                    break;
                case 3:
                    Console.WriteLine("   (1)   ");
                    Console.WriteLine("┌———————┐");
                    Console.WriteLine("│ o     │");
                    Console.WriteLine("│   o   │");
                    Console.WriteLine("│     o │");
                    Console.WriteLine("└———————┘");
                    break;
                case 4:
                    Console.WriteLine("   (1)   ");
                    Console.WriteLine("┌———————┐");
                    Console.WriteLine("│ o   o │");
                    Console.WriteLine("│       │");
                    Console.WriteLine("│ o   o │");
                    Console.WriteLine("└———————┘");
                    break;
                case 5:
                    Console.WriteLine("   (1)   ");
                    Console.WriteLine("┌———————┐");
                    Console.WriteLine("│ o   o │");
                    Console.WriteLine("│   o   │");
                    Console.WriteLine("│ o   o │");
                    Console.WriteLine("└———————┘");
                    break;
                case 6:
                    Console.WriteLine("   (1)   ");
                    Console.WriteLine("┌———————┐");
                    Console.WriteLine("│ o   o │");
                    Console.WriteLine("│ o   o │");
                    Console.WriteLine("│ o   o │");
                    Console.WriteLine("└———————┘");
                    break;
                default:
                    break;
            }
            switch (_batman.DiceTwo)
            {
                case 1:
                    Console.WriteLine("   (2)   ");
                    Console.WriteLine("┌———————┐");
                    Console.WriteLine("│       │");
                    Console.WriteLine("│   o   │");
                    Console.WriteLine("│       │");
                    Console.WriteLine("└———————┘");
                    break;
                case 2:
                    Console.WriteLine("   (2)   ");
                    Console.WriteLine("┌———————┐");
                    Console.WriteLine("│ o     │");
                    Console.WriteLine("│       │");
                    Console.WriteLine("│     o │");
                    Console.WriteLine("└———————┘");
                    break;
                case 3:
                    Console.WriteLine("   (2)   ");
                    Console.WriteLine("┌———————┐");
                    Console.WriteLine("│ o     │");
                    Console.WriteLine("│   o   │");
                    Console.WriteLine("│     o │");
                    Console.WriteLine("└———————┘");
                    break;
                case 4:
                    Console.WriteLine("   (2)   ");
                    Console.WriteLine("┌———————┐");
                    Console.WriteLine("│ o   o │");
                    Console.WriteLine("│       │");
                    Console.WriteLine("│ o   o │");
                    Console.WriteLine("└———————┘");
                    break;
                case 5:
                    Console.WriteLine("   (2)   ");
                    Console.WriteLine("┌———————┐");
                    Console.WriteLine("│ o   o │");
                    Console.WriteLine("│   o   │");
                    Console.WriteLine("│ o   o │");
                    Console.WriteLine("└———————┘");
                    break;
                case 6:
                    Console.WriteLine("   (2)   ");
                    Console.WriteLine("┌———————┐");
                    Console.WriteLine("│ o   o │");
                    Console.WriteLine("│ o   o │");
                    Console.WriteLine("│ o   o │");
                    Console.WriteLine("└———————┘");
                    break;
                default:
                    break;
            }
        }
        private void TurnStartInfo()
        {
            Console.Clear();
            Console.WriteLine($"Looking at {_villain.Name}, they have approximately {_villain.Health} health remaining\n" +
                $"Batman has {_batman.Health} health left, his Bat fists, a {_batman.GadgetTwo}\n" +
                $"a {_batman.GadgetThree}, and a {_batman.GadgetFour} at his disposal.\n" +
                $"\n" +
                $"\n" +
                $"Are you ready to roll the trusty Bat-Dice?");
            AnyKey();
            Console.Clear();
            Console.Write("Rolling Dice");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.WriteLine(".");
            _batman.DiceOne = DiceRoll();
            Thread.Sleep(500);
            _batman.DiceTwo = DiceRoll();
            Thread.Sleep(500);
            DiceDisplay();
            AnyKey();
        }
        private void ChooseAttackDisplay()
        {
            Console.Clear();
            Console.WriteLine($"Batman's Health: {_batman.Health}\n" +
                $"\n" +
                $"{_villain.Name}'s Health: {_villain.Health}\n" +
                $"\n" +
                $"Availible Gadgets:\n" +
                $"\n" +
                $"1: Fists - They do damage equal to the value of the used die.");
            Console.Write("2: ");
            GadgetInfo(_batman.GadgetTwo);
            Console.Write("3: ");
            GadgetInfo(_batman.GadgetThree);
            Console.Write("4: ");
            GadgetInfo(_batman.GadgetFour);
            DiceDisplay();
        }
        private void GadgetInfo(Batman.Gadget gadget)
        {
            switch (gadget)
            {
                case Batman.Gadget.StunGun:
                    Console.WriteLine("Stun Gun - Roll 6: 6 Damage and Stun");
                    break;
                case Batman.Gadget.BatBat:
                    Console.WriteLine("Bat-Bat - Roll Even: 10 Damage");
                    break;
                case Batman.Gadget.Batarang:
                    Console.WriteLine("Batarang - Roll 1: 13 Damage/Any other Roll: 5 Damage");
                    break;
                case Batman.Gadget.SharkRepellent:
                    Console.WriteLine("Shark Repellent - We don't now what it does, its shark repellent");
                    break;
                case Batman.Gadget.BatLightSaber:
                    Console.WriteLine("Bat-LightSaber - Roll 6: 18 Damage");
                    break;
                case Batman.Gadget.BatGauntlet:
                    Console.WriteLine("Bat-Gauntlet - Roll Odd: 10 Damage");
                    break;

            }
        }

        private Batman.Gadget PickGadget(string gadget)
        {

            if (gadget == "1")
            {
                return _batman.GadgetOne;

            }
            else if (gadget == "2")
            {
                return _batman.GadgetTwo;

            }
            else if (gadget == "3")
            {
                return _batman.GadgetThree;
            }
            else if (gadget == "4")
            {
                return _batman.GadgetFour;
            }
            else if (gadget == "0472")
            {
                return Batman.Gadget.DevTool;
            }
            else if (gadget == "04729")
            {
                _villainNumber = 7;
                return Batman.Gadget.DevTool;
            }
            else
            {
                Console.WriteLine("Trying to get one over on the game? Have fun with your punching.");
                return _batman.GadgetOne;
            }


        }

        private int AttackMethod(Batman.Gadget gadget)
        {
            switch (gadget)
            {
                case Batman.Gadget.StunGun:
                    return _batman.StunGunAttack(_attackDie);
                case Batman.Gadget.BatBat:
                    return _batman.BatBatAttack(_attackDie);
                case Batman.Gadget.Batarang:
                    return _batman.BatarangAttack(_attackDie);
                case Batman.Gadget.SharkRepellent:
                    return _batman.BatSharkRepellent(_attackDie);
                case Batman.Gadget.BatLightSaber:
                    return _batman.BatLightSaber(_attackDie);
                case Batman.Gadget.BatGauntlet:
                    return _batman.BatGauntletAttack(_attackDie);
                case Batman.Gadget.DevTool:
                    return 123456789;
                case Batman.Gadget.Punch:
                default:
                    return _batman.Punch(_attackDie);

            }

        }
        private int VillainAttackMethod()
        {
            switch (_villain.Name)
            {
                case "Random Goon":
                    return _villain.GoonAttack();
                case "Poison Ivy":
                    return _villain.PoisonIvyAttack(_attackDie);
                case "The Penguin":
                    return _villain.PeguinAttack(_attackDie);
                case "Scarecrow":
                    return _villain.ScarecrowAttack(_attackDie);
                case "Two-Face":
                    return _villain.TwoFaceAttack(_attackDie);
                case "Bane":
                    return _villain.BaneAttack(_attackDie);
                case "The Joker":
                    return _villain.JokerAttack(_attackDie);
                default:
                    return 46278;
            }
        }

        private Batman.Gadget GameStartPick(string gadget)
        {
            switch (gadget)
            {
                case "1":
                    return Batman.Gadget.StunGun;
                case "2":
                    return Batman.Gadget.BatBat;
                case "3":
                default:
                    return Batman.Gadget.Batarang;
                case "4":
                    return Batman.Gadget.SharkRepellent;
                case "5":
                    return Batman.Gadget.BatLightSaber;
                case "6":
                    return Batman.Gadget.BatGauntlet;
            }

        }

        private void NewVilian()
        {
            switch (_villainNumber)
            {
                case 0:
                    Console.WriteLine("A Goon is attacking Batman!");
                    _villain.Name = "Random Goon";
                    _villain.Health = 20;
                    break;
                case 1:
                    Console.WriteLine("Poison Ivy is trying to seduce Batman. Stop Her!");
                    _villain.Name = "Poison Ivy";
                    _villain.Health = 25;
                    break;
                case 2:
                    Console.WriteLine("The Peguin waddles his way towards Batman with his umbrella gun.");
                    _villain.Name = "The Penguin";
                    _villain.Health = 45;
                    break;
                case 3:
                    _villain.Name = "The Riddler";
                    _villain.Health = 30;
                    break;
                case 4:
                    Console.WriteLine("The Scarecrow sneaks behind Batman and unleashes his fear toxin. Everything is starting to be distorted. ");
                    _villain.Name = "Scarecrow";
                    _villain.Health = 30;
                    break;
                case 5:
                    Console.WriteLine("Two-Face approaches with his own coin. 'Heads or Tails!'");
                    _villain.Name = "Two-Face";
                    _villain.Health = 35;
                    break;
                case 6:
                    Console.WriteLine("Bane injects himself with venom. He is now 2 times his size!");
                    _villain.Name = "Bane";
                    _villain.Health = 45;
                    break;
                case 7:
                    Console.WriteLine("Batman finally reach the Joker! He cackles as he's ready to fight");
                    _villain.Name = "The Joker";
                    _villain.Health = 35;
                    break;
                default:
                    break;
            }
        }

        private void AnyKey()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        private void YouWin()
        {
            Console.WriteLine("With the Joker and the other villains defeated and in police custody\n" +
                "Gotham City stands safe once again!\n" +
                "");
            Thread.Sleep(5000);
            Console.WriteLine("Now that he has nothing more to worry about, the Caped Crusader decides to\n" +
                "get some well deserved rest and relaxation at the Gotham City beach.\n" +
                "");
            Thread.Sleep(5000);
            Console.WriteLine("As Batman shreds waves with his radical Bat-Surfboard, he smiles as he\n" +
                "enjoys not having anything else that can hurt him at the moment\n" +
                "");
            Thread.Sleep(6000);
            Console.WriteLine("EXCEPT FOR THIS SHARK!!!!");
            Thread.Sleep(2000);
            if (_batman.GadgetTwo == Batman.Gadget.SharkRepellent || _batman.GadgetThree == Batman.Gadget.SharkRepellent || _batman.GadgetFour == Batman.Gadget.SharkRepellent)
            {
                Console.WriteLine("Quick as lighting, Batman pulls out the Bat-Shark Repellent and dispatches the final boss of this game!");
                AnyKey();
                Console.WriteLine("You Win!\n" +
                    "\n" +
                    "Enter 1 to play again\n" +
                    "");
                string play = Console.ReadLine();
                if (play == "1")
                {
                    Run();
                }
                else
                {
                    Console.WriteLine("Thank you for playing!");
                    _batman.Health = 0;
                    AnyKey();
                }
            }
            else
            {
                Console.WriteLine("Unfortunately Batman does not have any gadgets to help him and gets kidnapped by shark in\n" +
                    "one of his own Bat-Burlap Sacks! Oh No!");
                GameOver();
            }
        }
        private void RiddlerFight()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("?");
            Thread.Sleep(1000);
            Console.WriteLine("????????  ? ???  ???????  ? ????????  ? ???  ??? ?? ??????  ??  ??? ?? ??????  ??? ?? ?????  ? ?");
            Thread.Sleep(2000);
            Console.WriteLine("????????? ??? ???????  ????  ? ?? ?? ??? ??? ?? ?????????????  ????  ? ?? ?? ???  ? ???????? ????");
            Console.WriteLine("?????? ?? ??? ???? ??? ??? ??? ?? ?????????????  ????  ? ?? ?? ???  ? ???????? ???????????  ??? ?");
            Console.WriteLine("????????  ? ???  ??? ?? ? ??? ??? ?? ?????????????  ????  ? ?? ?? ???  ? ???????? ????????  ?????");
            Thread.Sleep(2000);
            Console.WriteLine("???  ???? ??? ??? ?? ?????????????  ????  ? ?? ????????? ???  ? ???????? ??????  ????  ?? ?? ??? ?? ?? ?");
            Console.WriteLine("???????? ? ???  ??  ? ?? ???? ? ??? ?????????????????? ????????? ??????????  ????? ?? ? ? ???? ????");
            Console.WriteLine("?????  ?????  ??? ?? ????????? ? ??? ??? ?? ??????????  ????  ? ?? ?? ???  ? ???????? ???? ???");
            Console.WriteLine("????????  ? ???  ??? ?? ?????? ????????????? ???? ????????? ??????????  ????? ?? ? ? ??? ???");
            Console.WriteLine("??? ??? ??? ?? ?????????????  ????  ? ?? ?? ???  ? ???????? ?????? ??  ? ???  ??? ?? ??????  ???");
            Console.WriteLine("????????  ? ???  ??? ?? ??????? ???? ???? ????? ?? ? ???? ???? ?? ?????? ?????? ???????? ???? ?? ? ??? ??");
            Console.WriteLine("????? ???? ???  ????????????  ?????? ????????? ????????  ??????? ?? ? ? ??? ?? ?? ??????  ???");
            Console.WriteLine("????????  ????? ??????? ??????? ????????? ???? ?????????  ??? ????? ?? ? ? ??? ??????? ????  ???");
            Console.WriteLine("???? ????  ????  ??? ?? ???????  ? ??? ??? ?? ???????  ????  ? ?? ?? ???  ? ???????? ????");
            Console.WriteLine("???????????????? ????????? ?????? ????????? ?? ? ? ????????  ? ? ??  ??? ?? ??????  ??");
            Console.WriteLine("????????  ???? ? ??? ??? ?? ????????  ?????  ????  ? ?? ?? ???  ? ???????? ???? ? ?? ?? ???????  ??");
            Console.WriteLine("????????  ? ???  ??? ?? ??????? ???? ???? ????? ?? ? ???? ???? ?? ?????? ?????? ???????? ???? ?? ? ??? ??");
            Console.WriteLine("????????  ????? ??????? ??????? ????????? ???? ?????????  ??? ????? ?? ? ? ??? ??????? ????  ???");
            Console.WriteLine("????????? ???  ??? ?????????????????? ????????? ????????????? ?? ? ? ???? ???? ?? ?? ??");
            Console.WriteLine("????????  ????? ??????? ??????? ????????? ???? ?????????  ??? ????? ?? ? ? ??? ??????? ????  ???");
            Thread.Sleep(90);
            Console.Clear();
            Console.WriteLine("Riddle me this Batman!");
            Thread.Sleep(1000);
            Console.WriteLine("Why is the programmer so bad at writing music?");
            string answer = Console.ReadLine().ToLower();
            if (answer.Contains("c#") && answer.Contains("only") && answer.Contains("use"))
            {
                Console.Clear();
                Thread.Sleep(4000);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("With the Riddler foiled in his attempts to hack this game\n" +
                    "Batman continues forward, looking for his next obstacle\n" +
                    "in finding the Joker.");
            }
            else
            {
                Console.WriteLine("And they call you the world's greatest detective!\n" +
                    "I hope your suit can handle high voltage");
                Console.Clear();
                _batman.Health -= 10;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("The zap from the Riddler did 10 damage to Batman\n" +
                    $"He has {_batman.Health} health remaining.");

            }
        }
        private void GameOver()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Game Over :(\n" +
                "\n" +
                "Enter 1 to play again\n" +
                "");
            Console.ResetColor();
            string play = Console.ReadLine();
            if (play == "1")
            {
                Run();
            }
            else
            {
                Console.WriteLine("Thank you for playing!");
                _batman.Health = 0;
                AnyKey();
            }
        }
    }
}
